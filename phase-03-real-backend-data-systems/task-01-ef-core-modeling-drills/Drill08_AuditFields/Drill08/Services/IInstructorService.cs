using Drill08.DTOs;
using Drill08.Entities;

namespace Drill08.Services
{
    public interface IInstructorService
    {
        public InstructorWithTracksDto? GetInstructorWithTrack(int id);

    }
}