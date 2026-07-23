using Drill07.DTOs;

namespace Drill07.Services
{
    public interface ITracksService
    {
        public TrackWithStudentsDto? GetTrackWithStudents(int TrackId);
    }
}