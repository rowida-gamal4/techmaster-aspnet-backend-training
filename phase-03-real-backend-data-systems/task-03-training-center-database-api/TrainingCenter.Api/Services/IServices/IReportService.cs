using TrainingCenter.Common;
using TrainingCenter.DTOs;

namespace TrainingCenter.Services.IServices
{
    public interface IReportService
    {
        GeneralResponseDto<DashboardSummaryResponse> GetDashboardSummary();

        GeneralResponseDto<List<UnpaidEnrollmentResponse>> GetUnpaidEnrollments();

        GeneralResponseDto<List<TrackCapacityResponse>> GetTrackCapacity();

        GeneralResponseDto<RevenueSummaryResponse> GetRevenueSummary();

        GeneralResponseDto<List<RevenueByTrackResponse>> GetRevenueByTrack();
    }
}