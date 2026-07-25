using TrainingCenter.Common;
using TrainingCenter.DTOs;

namespace TrainingCenter.Services.IServices
{
    public interface IReportService
    {
        public GeneralResponseDto<List<AvailableTrackResponse>>GetAvailableTracks() ;
        GeneralResponseDto<DashboardSummaryResponse> GetDashboardSummary();

        GeneralResponseDto<List<UnpaidEnrollmentResponse>> GetUnpaidEnrollments();

        GeneralResponseDto<List<TrackCapacityResponse>> GetTrackCapacity();

        GeneralResponseDto<RevenueSummaryResponse> GetRevenueSummary();

        GeneralResponseDto<List<RevenueByTrackResponse>> GetRevenueByTrack();

        public GeneralResponseDto<List<TopTrackResponse>> GetTopTracks();

         public GeneralResponseDto<List<InstructorWorkloadResponse>> GetInstructorWorkload();
        public GeneralResponseDto<List<StudentWithoutPaymentResponse>> GetStudentsWithoutPayments(); 
    }
}