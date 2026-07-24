
using Microsoft.EntityFrameworkCore;
using TrainingCenter.Api.Data;
using TrainingCenter.Common;
using TrainingCenter.DTOs;
using TrainingCenter.Entities;
using TrainingCenter.Services.IServices;

namespace TrainingCenter.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly AppDbContext context;

        public EnrollmentService(AppDbContext context)
        {
            this.context = context;
        }

        public GeneralResponseDto<EnrollmentDetailsResponse> CreateEnrollment(CreateEnrollmentRequest request)
        {
            GeneralResponseDto<EnrollmentDetailsResponse> response = new();

            var student = context.Students.FirstOrDefault(s => s.StudentId == request.StudentId);
            if (student is null)
            {
                response.Success = false;
                response.Message = "Student not found";
                return response;
            }

            var track = context.TrainingTracks.FirstOrDefault(t => t.TrackId == request.TrainingTrackId);
            if (track is null)
            {
                response.Success = false;
                response.Message = "Track not found";
                return response;
            }

            bool alreadyEnrolled = context.Enrollments.Any(e => e.StudentId == request.StudentId && e.TrainingTrackId == request.TrainingTrackId && e.Status == "Active");
            if (alreadyEnrolled)
            {
                response.Success = false;
                response.Message = "Student is already enrolled in this track.";
                return response;
            }

            int enrollmentCount = context.Enrollments.Count(e => e.TrainingTrackId == request.TrainingTrackId && e.Status == "Active");
            if (enrollmentCount >= track.Capacity)
            {
                response.Success = false;
                response.Message = "Track capacity is full.";
                return response;
            }

            Enrollment enrollment = new()
            {
                StudentId = request.StudentId,
                TrainingTrackId = request.TrainingTrackId,
                EnrollmentDate = DateTime.UtcNow,
                Status = request.Status,
                ProgressPercentage = request.ProgressPercentage,
                CreatedAt = DateTime.UtcNow
            };

            context.Enrollments.Add(enrollment);
            context.SaveChanges();

            EnrollmentDetailsResponse detailsResponse = new()
            {
                EnrollmentId = enrollment.EnrollmentId,
                StudentName = enrollment.Student.FullName,
                TrackName = enrollment.TrainingTrack.Title,
                EnrollmentDate = enrollment.EnrollmentDate,
                Status = enrollment.Status,
                ProgressPercentage = enrollment.ProgressPercentage,
                FinalResult = enrollment.FinalResult,
                PaymentStatus = enrollment.Payments.Select(p => p.PaymentStatus.ToString()).FirstOrDefault() ?? "No Payment",

            };
            response.Success = true;
            response.Message = "Enrollment created successfully.";
            response.Data = detailsResponse;

            return response;
        }

        public GeneralResponseDto<List<EnrollmentDetailsResponse>> GetAllEnrollments(string? status, int? trackId, int? studentId, string? paymentStatus)
        {
            GeneralResponseDto<List<EnrollmentDetailsResponse>> response = new();
            var returnedEnrollments = context.Enrollments.Include(e => e.Student).Include(e => e.TrainingTrack).Include(e => e.Payments).AsQueryable();

            if (!string.IsNullOrEmpty(status))
                returnedEnrollments = returnedEnrollments.Where(e => e.Status == status);

            if (trackId.HasValue)
                returnedEnrollments = returnedEnrollments.Where(e => e.TrainingTrackId == trackId);

            if (studentId.HasValue)
                returnedEnrollments = returnedEnrollments.Where(e => e.StudentId == studentId);

            if (!string.IsNullOrEmpty(paymentStatus))
                if (Enum.TryParse<PaymentStatus>(paymentStatus, true, out var statusEnum))
                {
                    returnedEnrollments = returnedEnrollments
                        .Where(e => e.Payments.Any(p => p.PaymentStatus == statusEnum));
                }

            var enrollments = returnedEnrollments.Select(e => new EnrollmentDetailsResponse
            {
                EnrollmentId = e.EnrollmentId,
                StudentName = e.Student.FullName,
                TrackName = e.TrainingTrack.Title,
                EnrollmentDate = e.EnrollmentDate,
                Status = e.Status,
                PaymentStatus = e.Payments.Select(p => p.PaymentStatus.ToString()).FirstOrDefault() ?? "No Payment",
                ProgressPercentage = e.ProgressPercentage,
                FinalResult = e.FinalResult

            }).ToList();
            response.Success = true;
            response.Message = "Enrollments retrieved successfully";
            response.Data = enrollments;

            return response;
        }

        public GeneralResponseDto<EnrollmentDetailsResponse> GetEnrollmentById(int id)
        {
            GeneralResponseDto<EnrollmentDetailsResponse> responseDto = new();
            var enrollment = context.Enrollments.Include(e => e.Student).Include(e => e.TrainingTrack).Include(e => e.Payments).FirstOrDefault(e => e.EnrollmentId == id);

            if (enrollment is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Enrollment not found";
                return responseDto;
            }
            else
            {
                EnrollmentDetailsResponse detailsResponse = new()
                {
                    EnrollmentId = enrollment.EnrollmentId,
                    StudentName = enrollment.Student.FullName,
                    TrackName = enrollment.TrainingTrack.Title,
                    EnrollmentDate = enrollment.EnrollmentDate,
                    Status = enrollment.Status,
                    PaymentStatus = enrollment.Payments.Select(p => p.PaymentStatus.ToString()).FirstOrDefault() ?? "No Payment",
                    ProgressPercentage = enrollment.ProgressPercentage,
                    FinalResult = enrollment.FinalResult

                };

                responseDto.Success = true;
                responseDto.Message = "Enrollment found successfully";
                responseDto.Data = detailsResponse;

                return responseDto;
            }

        }

        public GeneralResponseDto<bool> UpdateEnrollmentStatus(int id, UpdateEnrollmentStatusRequest request)
        {
            GeneralResponseDto<bool> responseDto = new();

            var enrollment = context.Enrollments.FirstOrDefault(e => e.EnrollmentId == id);

            if (enrollment is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Enrollment not found";
                return responseDto;
            }
            else
            {
                if (enrollment.Status != "Active")
                {
                    responseDto.Success = false;
                    responseDto.Message = "Enrollment status cannot be changed.";
                    return responseDto;
                }
                if (request.Status != "Completed" && request.Status != "Cancelled")
                {
                    responseDto.Success = false;
                    responseDto.Message = "Invalid status.";
                    return responseDto;
                }
                enrollment.Status = request.Status;
                enrollment.UpdatedAt = DateTime.UtcNow;
                context.SaveChanges();

                responseDto.Success = true;
                responseDto.Message = "Enrollment status updated successfully";
                return responseDto;
            }
        }
        public GeneralResponseDto<StudentEnrollmentHistoryResponse> GetStudentEnrollmentHistory(int id)
        {
            GeneralResponseDto<StudentEnrollmentHistoryResponse> responseDto = new();

            var student = context.Students.Include(s => s.Enrollments).ThenInclude(e => e.TrainingTrack).FirstOrDefault(s => s.StudentId == id);

            if (student is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Student not found";
                return responseDto;
            }

            StudentEnrollmentHistoryResponse response = new()
            {
                StudentId = student.StudentId,
                FullName = student.FullName,
                Enrollments = student.Enrollments.Select(e => new StudentEnrollmentItemResponse
                {
                    EnrollmentId = e.EnrollmentId,
                    TrackId = e.TrainingTrackId,
                    TrackName = e.TrainingTrack.Title,
                    EnrollmentDate = e.EnrollmentDate,
                    Status = e.Status,
                    ProgressPercentage = e.ProgressPercentage,
                    FinalResult = e.FinalResult
                }).ToList()
            };

            responseDto.Success = true;
            responseDto.Message = "Student enrollment history retrieved successfully";
            responseDto.Data = response;

            return responseDto;
        }

        public GeneralResponseDto<TrackStudentsResponse> GetTrackStudents(int id)
        {
            GeneralResponseDto<TrackStudentsResponse> responseDto = new();

            var track = context.TrainingTracks.Include(t => t.Enrollments).ThenInclude(e => e.Student).FirstOrDefault(t => t.TrackId == id);
            if (track is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Track not found";
                return responseDto;
            }

            TrackStudentsResponse response = new()
            {
                TrackId = track.TrackId,
                TrackName = track.Title,
                Students = track.Enrollments.Select(e => new TrackStudentItemResponse
                {
                    StudentId = e.Student.StudentId,
                    FullName = e.Student.FullName,
                    EnrollmentDate = e.EnrollmentDate,
                    Status = e.Status,
                    ProgressPercentage = e.ProgressPercentage,
                    FinalResult = e.FinalResult

                }).ToList()
            };

            responseDto.Success = true;
            responseDto.Message = "Track students retrieved successfully";
            responseDto.Data = response;

            return responseDto;
        }
    }
}