
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingCenter.Api.Data;
using TrainingCenter.Common;
using TrainingCenter.DTOs;
using TrainingCenter.Entities;
using TrainingCenter.Services.IServices;

namespace TrainingCenter.Services
{
    public class TracksService : ITracksService
    {
        private readonly AppDbContext context;
        private readonly ICurrentUserService currentUserService;

        public TracksService(AppDbContext context, ICurrentUserService currentUserService)
        {
            this.context = context;
            this.currentUserService = currentUserService;
        }

        public GeneralResponseDto<List<TrackListItemResponse>> GetAllTracks(string? keyword, TrackLevel? level, int? instructorId)
        {
            GeneralResponseDto<List<TrackListItemResponse>> response = new();


            var query = context.TrainingTracks.Where(t => !t.IsDeleted && t.Status == "Active").AsQueryable();

            //Instructor 
            if (currentUserService.Role == Role.Instructor)
            {
                var currentInstructorId = context.Users.Where(u => u.Id == currentUserService.UserId).Select(u => u.InstructorId).FirstOrDefault();

                if (currentInstructorId == null)
                {
                    response.Success = false;
                    response.Message = "Instructor not found.";
                    response.ErrorType = ErrorType.NotFound;
                    return response;
                }

                query = query.Where(t => t.InstructorId == currentInstructorId.Value);
            }

            //admin can filter by id 
            if (instructorId.HasValue && currentUserService.Role == Role.Admin)
            {
                query = query.Where(t => t.InstructorId == instructorId.Value);
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();
                query = query.Where(t => t.Title.ToLower().Contains(keyword) || t.Code.ToLower().Contains(keyword) || t.Description.ToLower().Contains(keyword));
            }


            if (level.HasValue)
            {
                query = query.Where(t => t.Level == level.Value);
            }




            var tracks = query.Select(t => new TrackListItemResponse
            {
                TrackId = t.TrackId,
                Title = t.Title,
                Code = t.Code,
                Level = t.Level,
                Status = t.Status,
                Price = t.Price,
                InstructorName = t.Instructor.FullName
            }).ToList();


            response.Success = true;
            response.Message = "Tracks retrieved successfully.";
            response.Data = tracks;

            return response;
        }
        public GeneralResponseDto<TrackDetailsResponse> GetTrackById(int id)
        {
            GeneralResponseDto<TrackDetailsResponse> response = new();
            var track = context.TrainingTracks.Include(t => t.Instructor).Include(t => t.Enrollments).FirstOrDefault(t => t.TrackId == id && !t.IsDeleted);

            if (track is null)
            {
                response.Success = false;
                response.Message = "Track not found";
                response.ErrorType = ErrorType.NotFound;
                return response;
            }
            // student 
            if (currentUserService.Role == Role.Student)
            {
                if (track.Status != "Active")
                {
                    response.Success = false;
                    response.Message = "Track is not available.";
                    response.ErrorType = ErrorType.NotFound;
                    return response;
                }
            }
            //Instructor 
            if (currentUserService.Role == Role.Instructor)
            {
                var currentInstructorId = context.Users.Where(u => u.Id == currentUserService.UserId).Select(u => u.InstructorId).FirstOrDefault();

                if (currentInstructorId == null)
                {
                    response.Success = false;
                    response.Message = "Instructor not found.";
                    response.ErrorType = ErrorType.NotFound;
                    return response;
                }

                if (track.InstructorId != currentInstructorId.Value)
                {
                    response.Success = false;
                    response.Message = "You are not allowed to access this track.";
                    response.ErrorType = ErrorType.Forbidden;
                    return response;
                }
            }

            TrackDetailsResponse details = new()
            {
                TrackId = track.TrackId,
                Title = track.Title,
                Code = track.Code,
                Description = track.Description,
                Level = track.Level,
                Capacity = track.Capacity,
                Status = track.Status,
                Price = track.Price,
                StartDate = track.StartDate,
                EndDate = track.EndDate,
                InstructorId = track.InstructorId,
                InstructorName = track.Instructor.FullName,
                EnrolledStudents = track.Enrollments.Count
            };

            response.Success = true;
            response.Message = "Track retrieved successfully";
            response.Data = details;

            return response;
        }
        public GeneralResponseDto<TrackDetailsResponse> CreateTrack(CreateTrackRequest request)
        {
            GeneralResponseDto<TrackDetailsResponse> response = new();

            if (!context.Instructors.Any(i => i.InstructorId == request.InstructorId))
            {
                response.Success = false;
                response.Message = "Instructor not found";
                response.ErrorType = ErrorType.NotFound;
                return response;
            }
            if (context.TrainingTracks.Any(t => !t.IsDeleted && t.Code.ToLower() == request.Code.ToLower()))
            {
                response.Success = false;
                response.Message = "Track code already exists.";
                response.ErrorType = ErrorType.Conflict;
                return response;
            }

            if (request.Capacity <= 0)
            {
                response.Success = false;
                response.Message = "Capacity must be > 0.";
                response.ErrorType = ErrorType.Validation;
                return response;
            }
            if (request.StartDate >= request.EndDate)
            {
                response.Success = false;
                response.Message = "Start date must be before end date.";
                response.ErrorType = ErrorType.Validation;
                return response;
            }

            TrainingTrack track = new()
            {
                Title = request.Title,
                Code = request.Code,
                Description = request.Description,
                Level = request.Level,
                Capacity = request.Capacity,
                Status = request.Status,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                InstructorId = request.InstructorId,
                Price = request.Price,
                CreatedAt = DateTime.UtcNow
            };

            context.TrainingTracks.Add(track);
            context.SaveChanges();

            TrackDetailsResponse details = new()
            {
                TrackId = track.TrackId,
                Title = track.Title,
                Code = track.Code,
                Description = track.Description,
                Level = track.Level,
                Capacity = track.Capacity,
                Status = track.Status,
                StartDate = track.StartDate,
                Price = track.Price,
                EndDate = track.EndDate,
                InstructorId = track.InstructorId,
                InstructorName = context.Instructors.First(i => i.InstructorId == track.InstructorId).FullName,
                EnrolledStudents = 0
            };

            response.Success = true;
            response.Message = "Track created successfully";
            response.Data = details;

            return response;
        }

