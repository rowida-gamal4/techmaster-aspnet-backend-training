using Drill06.DTOs;
using Drill06.Entities;

namespace Drill06.Services
{
    public interface IInstructorService
    {
        public InstructorWithTracksDto? GetInstructorWithTrack(int id);

    }
}