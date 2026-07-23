using Drill10.DTOs;
using Drill10.Entities;

namespace Drill10.Services
{
    public interface IStudentService
    {
        public Student CreateStudent(CreateStudentDto dto);

        public Student? UpdateStudent(int id, UpdateStudentDto dto);
        public StudentWithEnrollmentsDto? GetStudentWithEnrollmentTracks(int StudentId);


        public PaginationResult<StudentListItemDto> GetStudents(int pageNumber, int pageSize);

        public List<StudentListItemDto>GetAllStudentsIncludingDeleted();

        public bool? DeleteStudent(int id) ;
    }
}