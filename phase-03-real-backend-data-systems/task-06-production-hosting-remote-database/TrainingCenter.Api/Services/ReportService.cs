using Microsoft.EntityFrameworkCore;
using TrainingCenter.Api.Data;
using TrainingCenter.Common;
using TrainingCenter.DTOs;
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

        public GeneralResponseDto<DashboardSummaryResponse> GetDashboardSummary()
        {
            DashboardSummaryResponse summaryResponse = new()
            {
                TotalStudents = context.Students.Count(s => !s.IsDeleted),
                TotalInstructors = context.Instructors.Count(),
                TotalTracks = context.TrainingTracks.Count(t => !t.IsDeleted),
                TotalEnrollments = context.Enrollments.Count(),
                TotalRevenue = context.Payments.Sum(p => p.Amount)
            };

             GeneralResponseDto<DashboardSummaryResponse> responseDto = new ()
            {
                Success = true,
                Message = "Dashboard summary retrieved successfully",
                Data = summaryResponse 
            };

            return responseDto ;
        }

        public GeneralResponseDto<List<UnpaidEnrollmentResponse>> GetUnpaidEnrollments()
        {
            var data = context.Enrollments.Include(e => e.Student).Include(e => e.TrainingTrack).Include(e => e.Payments).Where(e => e.Payments.Any(p =>
                    p.PaymentStatus == Entities.PaymentStatus.Pending || p.PaymentStatus == Entities.PaymentStatus.PartiallyPaid)).Select(e => new UnpaidEnrollmentResponse
                {
                    EnrollmentId = e.EnrollmentId,
                    StudentName = e.Student.FullName,
                    TrackName = e.TrainingTrack.Title,
                    TotalPaid = e.Payments.Sum(p => p.Amount),
                    PaymentStatus = e.Payments.Select(p => p.PaymentStatus.ToString()).FirstOrDefault() ?? "Pending"
                }).ToList();

             GeneralResponseDto<List<UnpaidEnrollmentResponse>> responseDto = new ()
            {
                Success = true,
                Message = "Unpaid enrollments retrieved successfully",
                Data = data
            };

            return responseDto ;
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

             GeneralResponseDto<List<TrackCapacityResponse>> responseDto = new ()
            {
                Success = true,
                Message = "Track capacity retrieved successfully",
                Data = data
            };

            return responseDto ;
        }

        public GeneralResponseDto<RevenueSummaryResponse> GetRevenueSummary()
        {
            RevenueSummaryResponse summaryResponse = new()
            {
                TotalPayments = context.Payments.Count(),
                TotalRevenue = context.Payments.Sum(p => p.Amount)
            };

             GeneralResponseDto<RevenueSummaryResponse> responseDto = new ()
            {
                Success = true,
                Message = "Revenue summary retrieved successfully",
                Data = summaryResponse
            };

            return responseDto ;
        }

        public GeneralResponseDto<List<RevenueByTrackResponse>> GetRevenueByTrack()
        {
            var data = context.TrainingTracks.Include(t => t.Enrollments).ThenInclude(e => e.Payments).Select(t => new RevenueByTrackResponse
                {
                    TrackId = t.TrackId,
                    TrackName = t.Title,
                    Revenue = t.Enrollments.SelectMany(e => e.Payments).Sum(p => p.Amount)
                }).ToList();

             GeneralResponseDto<List<RevenueByTrackResponse>> responseDto = new ()
            {
                Success = true,
                Message = "Revenue by track retrieved successfully",
                Data = data
            };

            return responseDto ;
        }
    }
}