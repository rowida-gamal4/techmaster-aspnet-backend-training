using Drill07.Api.Data;
using Drill07.DTOs;
using Drill07.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drill07.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext context;

        public StudentService(AppDbContext context)
        {
            this.context = context;
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

        public List<Student>GetAllStudents()
        {
            var students = context.Students.Where(s=>!s.IsDeleted).ToList();
            return students ;
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

        public List<Student> GetAllStudentsIncludingDeleted()
        {
            var students = context.Students.ToList();
            return students ;
        }
    }
}