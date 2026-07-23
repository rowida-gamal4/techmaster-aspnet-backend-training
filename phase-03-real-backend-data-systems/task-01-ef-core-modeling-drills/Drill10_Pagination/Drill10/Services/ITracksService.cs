using Drill10.DTOs;

namespace Drill10.Services
{
    public interface ITracksService
    {
        public TrackWithStudentsDto? GetTrackWithStudents(int TrackId);

        public TrackDetailsDto? GetTrackDetails(int id);
    }
}