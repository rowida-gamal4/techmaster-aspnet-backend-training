using Drill05.DTOs;
using Drill05.Entities;

namespace Drill05.Services
{
    public interface IInstructorService
    {
        public InstructorWithTracksDto? GetInstructorWithTrack(int id);

    }
}