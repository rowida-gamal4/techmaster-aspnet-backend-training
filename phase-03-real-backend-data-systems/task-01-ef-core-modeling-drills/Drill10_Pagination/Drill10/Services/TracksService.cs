using Drill10.Api.Data;
using Drill10.DTOs;
using Drill10.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drill10.Services
{
    public class TracksService : ITracksService
    {
        private readonly AppDbContext context;

        public TracksService(AppDbContext context)
        {
            this.context = context;
        }

        public TrackDetailsDto? GetTrackDetails(int id)
        {
           var track = context.TrainingTracks.Where(t => t.TrackId == id).Select(t => new TrackDetailsDto
            {
                TrackId = t.TrackId,
                TrackName = t.TrackName,
                InstructorName = t.Instructor.FullName
            }).FirstOrDefault();

            if (track is null)
             return null ;

            return track ; 


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