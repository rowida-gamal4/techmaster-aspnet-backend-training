using Drill04.DTOs;
using Drill04.Entities;

namespace Drill04.Services
{
    public interface IInstructorService
    {
        public InstructorWithTracksDto? GetInstructorWithTrack(int id);

    }
}