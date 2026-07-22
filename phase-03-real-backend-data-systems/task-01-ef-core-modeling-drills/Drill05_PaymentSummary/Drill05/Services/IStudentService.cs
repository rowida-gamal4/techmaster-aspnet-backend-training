using Drill05.DTOs;

namespace Drill05.Services
{
    public interface IStudentService
    {
        public StudentWithEnrollmentsDto? GetStudentWithEnrollmentTracks(int StudentId);
    }
}