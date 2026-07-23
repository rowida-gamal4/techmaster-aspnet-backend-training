using Drill09.DTOs;
using Drill09.Entities;

namespace Drill09.Services
{
    public interface IStudentService
    {
        public Student CreateStudent(CreateStudentDto dto);

        public Student? UpdateStudent(int id, UpdateStudentDto dto);
        public StudentWithEnrollmentsDto? GetStudentWithEnrollmentTracks(int StudentId);
        public List<StudentListItemDto>GetAllStudents();

        public List<StudentListItemDto>GetAllStudentsIncludingDeleted();

        public bool? DeleteStudent(int id) ;
    }
}