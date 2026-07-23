using Drill06.DTOs;
using Drill06.Entities;

namespace Drill06.Services
{
    public interface IStudentService
    {
        public StudentWithEnrollmentsDto? GetStudentWithEnrollmentTracks(int StudentId);
        public List<Student>GetAllStudents();
    }
}