using TrainingCenter.Common;
using TrainingCenter.DTOs;
using TrainingCenter.Entities;

namespace TrainingCenter.Services
{
    public interface ITracksService
    {
        public GeneralResponseDto<List<TrackListItemResponse>> GetAllTracks(string? keyword, TrackLevel? level, int? instructorId);

        public GeneralResponseDto<TrackDetailsResponse> GetTrackById(int id);

        public GeneralResponseDto<TrackDetailsResponse> CreateTrack(CreateTrackRequest request);
        public GeneralResponseDto<TrackDetailsResponse> UpdateTrack(int id, UpdateTrackRequest request);

        public GeneralResponseDto<bool> DeleteTrack(int id);

        public GeneralResponseDto<TrackDetailsResponse> AssignInstructor(int trackId, AssignInstructorRequest request);


    }
}