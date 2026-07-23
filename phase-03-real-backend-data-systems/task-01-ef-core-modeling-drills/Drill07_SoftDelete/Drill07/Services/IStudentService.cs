using Drill07.DTOs;
using Drill07.Entities;

namespace Drill07.Services
{
    public interface IStudentService
    {
        public StudentWithEnrollmentsDto? GetStudentWithEnrollmentTracks(int StudentId);
        public List<Student>GetAllStudents();

        public List<Student>GetAllStudentsIncludingDeleted();

        public bool? DeleteStudent(int id) ;
    }
}