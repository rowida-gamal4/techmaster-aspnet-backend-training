
using Microsoft.EntityFrameworkCore;
using TrainingCenter.Api.Data;
using TrainingCenter.Common;
using TrainingCenter.DTOs;
using TrainingCenter.Entities;

namespace TrainingCenter.Services
{
    public class TracksService : ITracksService
    {
        private readonly AppDbContext context;

        public TracksService(AppDbContext context)
        {
            this.context = context;
        }

        public GeneralResponseDto<List<TrackListItemResponse>> GetAllTracks(string? keyword,TrackLevel? level,int? instructorId)
        {
            GeneralResponseDto<List<TrackListItemResponse>> response = new();


            var query = context.TrainingTracks.Where(t => !t.IsDeleted && t.Status == "Open").AsQueryable();

            // Query 04 - Track Search
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();
                query = query.Where(t =>t.Title.ToLower().Contains(keyword) ||t.Code.ToLower().Contains(keyword) ||t.Description.ToLower().Contains(keyword));
            }

            // Query 05 - Filter Tracks By Level
            if (level.HasValue)
            {
                query = query.Where(t => t.Level == level.Value);
            }

            // Query 06 - Filter Tracks By Instructor
            if (instructorId.HasValue)
            {
                query = query.Where(t => t.InstructorId == instructorId.Value);
            }

            var tracks = query.Select(t => new TrackListItemResponse
                {
                    TrackId = t.TrackId,
                    Title = t.Title,
                    Code = t.Code,
                    Level = t.Level,
                    Status = t.Status,
                    InstructorName = t.Instructor.FullName
                }) .ToList();

        
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
                return response;
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
                return response;
            }
            if (!context.Instructors.Any(i => i.InstructorId == request.InstructorId))
            {
                response.Success = false;
                response.Message = "Instructor not found";
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
                EndDate = track.EndDate,
                InstructorId = track.InstructorId,
                InstructorName = context.Instructors.First(i => i.InstructorId == track.InstructorId).FullName,
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
                return response;
            }

            bool hasActiveEnrollments = context.Enrollments.Any(e => e.TrainingTrackId == id && e.Status == EnrollmentStatus.Active);

            if (hasActiveEnrollments)
            {
                response.Success = false;
                response.Message = "Track has active enrollments and cannot be deleted.";
                return response;
            }

            track.IsDeleted = true;
            context.SaveChanges();

            response.Success = true;
            response.Message = "Track deleted successfully";
            response.Data = true;

            return response;
        }



    }




}