        public GeneralResponseDto<TrackDetailsResponse> UpdateTrack(int id, UpdateTrackRequest request)
        {
            GeneralResponseDto<TrackDetailsResponse> response = new();
            var track = context.TrainingTracks.Include(t => t.Instructor).FirstOrDefault(t => t.TrackId == id);

            if (track is null)
            {
                response.Success = false;
                response.Message = "Track not found";
                response.ErrorType = ErrorType.NotFound;
                return response;
            }
            bool codeExists = context.TrainingTracks.Any(t => !t.IsDeleted && t.TrackId != id && t.Code.ToLower() == request.Code.ToLower());
            if (codeExists)
            {
                response.Success = false;
                response.Message = "Track code already exists.";
                response.ErrorType = ErrorType.Conflict;
                return response;
            }

            if (request.Capacity <= 0)
            {
                response.Success = false;
                response.Message = "Capacity must be > 0.";
                response.ErrorType = ErrorType.Validation;
                return response;
            }
            if (request.StartDate >= request.EndDate)
            {
                response.Success = false;
                response.Message = "Start date must be before end date.";
                response.ErrorType = ErrorType.Validation;
                return response;
            }

            // Instructor          
            if (currentUserService.Role == Role.Instructor)
            {
                var currentInstructorId = context.Users.Where(u => u.Id == currentUserService.UserId).Select(u => u.InstructorId).FirstOrDefault();

                if (currentInstructorId == null)
                {
                    response.Success = false;
                    response.Message = "Instructor not found.";
                    response.ErrorType = ErrorType.NotFound;
                    return response;
                }

                if (track.InstructorId != currentInstructorId.Value)
                {
                    response.Success = false;
                    response.Message = "You are not allowed to update this track.";
                    response.ErrorType = ErrorType.Forbidden;
                    return response;
                }
                track.Title = request.Title;
                track.Code = request.Code;
                track.Description = request.Description;
                track.Level = request.Level;
                track.Status = request.Status;
                track.StartDate = request.StartDate;
                track.EndDate = request.EndDate;

            }
            else
            {
                if (!context.Instructors.Any(i => i.InstructorId == request.InstructorId))
                {
                    response.Success = false;
                    response.Message = "Instructor not found";
                    response.ErrorType = ErrorType.NotFound;
                    return response;
                }
                track.Title = request.Title;
                track.Code = request.Code;
                track.Description = request.Description;
                track.Level = request.Level;
                track.Capacity = request.Capacity;
                track.Status = request.Status;
                track.StartDate = request.StartDate;
                track.EndDate = request.EndDate;
                track.InstructorId = request.InstructorId;
                track.Price = request.Price ;
            }
            context.SaveChanges();

            TrackDetailsResponse details = new()
            {
                TrackId = track.TrackId,
                Title = track.Title,
                Code = track.Code,
                Description = track.Description,
                Level = track.Level,
                Capacity = track.Capacity,
                Status = track.Status,
                Price = track.Price,
                StartDate = track.StartDate,
                EndDate = track.EndDate,
                InstructorId = track.InstructorId,
                InstructorName = context.Instructors.Where(i => i.InstructorId == track.InstructorId).Select(i => i.FullName).First(),
                EnrolledStudents = context.Enrollments.Count(e => e.TrainingTrackId == track.TrackId)
            };

            response.Success = true;
            response.Message = "Track updated successfully";
            response.Data = details;

            return response;
        }

