using Drill10.Api.Data;
using Drill10.DTOs;
using Drill10.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drill10.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext context;

        public StudentService(AppDbContext context)
        {
            this.context = context;
        }

        public PaginationResult<StudentListItemDto> GetStudents(int pageNumber, int pageSize)
        {
            var totalCount = context.Students.Count(s => !s.IsDeleted);

            var students = context.Students.Where(s => !s.IsDeleted).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(s => new StudentListItemDto
                {
                    Id = s.Id,
                    FullName = s.FullName,
                    Email = s.Email
                }).ToList();

            return new PaginationResult<StudentListItemDto>
            {
                Items = students,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize)
            };
        }
        public StudentWithEnrollmentsDto? GetStudentWithEnrollmentTracks(int StudentId)
        {
           var student = context.Students.Include(s=>s.Enrollments).ThenInclude(e=>e.TrainingTrack).FirstOrDefault(s=>s.Id == StudentId);
           
           if(student is null)
            return null ;

            StudentWithEnrollmentsDto  studentdto = new()
           {
               Id = student.Id ,
               FullName = student.FullName ,
               Tracks= student.Enrollments.Select(e  => new EnrollmentTrackDto
                    {
                        TrackId = e.TrainingTrack.TrackId,
                        TrackName = e.TrainingTrack.TrackName ,
                        Status = e.Status ,
                        EnrollmentDate =e.EnrollmentDate ,
                        FinalGrade = e.FinalGrade
                    }).ToList()
            };
           return studentdto ;
        }


        public bool? DeleteStudent(int id)
        {
            var student = context.Students.FirstOrDefault(s=>s.Id == id);
            
            if(student is null)
             return null ;
            student.IsDeleted = true ;
            student.DeletedAt = DateTime.Now ;
            context.SaveChanges();
            return true ; 
        }

        public List<StudentListItemDto> GetAllStudentsIncludingDeleted()
        {
            var students = context.Students.Select(s => new StudentListItemDto
            {
                Id = s.Id,
                FullName = s.FullName,
                Email = s.Email
            }).ToList();
            return students ;
        }

        public Student CreateStudent(CreateStudentDto dto)
        {
            Student student = new()
            {
                FullName = dto.FullName,
                Email = dto.Email,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.UtcNow
            };

            context.Students.Add(student);
            context.SaveChanges();

            return student;
        }
        public Student? UpdateStudent(int id, UpdateStudentDto dto)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == id);

            if (student is null)
                return null;

            student.FullName = dto.FullName;
            student.Email = dto.Email;
            student.IsActive = dto.IsActive;
            student.UpdatedAt = DateTime.UtcNow;

            context.SaveChanges();

            return student;
        }
    }
}