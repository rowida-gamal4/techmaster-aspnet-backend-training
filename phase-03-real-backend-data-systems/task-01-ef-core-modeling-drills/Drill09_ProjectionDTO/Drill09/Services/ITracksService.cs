using Drill09.DTOs;

namespace Drill09.Services
{
    public interface ITracksService
    {
        public TrackWithStudentsDto? GetTrackWithStudents(int TrackId);

        public TrackDetailsDto? GetTrackDetails(int id);
    }
}