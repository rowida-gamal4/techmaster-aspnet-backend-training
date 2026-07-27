using TrainingCenter.Common;
using TrainingCenter.DTOs;

namespace TrainingCenter.Services.IServices
{
   public interface IEnrollmentService
{
    GeneralResponseDto<List<EnrollmentDetailsResponse>> GetAllEnrollments( string? status, int? trackId,int? studentId,string? paymentStatus);

    GeneralResponseDto<EnrollmentDetailsResponse> GetEnrollmentById(int id);

    GeneralResponseDto<EnrollmentDetailsResponse> CreateEnrollment(CreateEnrollmentRequest request);

    GeneralResponseDto<bool> UpdateEnrollmentStatus(int id, UpdateEnrollmentStatusRequest request);

    public GeneralResponseDto<TrackStudentsResponse>GetTrackStudents(int id);

    public GeneralResponseDto<StudentEnrollmentHistoryResponse> GetStudentEnrollmentHistory(int id);
}
}