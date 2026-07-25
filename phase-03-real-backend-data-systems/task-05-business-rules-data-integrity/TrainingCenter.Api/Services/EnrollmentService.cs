
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
            if (student.IsDeleted)
            {
                response.Success = false;
                response.Message = "Deleted students cannot be enrolled.";
                return response;
            }

            if (!student.IsActive)
            {
                response.Success = false;
                response.Message = "Inactive students cannot be enrolled.";
                return response;
            }

            var track = context.TrainingTracks.FirstOrDefault(t => t.TrackId == request.TrainingTrackId);
            if (track is null)
            {
                response.Success = false;
                response.Message = "Track not found";
                return response;
            }

            if (track.Status.Equals("Closed", StringComparison.OrdinalIgnoreCase))
            {
                response.Success = false;
                response.Message = "Closed tracks cannot accept new enrollments.";
                return response;
            }

            bool alreadyEnrolled = context.Enrollments.Any(e => e.StudentId == request.StudentId && e.TrainingTrackId == request.TrainingTrackId && e.Status == EnrollmentStatus.Active);
            if (alreadyEnrolled)
            {
                response.Success = false;
                response.Message = "Student is already enrolled in this track.";
                return response;
            }

            int enrollmentCount = context.Enrollments.Count(e => e.TrainingTrackId == request.TrainingTrackId && e.Status == EnrollmentStatus.Active);
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
                Status = EnrollmentStatus.Pending,
                ProgressPercentage = request.ProgressPercentage,
                CreatedAt = DateTime.UtcNow
            };

            context.Enrollments.Add(enrollment);
            context.SaveChanges();

            EnrollmentDetailsResponse detailsResponse = new()
            {
                EnrollmentId = enrollment.EnrollmentId,
                StudentName = student.FullName,
                TrackTitle = track.Title,
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



        // Query 08 - Enrollment List With Details
        //Query 19 - Advanced Enrollment Filter
        public GeneralResponseDto<List<EnrollmentDetailsResponse>> GetAllEnrollments(EnrollmentStatus? status, int? trackId, int? studentId, string? paymentStatus)
        {
            GeneralResponseDto<List<EnrollmentDetailsResponse>> response = new();
            var returnedEnrollments = context.Enrollments.Include(e => e.Student).Include(e => e.TrainingTrack).Include(e => e.Payments).AsQueryable();

            // Query 09 - Filter Enrollments By Status
            if (status.HasValue)
                returnedEnrollments = returnedEnrollments.Where(e => e.Status == status.Value);

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
                TrackTitle = e.TrainingTrack.Title,
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
                    TrackTitle = enrollment.TrainingTrack.Title,
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
                if (enrollment.Status == EnrollmentStatus.Completed)
                {
                    responseDto.Success = false;
                    responseDto.Message =
                        "Completed enrollment cannot be modified.";
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

        // Query 10 - Student Enrollment History
        public GeneralResponseDto<StudentEnrollmentHistoryResponse> GetStudentEnrollmentHistory(int id)
        {
            GeneralResponseDto<StudentEnrollmentHistoryResponse> response = new();

            var student = context.Students.Where(s => s.StudentId == id).Select(s => new StudentEnrollmentHistoryResponse
            {
                StudentId = s.StudentId,
                FullName = s.FullName,
                Enrollments = s.Enrollments.Select(e => new StudentEnrollmentItemResponse
                {
                    EnrollmentId = e.EnrollmentId,
                    TrackId = e.TrainingTrackId,
                    TrackTitle = e.TrainingTrack.Title,
                    EnrollmentDate = e.EnrollmentDate,
                    Status = e.Status,
                    ProgressPercentage = e.ProgressPercentage,
                    FinalResult = e.FinalResult
                }).ToList()
            }).FirstOrDefault();

            if (student is null)
            {
                response.Success = false;
                response.Message = "Student not found";
                return response;
            }

            response.Success = true;
            response.Message = "Student enrollment history retrieved successfully";
            response.Data = student;

            return response;
        }

        //Query 11 - Track Students

        public GeneralResponseDto<TrackStudentsResponse> GetTrackStudents(int id)
        {
            GeneralResponseDto<TrackStudentsResponse> responseDto = new();

            var track = context.TrainingTracks
                .Where(t => t.TrackId == id)
                .Select(t => new TrackStudentsResponse
                {
                    TrackId = t.TrackId,
                    TrackTitle = t.Title,
                    Students = t.Enrollments.Select(e => new TrackStudentItemResponse
                    {
                        StudentId = e.Student.StudentId,
                        FullName = e.Student.FullName,
                        EnrollmentDate = e.EnrollmentDate,
                        Status = e.Status,
                        ProgressPercentage = e.ProgressPercentage,
                        FinalResult = e.FinalResult
                    }).ToList()
                })
                .FirstOrDefault();

            if (track is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Track not found";
                return responseDto;
            }

            responseDto.Success = true;
            responseDto.Message = "Track students retrieved successfully";
            responseDto.Data = track;

            return responseDto;
        }
    }
}