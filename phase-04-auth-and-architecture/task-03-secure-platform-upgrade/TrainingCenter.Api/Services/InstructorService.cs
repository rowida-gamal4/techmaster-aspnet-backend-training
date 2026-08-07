
using Microsoft.EntityFrameworkCore;
using TrainingCenter.Api.Data;
using TrainingCenter.Common;
using TrainingCenter.DTOs;
using TrainingCenter.Entities;
using TrainingCenter.Services.IServices;

namespace TrainingCenter.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly AppDbContext context;
        private readonly ICurrentUserService currentUserService;

        public InstructorService(AppDbContext context, ICurrentUserService currentUserService)
        {
            this.context = context;
            this.currentUserService = currentUserService;
        }
        #region Task03 Special Methods
        public GeneralResponseDto<List<TrackListItemResponse>> GetMyTracks()
        {
            GeneralResponseDto<List<TrackListItemResponse>> response = new();

            var currentInstructorId = context.Users.Where(u => u.Id == currentUserService.UserId).Select(u => u.InstructorId).FirstOrDefault();

            if (currentInstructorId == null)
            {
                response.Success = false;
                response.Message = "Instructor profile not found.";
                response.ErrorType = ErrorType.NotFound;
                return response;
            }

            var tracks = context.TrainingTracks.Where(t => !t.IsDeleted && t.InstructorId == currentInstructorId.Value).Select(t => new TrackListItemResponse
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

        public GeneralResponseDto<TrackSessionResponse> CreateSession(int trackId, CreateTrackSessionRequest request)
        {
            GeneralResponseDto<TrackSessionResponse> response = new();
            var currentInstructorId = context.Users.Where(u => u.Id == currentUserService.UserId).Select(u => u.InstructorId).FirstOrDefault();

            if (currentInstructorId == null)
            {
                response.Success = false;
                response.Message = "Instructor profile not found.";
                response.ErrorType = ErrorType.NotFound;
                return response;
            }

            var track = context.TrainingTracks.FirstOrDefault(t => t.TrackId == trackId && !t.IsDeleted);

            if (track is null)
            {
                response.Success = false;
                response.Message = "Track not found.";
                response.ErrorType = ErrorType.NotFound;
                return response;
            }

            if (track.InstructorId != currentInstructorId)
            {
                response.Success = false;
                response.Message = "You are not allowed to create sessions for another instructor's track.";
                response.ErrorType = ErrorType.Forbidden;
                return response;
            }
            var session = new TrackSession
            {
                TrainingTrackId = trackId,
                SessionDate = request.SessionDate,
                Title = request.Title,
                Description = request.Description,
                MeetingLink = request.MeetingLink,
                IsCompleted = false,
                CreatedByInstructorId = currentInstructorId.Value
            };

            context.TrackSessions.Add(session);
            context.SaveChanges();
            response.Success = true;
            response.Message = "Track session created successfully.";
            response.Data = new TrackSessionResponse
            {
                SessionId = session.SessionId,
                TrainingTrackId = session.TrainingTrackId,
                SessionDate = session.SessionDate,
                Title = session.Title,
                Description = session.Description,
                MeetingLink = session.MeetingLink,
                IsCompleted = session.IsCompleted,
                CreatedByInstructorId = session.CreatedByInstructorId
            };

            return response;
        }

        public GeneralResponseDto<TrackSessionResponse> UpdateSession(int id, UpdateTrackSessionRequest request)
        {
            GeneralResponseDto<TrackSessionResponse> response = new();

            var currentInstructorId = context.Users.Where(u => u.Id == currentUserService.UserId).Select(u => u.InstructorId).FirstOrDefault();

            if (currentInstructorId == null)
            {
                response.Success = false;
                response.Message = "Instructor profile not found.";
                response.ErrorType = ErrorType.NotFound;
                return response;
            }

            var session = context.TrackSessions.Include(s => s.TrainingTrack).FirstOrDefault(s => s.SessionId == id);

            if (session is null)
            {
                response.Success = false;
                response.Message = "Session not found.";
                response.ErrorType = ErrorType.NotFound;
                return response;
            }

            if (session.TrainingTrack.InstructorId != currentInstructorId.Value)
            {
                response.Success = false;
                response.Message = "You are can not update session of another instructor's track.";
                response.ErrorType = ErrorType.Forbidden;
                return response;
            }

            session.SessionDate = request.SessionDate;
            session.Title = request.Title;
            session.Description = request.Description;
            session.MeetingLink = request.MeetingLink;
            session.IsCompleted = request.IsCompleted;

            context.SaveChanges();

            response.Success = true;
            response.Message = "Session updated successfully.";
            response.Data = new TrackSessionResponse
            {
                SessionId = session.SessionId,
                TrainingTrackId = session.TrainingTrackId,
                SessionDate = session.SessionDate,
                Title = session.Title,
                Description = session.Description,
                MeetingLink = session.MeetingLink,
                IsCompleted = session.IsCompleted,
                CreatedByInstructorId = session.CreatedByInstructorId
            };

            return response;
        }
        #endregion

        public GeneralResponseDto<InstructorDetailsResponse> CreateInstructor(CreateInstructorRequest request)
        {
            GeneralResponseDto<InstructorDetailsResponse> response = new();

            if (context.Instructors.Any(i => i.Email.ToLower() == request.Email.ToLower()))
            {
                response.Success = false;
                response.Message = "Email already exists.";
                response.ErrorType = ErrorType.Conflict;
                return response;
            }

            if (context.Users.Any(u => u.Email.ToLower() == request.Email.ToLower()))
            {
                response.Success = false;
                response.Message = "Email already exists.";
                response.ErrorType = ErrorType.Conflict;
                return response;
            }

            using var transaction = context.Database.BeginTransaction();

            try
            {
                Instructor instructor = new()
                {
                    FullName = request.FullName,
                    Email = request.Email,
                    Specialization = request.Specialization,
                    Bio = request.Bio,
                    IsActive = request.IsActive,
                    CreatedAt = DateTime.UtcNow
                };

                context.Instructors.Add(instructor);
                context.SaveChanges();

                ApplicationUser user = new()
                {
                    FullName = instructor.FullName,
                    Email = instructor.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    Role = Role.Instructor,
                    IsActive = instructor.IsActive,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    InstructorId = instructor.InstructorId,
                    StudentId = null
                };

                context.Users.Add(user);
                context.SaveChanges();

                transaction.Commit();

                InstructorDetailsResponse detailsResponse = new()
                {
                    InstructorId = instructor.InstructorId,
                    FullName = instructor.FullName,
                    Email = instructor.Email,
                    Specialization = instructor.Specialization,
                    Bio = instructor.Bio,
                    IsActive = instructor.IsActive,
                    CreatedAt = instructor.CreatedAt
                };

                response.Success = true;
                response.Message = "Instructor and user account created successfully.";
                response.Data = detailsResponse;

                return response;
            }
            catch
            {
                transaction.Rollback();

                response.Success = false;
                response.Message = "Failed to create instructor.";
                response.ErrorType = ErrorType.Conflict;

                return response;
            }
        }
        public GeneralResponseDto<bool> DeleteInstructor(int id)
        {
            GeneralResponseDto<bool> responseDto = new();
            var instructor = context.Instructors.FirstOrDefault(s => s.InstructorId == id);

            if (instructor is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Instructor not found";
                responseDto.ErrorType = ErrorType.NotFound;
            }
            else
            {

                context.Remove(instructor);
                context.SaveChanges();

                responseDto.Success = true;
                responseDto.Message = "Instructor deleted successfully";
            }
            return responseDto;
        }

        public GeneralResponseDto<List<InstructorListItemResponse>> GetAllInstructors()
        {
            GeneralResponseDto<List<InstructorListItemResponse>> response = new();
            var instructors = context.Instructors.Select(i => new InstructorListItemResponse
            {
                InstructorId = i.InstructorId,
                FullName = i.FullName,
                Email = i.Email,
                Specialization = i.Specialization
            }).ToList();

            response.Success = true;
            response.Message = "Instructors retrieved successfully";
            response.Data = instructors;

            return response;
        }

        public GeneralResponseDto<InstructorDetailsResponse> GetInstructorById(int id)
        {
            GeneralResponseDto<InstructorDetailsResponse> responseDto = new();

            var instructor = context.Instructors.FirstOrDefault(i => i.InstructorId == id);

            if (instructor is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Instructor not found";
                responseDto.ErrorType = ErrorType.NotFound;
                return responseDto;
            }

            //Instructor 
            if (currentUserService.Role == Role.Instructor)
            {
                var currentUser = context.Users.FirstOrDefault(u => u.Id == currentUserService.UserId);
                if (currentUser?.InstructorId != id)
                {
                    responseDto.Success = false;
                    responseDto.Message = "You are not allowed to view this instructor.";
                    responseDto.ErrorType = ErrorType.Forbidden;
                    return responseDto;
                }

            }

            InstructorDetailsResponse detailsResponse = new()
            {
                InstructorId = instructor.InstructorId,
                FullName = instructor.FullName,
                Email = instructor.Email,
                Specialization = instructor.Specialization,
                Bio = instructor.Bio,
                IsActive = instructor.IsActive,
                CreatedAt = instructor.CreatedAt
            };
            responseDto.Success = true;
            responseDto.Message = "Instructor found successfully";
            responseDto.Data = detailsResponse;

            return responseDto;
        }

        public GeneralResponseDto<List<InstructorTracksResponse>> GetInstructorTracks(int id)
        {
            GeneralResponseDto<List<InstructorTracksResponse>> responseDto = new();

            var instructor = context.Instructors.Include(i => i.TrainingTracks).FirstOrDefault(i => i.InstructorId == id);

            if (instructor is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Instructor not found";
                responseDto.ErrorType = ErrorType.NotFound;
                return responseDto;
            }

            //Instructor 
            if (currentUserService.Role == Role.Instructor)
            {
                var currentUser = context.Users.FirstOrDefault(u => u.Id == currentUserService.UserId);
                if (currentUser?.InstructorId != id)
                {
                    responseDto.Success = false;
                    responseDto.Message = "You are not allowed to view this tracks.";
                    responseDto.ErrorType = ErrorType.Forbidden;
                    return responseDto;
                }

            }

            var tracks = instructor.TrainingTracks.Select(t => new InstructorTracksResponse
            {
                TrackId = t.TrackId,
                Title = t.Title,
                Code = t.Code,
                Level = t.Level,
                Status = t.Status
            })
                .ToList();

            responseDto.Success = true;
            responseDto.Message = "Instructor tracks retrieved successfully";
            responseDto.Data = tracks;

            return responseDto;
        }


        public GeneralResponseDto<InstructorDetailsResponse> UpdateInstructor(int id, UpdateInstructorRequest instructorRequest)
        {
            GeneralResponseDto<InstructorDetailsResponse> responseDto = new();

            var instructor = context.Instructors.FirstOrDefault(i => i.InstructorId == id);
            if (instructor is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Instructor not found";
                responseDto.ErrorType = ErrorType.NotFound;
                return responseDto;
            }
            //Instructor 
            if (currentUserService.Role == Role.Instructor)
            {
                var currentUser = context.Users.FirstOrDefault(u => u.Id == currentUserService.UserId);
                if (currentUser?.InstructorId != id)
                {
                    responseDto.Success = false;
                    responseDto.Message = "You are not allowed to update this instructor.";
                    responseDto.ErrorType = ErrorType.Forbidden;
                    return responseDto;
                }

            }

            bool emailExists = context.Instructors.Any(i => i.InstructorId != id && i.Email == instructorRequest.Email);
            if (emailExists)
            {
                responseDto.Success = false;
                responseDto.ErrorType = ErrorType.Conflict;
                responseDto.Message = "Email already exists";
                return responseDto;
            }

            else
            {
                instructor.FullName = instructorRequest.FullName;
                instructor.Email = instructorRequest.Email;
                instructor.IsActive = instructorRequest.IsActive;
                instructor.Specialization = instructorRequest.Specialization;
                instructor.Bio = instructorRequest.Bio;
                context.SaveChanges();

                InstructorDetailsResponse detailsResponse = new()
                {
                    InstructorId = instructor.InstructorId,
                    FullName = instructor.FullName,
                    Email = instructor.Email,
                    Specialization = instructor.Specialization,
                    Bio = instructor.Bio,
                    IsActive = instructor.IsActive,
                    CreatedAt = instructor.CreatedAt,

                };

                responseDto.Success = true;
                responseDto.Message = "Instructor updated successfully";
                responseDto.Data = detailsResponse;

            }

            return responseDto;
        }
    }
}