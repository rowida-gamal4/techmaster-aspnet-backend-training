using Drill04.Api.Data;
using Drill04.DTOs;
using Drill04.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drill04.Services
{
    public class TracksService : ITracksService
    {
        private readonly AppDbContext context;

        public TracksService(AppDbContext context)
        {
            this.context = context;
        }
       

        public TrackWithStudentsDto? GetTrackWithStudents(int TrackId)
        {
            var track = context.TrainingTracks.Include(t=>t.Enrollments).ThenInclude(e=>e.Student).FirstOrDefault(t=>t.TrackId == TrackId);

            if(track is null)
              return null ;
              TrackWithStudentsDto  trackdto = new()
           {
               TrackId = track.TrackId ,
               TrackName = track.TrackName ,
               Students= track.Enrollments.Select(e  => new EnrollmentStudentDto
                    {
                        StudentId = e.Student.Id,
                        FullName = e.Student.FullName ,
                        Status = e.Status ,
                        EnrollmentDate =e.EnrollmentDate ,
                        FinalGrade = e.FinalGrade
                    }).ToList()
            };
           return trackdto ;  
        }
    }
}