using Drill07.DTOs;
using Drill07.Entities;

namespace Drill07.Services
{
    public interface IInstructorService
    {
        public InstructorWithTracksDto? GetInstructorWithTrack(int id);

    }
}