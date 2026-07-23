using Drill10.DTOs;
using Drill10.Entities;

namespace Drill10.Services
{
    public interface IInstructorService
    {
        public InstructorWithTracksDto? GetInstructorWithTrack(int id);

    }
}