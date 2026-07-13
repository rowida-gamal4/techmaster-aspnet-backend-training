using StudentManagementApi.DTOs;
using StudentManagementApi.Models;

namespace StudentManagementApi.Services
{
    public interface IStudentService
    {
        public StudentResponse CreateStudent(CreateStudentRequest studentRequest);

        public PagedResultResponse GetAllStudents(PagedResultRequest pagedResultRequest);

        public StudentResponse GetStudentById (int id);

        public StudentResponse UpdateStudent(int id, UpdateStudentRequest updateStudentRequest);

        public bool? UpdateStudentStatus(int id ,bool IsActive);

        public StudentStatsResponse StudentStats();

        public bool? DeleteStudent (int id);

    }
}