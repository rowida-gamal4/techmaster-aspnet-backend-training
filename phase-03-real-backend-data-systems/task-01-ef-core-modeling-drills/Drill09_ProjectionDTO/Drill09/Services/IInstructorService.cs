using Drill09.DTOs;
using Drill09.Entities;

namespace Drill09.Services
{
    public interface IInstructorService
    {
        public InstructorWithTracksDto? GetInstructorWithTrack(int id);

    }
}