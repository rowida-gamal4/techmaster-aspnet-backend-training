using Drill04.DTOs;

namespace Drill04.Services
{
    public interface IStudentService
    {
        public StudentWithEnrollmentsDto? GetStudentWithEnrollmentTracks(int StudentId);
    }
}