        public GeneralResponseDto<bool> DeleteTrack(int id)
        {
            GeneralResponseDto<bool> response = new();

            var track = context.TrainingTracks.FirstOrDefault(t => t.TrackId == id);
            if (track is null)
            {
                response.Success = false;
                response.Message = "Track not found";
                response.ErrorType = ErrorType.NotFound;
                return response;
            }

            bool hasActiveEnrollments = context.Enrollments.Any(e => e.TrainingTrackId == id && e.Status == EnrollmentStatus.Active);

            if (hasActiveEnrollments)
            {
                response.Success = false;
                response.Message = "Track has active enrollments and cannot be deleted.";
                response.ErrorType = ErrorType.Conflict;
                return response;
            }

            track.IsDeleted = true;
            context.SaveChanges();

            response.Success = true;
            response.Message = "Track deleted successfully";
            response.Data = true;

            return response;
        }

        public GeneralResponseDto<TrackDetailsResponse> AssignInstructor(int trackId, AssignInstructorRequest request)
        {
            GeneralResponseDto<TrackDetailsResponse> response = new(); 
            var track = context.TrainingTracks.Include(t=>t.Instructor).FirstOrDefault(t=>t.TrackId == trackId && !t.IsDeleted); 

            if (track is null)
            {
                response.Success = false;
                response.ErrorType = ErrorType.NotFound;
                response.Message = "Track not found.";
                return response;
            }

            var instructor = context.Instructors.FirstOrDefault(i=>i.InstructorId == request.InstructorId);

            if(instructor is null)
            {
                response.Success = false;
                response.ErrorType = ErrorType.NotFound;
                response.Message = "Instructor not found.";
                return response;
            }
            if(!instructor.IsActive)
            {
                response.Success = false;
                response.ErrorType = ErrorType.Validation;
                response.Message = "Instructor must be active.";
                return response;
            }
            track.InstructorId = instructor.InstructorId ;
             context.SaveChanges();

            TrackDetailsResponse detailsResponse = new()
            {
                TrackId = track.TrackId,
                Title = track.Title,
                Code = track.Code,
                Description = track.Description,
                Level = track.Level,
                Capacity = track.Capacity,
                Status = track.Status,
                Price = track.Price,
                StartDate = track.StartDate,
                EndDate = track.EndDate,
                InstructorId = instructor.InstructorId,
                InstructorName = instructor.FullName,
                EnrolledStudents = context.Enrollments.Count(e => e.TrainingTrackId == track.TrackId)            
            };
            response.Success = true;
            response.Message = "Instructor assigned successfully.";
            response.Data = detailsResponse ;
            return response ;

        }
    }




}
