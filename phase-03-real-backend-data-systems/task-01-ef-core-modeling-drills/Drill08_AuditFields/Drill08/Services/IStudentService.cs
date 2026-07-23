using Drill08.DTOs;
using Drill08.Entities;

namespace Drill08.Services
{
    public interface IStudentService
    {
        public Student CreateStudent(CreateStudentDto dto);

        public Student? UpdateStudent(int id, UpdateStudentDto dto);
        public StudentWithEnrollmentsDto? GetStudentWithEnrollmentTracks(int StudentId);
        public List<Student>GetAllStudents();

        public List<Student>GetAllStudentsIncludingDeleted();

        public bool? DeleteStudent(int id) ;
    }
}