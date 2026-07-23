using Drill08.DTOs;

namespace Drill08.Services
{
    public interface ITracksService
    {
        public TrackWithStudentsDto? GetTrackWithStudents(int TrackId);
    }
}