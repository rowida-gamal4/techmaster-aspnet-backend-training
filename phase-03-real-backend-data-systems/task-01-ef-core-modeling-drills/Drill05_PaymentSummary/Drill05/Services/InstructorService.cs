
using Drill05.Api.Data;
using Drill05.DTOs;
using Drill05.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drill05.Services
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