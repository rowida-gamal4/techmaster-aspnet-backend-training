using Drill05.DTOs;

namespace Drill05.Services
{
    public interface ITracksService
    {
        public TrackWithStudentsDto? GetTrackWithStudents(int TrackId);
    }
}