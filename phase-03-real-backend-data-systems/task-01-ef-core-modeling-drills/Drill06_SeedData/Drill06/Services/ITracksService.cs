using Drill06.DTOs;

namespace Drill06.Services
{
    public interface ITracksService
    {
        public TrackWithStudentsDto? GetTrackWithStudents(int TrackId);
    }
}