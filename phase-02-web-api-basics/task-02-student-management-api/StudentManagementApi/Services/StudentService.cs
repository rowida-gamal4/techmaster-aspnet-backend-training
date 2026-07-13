using Microsoft.AspNetCore.Http.HttpResults;
using StudentManagementApi.DTOs;
using StudentManagementApi.Models;

namespace StudentManagementApi.Services
{

    public class StudentService : IStudentService
    {
        private static readonly List<Student> students = new()
        {
        new Student{StudentId = 1, FullName = "Gamal",Email = "gamal@gmail.com",PhoneNumber = "01011111111",TrackName = "ASP.NET",EnrollmentDate = DateTime.Now.AddDays(-30),IsActive = true,},
        new Student{StudentId = 2, FullName = "Hassan",Email = "hassan@gmail.com",PhoneNumber = "01021111111",TrackName = "Front End",EnrollmentDate = DateTime.Now.AddDays(-30),IsActive = true,},
        new Student{StudentId = 1, FullName = "Mohamed",Email = "mohamed@gmail.com",PhoneNumber = "01031111111",TrackName = "Flutter",EnrollmentDate = DateTime.Now.AddDays(-30),IsActive = true,},
        };
        public StudentResponse CreateStudent(CreateStudentRequest studentRequest)
        {
            if (students.Any(s => s.Email.Equals(studentRequest.Email, StringComparison.OrdinalIgnoreCase)))
            {
                return null;
            }

            Student student = new Student()
            {
                StudentId = students.Count + 1,
                FullName = studentRequest.FullName,
                Email = studentRequest.Email,
                PhoneNumber = studentRequest.PhoneNumber,
                TrackName = studentRequest.TrackName,
                EnrollmentDate = DateTime.UtcNow,
                IsActive = true

            };

            students.Add(student);

            StudentResponse studentResponse = new StudentResponse()
            {
                StudentId = student.StudentId,
                EnrollmentDate = student.EnrollmentDate,
                FullName = student.FullName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                TrackName = student.TrackName,
                IsActive = student.IsActive,
                GitHubProfileUrl = student.GitHubProfileUrl ?? "N/A",
                LinkedInProfileUrl = student.LinkedInProfileUrl ?? "N/A"

            };
            return studentResponse;

        }

        public PagedResultResponse GetAllStudents(PagedResultRequest pagedResultRequest)
        {
            var returnedStudents = students.AsEnumerable();
            if (pagedResultRequest.Name != null)
            {
                returnedStudents = students.Where(s => s.FullName.Contains(pagedResultRequest.Name, StringComparison.OrdinalIgnoreCase));
            }
            if (pagedResultRequest.Email != null)
            {
                returnedStudents = returnedStudents.Where(s => s.Email.Contains(pagedResultRequest.Email, StringComparison.OrdinalIgnoreCase));
            }
            if (pagedResultRequest.TrackName != null)
            {
                returnedStudents = returnedStudents.Where(s => s.TrackName.Contains(pagedResultRequest.TrackName, StringComparison.OrdinalIgnoreCase));
            }
            if (pagedResultRequest.IsActive != null)
            {
                returnedStudents = returnedStudents.Where(s => s.IsActive == pagedResultRequest.IsActive);
            }
            if (pagedResultRequest.PageSize != null && pagedResultRequest.PageNumber != null)
            {
                returnedStudents = returnedStudents.Skip((pagedResultRequest.PageNumber.Value - 1) * pagedResultRequest.PageSize.Value).Take(pagedResultRequest.PageSize.Value);
            }


            PagedResultResponse Responses = new()
            {
                PageSize = pagedResultRequest.PageSize,
                PageNumber = pagedResultRequest.PageNumber,
                TotalCount = returnedStudents.Count(),

            };

            foreach (var item in returnedStudents)
            {
                StudentResponse studentResponse = new()
                {
                    StudentId = item.StudentId,
                    EnrollmentDate = item.EnrollmentDate,
                    FullName = item.FullName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    TrackName = item.TrackName,
                    IsActive = item.IsActive,
                    GitHubProfileUrl = item.GitHubProfileUrl ?? "N/A",
                    LinkedInProfileUrl = item.LinkedInProfileUrl ?? "N/A"
                };
                Responses.studentResponses.Add(studentResponse);

            }

            return Responses;
        }

        public StudentResponse GetStudentById(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                StudentResponse studentResponse = new StudentResponse()
                {
                    StudentId = student.StudentId,
                    EnrollmentDate = student.EnrollmentDate,
                    FullName = student.FullName,
                    Email = student.Email,
                    PhoneNumber = student.PhoneNumber,
                    TrackName = student.TrackName,
                    IsActive = student.IsActive,
                    GitHubProfileUrl = student.GitHubProfileUrl ?? "N/A",
                    LinkedInProfileUrl = student.LinkedInProfileUrl ?? "N/A"

                };
                return studentResponse;
            }

            return null;

        }


        public StudentResponse UpdateStudent(int id, UpdateStudentRequest updateStudentRequest)
        {
            if (students.Any(s => s.StudentId != id && s.Email.Equals(updateStudentRequest.Email, StringComparison.OrdinalIgnoreCase)))
            {
                return null;
            }

            var student = students.FirstOrDefault(s => s.StudentId == id);
            if (student is null)
                return null;
            student.FullName = updateStudentRequest.FullName;
            student.Email = updateStudentRequest.Email;
            student.PhoneNumber = updateStudentRequest.PhoneNumber;
            student.TrackName = updateStudentRequest.TrackName;
            student.GitHubProfileUrl = updateStudentRequest.GitHubProfileUrl;
            student.LinkedInProfileUrl = updateStudentRequest.LinkedInProfileUrl;

            StudentResponse studentResponse = new StudentResponse()
            {
                StudentId = student.StudentId,
                EnrollmentDate = student.EnrollmentDate,
                FullName = student.FullName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                TrackName = student.TrackName,
                IsActive = student.IsActive,
                GitHubProfileUrl = student.GitHubProfileUrl ?? "N/A",
                LinkedInProfileUrl = student.LinkedInProfileUrl ?? "N/A"

            };
            return studentResponse;

        }

        public bool? UpdateStudentStatus(int id, bool IsActive)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);

            if (student is null)
                return null;

            student.IsActive = IsActive;

            return student.IsActive;
        }
  
      
        public StudentStatsResponse StudentStats()
        {
           var activeCount = students.Count(s => s.IsActive);

           var inactiveCount = students.Count(s => !s.IsActive);

           var countByTrack = students.GroupBy(s=>s.TrackName).ToDictionary(
            group => group.Key,
            group => group.Count()
            );

           StudentStatsResponse response = new()
           {
               TotalStudents = students.Count ,
               ActiveStudents = activeCount ,
               InActiveStudents = inactiveCount ,
               CountByTrack = countByTrack
              
           };
          return response ;
           

        }

        public bool? DeleteStudent(int id)
        {
             var student = students.FirstOrDefault(s => s.StudentId == id);

            if (student is null)
                return null;

            students.Remove(student);

            return true;
        }
    }
}