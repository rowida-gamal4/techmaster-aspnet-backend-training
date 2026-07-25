using Microsoft.EntityFrameworkCore;
using TrainingCenter.Api.Data;
using TrainingCenter.Common;
using TrainingCenter.DTOs;
using TrainingCenter.Entities;
using TrainingCenter.Services.IServices;

namespace TrainingCenter.Services
{
    public class ReportService : IReportService
    {
        private readonly AppDbContext context;

        public ReportService(AppDbContext context)
        {
            this.context = context;
        }

       
        public GeneralResponseDto<List<AvailableTrackResponse>> GetAvailableTracks()
        {
            GeneralResponseDto<List<AvailableTrackResponse>> responseDto = new();


            var avaliableTracks = context.TrainingTracks.Where(t => !t.IsDeleted).Select(t => new AvailableTrackResponse()
            {
                TrackId = t.TrackId,
                Title = t.Title,
                Capacity = t.Capacity,
                ActiveEnrollments = t.Enrollments.Count(e => e.Status == EnrollmentStatus.Active),
                RemainingSeats = t.Capacity - t.Enrollments.Count(e => e.Status == EnrollmentStatus.Active)
            }).Where(t => t.RemainingSeats > 0).ToList();



            if (!avaliableTracks.Any())
            {
                responseDto.Success = true;
                responseDto.Message = "No tracks with available seats.";

            }
            else
            {
                responseDto.Success = true;
                responseDto.Message = "Tracks with available seats retrieved successfully";
                responseDto.Data = avaliableTracks;
            }
            return responseDto;
        }


       
        public GeneralResponseDto<List<UnpaidEnrollmentResponse>> GetUnpaidEnrollments()
        {
            var data = context.Enrollments.Where(e => e.Payments.Any(p => p.PaymentStatus == Entities.PaymentStatus.Pending || p.PaymentStatus == Entities.PaymentStatus.PartiallyPaid)).Select(e => new UnpaidEnrollmentResponse
            {
                EnrollmentId = e.EnrollmentId,
                StudentName = e.Student.FullName,
                TrackName = e.TrainingTrack.Title,
                TotalPaid = e.Payments.Sum(p => p.Amount),
                RemainingAmount = e.TrainingTrack.Price - e.Payments.Sum(p => p.Amount),
                PaymentStatus = e.Payments
                        .Select(p => p.PaymentStatus.ToString())
                        .FirstOrDefault() ?? "Pending"
            }).ToList();

            GeneralResponseDto<List<UnpaidEnrollmentResponse>> responseDto = new()
            {
                Success = true,
                Message = "Unpaid enrollments retrieved successfully",
                Data = data
            };

            return responseDto;
        }

        
        public GeneralResponseDto<List<RevenueByTrackResponse>> GetRevenueByTrack()
        {
            var data = context.Payments.Where(p => p.PaymentStatus == PaymentStatus.Paid).GroupBy(p => new
            {
                p.Enrollment.TrainingTrackId,
                p.Enrollment.TrainingTrack.Title
            }).Select(g => new RevenueByTrackResponse
            {
                TrackId = g.Key.TrainingTrackId,
                TrackName = g.Key.Title,
                TotalPaid = g.Sum(p => p.Amount),
                EnrollmentCount = g.Select(p => p.EnrollmentId).Distinct().Count()
            }).ToList();

            return new GeneralResponseDto<List<RevenueByTrackResponse>>
            {
                Success = true,
                Message = "Revenue by track retrieved successfully.",
                Data = data
            };
        }

        
        public GeneralResponseDto<List<TopTrackResponse>> GetTopTracks()
        {
            var data = context.Enrollments.Where(e => e.Status == EnrollmentStatus.Active).GroupBy(e => new
            {
                e.TrainingTrackId,
                e.TrainingTrack.Title
            }).Select(g => new TopTrackResponse
            {
                TrackId = g.Key.TrainingTrackId,
                TrackTitle = g.Key.Title,
                ActiveEnrollmentCount = g.Count()
            }).OrderByDescending(t => t.ActiveEnrollmentCount).Take(5).ToList();

            return new GeneralResponseDto<List<TopTrackResponse>>
            {
                Success = true,
                Message = "Top tracks retrieved successfully.",
                Data = data
            };
        }

       
        public GeneralResponseDto<List<InstructorWorkloadResponse>> GetInstructorWorkload()
        {
            var data = context.Instructors.Select(i => new InstructorWorkloadResponse()
            {
                InstructorId = i.InstructorId,
                InstructorName = i.FullName,
                TrackCount = i.TrainingTracks.Count(),
                ActiveStudentCount = i.TrainingTracks.SelectMany(t => t.Enrollments).Where(e => e.Student.IsActive).Select(e => e.StudentId).Distinct().Count()
            }).ToList();
            return new GeneralResponseDto<List<InstructorWorkloadResponse>>
            {
                Success = true,
                Message = "Instructor workload retrieved successfully.",
                Data = data
            };
        }

       
        public GeneralResponseDto<List<StudentWithoutPaymentResponse>> GetStudentsWithoutPayments()
        {
            var data = context.Enrollments.Where(e => (e.Status == EnrollmentStatus.Active || e.Status == EnrollmentStatus.Pending) && !e.Payments.Any()).Select(e => new StudentWithoutPaymentResponse
            {
                StudentId = e.StudentId,
                FullName = e.Student.FullName,
                TrackTitle = e.TrainingTrack.Title,
                EnrollmentDate = e.EnrollmentDate,
                Status = e.Status
            }).ToList();

            return new GeneralResponseDto<List<StudentWithoutPaymentResponse>>
            {
                Success = true,
                Message = "Students without payments retrieved successfully.",
                Data = data
            };
        }

        
        public GeneralResponseDto<DashboardSummaryResponse> GetDashboardSummary()
        {
            DashboardSummaryResponse summaryResponse = new()
            {
                StudentsCount = context.Students.Count(s => !s.IsDeleted),
                TracksCount = context.Instructors.Count(t => !t.IsActive),
                ActiveEnrollments = context.Enrollments.Count(e => e.Status == EnrollmentStatus.Active),
                Revenue = context.Payments.Where(p => p.PaymentStatus == PaymentStatus.Paid).Sum(p => p.Amount),
                UnpaidCount = context.Enrollments.Count(e => e.Payments.Any(p => p.PaymentStatus == PaymentStatus.Pending || p.PaymentStatus == PaymentStatus.PartiallyPaid))
            };

            GeneralResponseDto<DashboardSummaryResponse> responseDto = new()
            {
                Success = true,
                Message = "Dashboard summary retrieved successfully",
                Data = summaryResponse
            };

            return responseDto;
        }

       
        public GeneralResponseDto<RevenueSummaryResponse> GetRevenueSummary()
        {

            RevenueSummaryResponse summary = new()
            {
                TotalRevenue = context.Payments.Where(p => p.PaymentStatus == PaymentStatus.Paid).Sum(p => p.Amount),
                TotalPayments = context.Payments.Count(),

                PaidCount = context.Payments.Count(p =>
                    p.PaymentStatus == PaymentStatus.Paid),

                PendingCount = context.Payments.Count(p =>
                    p.PaymentStatus == PaymentStatus.Pending ||
                    p.PaymentStatus == PaymentStatus.PartiallyPaid),

                FailedCount = context.Payments.Count(p =>
                    p.PaymentStatus == PaymentStatus.Failed)
            };

            GeneralResponseDto<RevenueSummaryResponse> response = new()
            {
                Success = true,
                Message = "Revenue summary retrieved successfully.",
                Data = summary
            };

            return response;
        }

        public GeneralResponseDto<List<TrackCapacityResponse>> GetTrackCapacity()
        {
            var data = context.TrainingTracks.Include(t => t.Enrollments).Select(t => new TrackCapacityResponse
            {
                TrackId = t.TrackId,
                TrackName = t.Title,
                Capacity = t.Capacity,
                EnrolledStudents = t.Enrollments.Count(),
                AvailableSeats = t.Capacity - t.Enrollments.Count()
            }).ToList();

            GeneralResponseDto<List<TrackCapacityResponse>> responseDto = new()
            {
                Success = true,
                Message = "Track capacity retrieved successfully",
                Data = data
            };

            return responseDto;
        }

    }
}