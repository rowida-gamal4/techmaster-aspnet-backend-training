using Drill03.DTOs;
using Drill03.Entities;

namespace Drill03.Services
{
    public interface IInstructorService
    {
        public InstructorWithTracksDto? GetInstructorWithTrack(int id);

    }
}