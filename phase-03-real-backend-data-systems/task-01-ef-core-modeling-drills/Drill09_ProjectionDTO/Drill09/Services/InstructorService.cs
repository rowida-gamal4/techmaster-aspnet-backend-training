
using Drill09.Api.Data;
using Drill09.DTOs;
using Drill09.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drill09.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly AppDbContext context;

        public InstructorService(AppDbContext context)
        {
            this.context = context;
        }


        public InstructorWithTracksDto? GetInstructorWithTrack(int id)
        {
            var instructor = context.Instructors.Include(i => i.TrainingTracks).FirstOrDefault(i => i.Id == id);

            if (instructor is null)
                return null;

            var instructorDto = new InstructorWithTracksDto
            {
                Id = instructor.Id,
                FullName = instructor.FullName,
                TrainingTracks = instructor.TrainingTracks.Select(track => new TrackDto
                    {
                        TrackId = track.TrackId,
                        TrackName = track.TrackName
                    }).ToList()
            };
            return instructorDto;
        }

    }
}