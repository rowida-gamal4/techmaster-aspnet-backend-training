using Drill04.DTOs;

namespace Drill04.Services
{
    public interface ITracksService
    {
        public TrackWithStudentsDto? GetTrackWithStudents(int TrackId);
    }
}