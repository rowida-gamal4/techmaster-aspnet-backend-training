using TrainingCenter.Common;
using TrainingCenter.DTOs;

namespace TrainingCenter.Services.IServices
{
    public interface IInstructorService
    {
        #region Task03 Special Methods
         public GeneralResponseDto<List<TrackListItemResponse>> GetMyTracks();
         public GeneralResponseDto<TrackSessionResponse> CreateSession(int trackId,CreateTrackSessionRequest request);
         public GeneralResponseDto<TrackSessionResponse> UpdateSession(int id,UpdateTrackSessionRequest request);
        #endregion
        public GeneralResponseDto<List<InstructorListItemResponse>>GetAllInstructors();
        public GeneralResponseDto<InstructorDetailsResponse>GetInstructorById(int id);

        public GeneralResponseDto<InstructorDetailsResponse>CreateInstructor(CreateInstructorRequest instructorRequest);

        public GeneralResponseDto<InstructorDetailsResponse>UpdateInstructor(int id,UpdateInstructorRequest instructorRequest);
 
        public GeneralResponseDto<bool> DeleteInstructor(int id) ;

        public GeneralResponseDto<List<InstructorTracksResponse>> GetInstructorTracks(int id) ;


    }
}