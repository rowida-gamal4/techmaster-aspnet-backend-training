using Drill06.Api.Data;
using Drill06.DTOs;
using Drill06.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drill06.Services
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
            var students = context.Students.ToList();
            return students ;
        }
    }
}