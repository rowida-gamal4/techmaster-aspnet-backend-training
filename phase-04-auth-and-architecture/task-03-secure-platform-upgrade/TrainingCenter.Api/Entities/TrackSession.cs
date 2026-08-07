using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.Entities
{
    public class TrackSession
    {
        [Key]
        public int SessionId { get; set; }

        [Required]
        public DateTime SessionDate { get; set; }

        [Required]
        public string Title { get; set; } = default!;

        public string? Description { get; set; }

        public string? MeetingLink { get; set; }

        public bool IsCompleted { get; set; }

        [Required]
        public int CreatedByInstructorId { get; set; }

        [Required]
        public int TrainingTrackId { get; set; }

        public TrainingTrack TrainingTrack { get; set; } = default!;


        public Instructor CreatedByInstructor { get; set; } = default!;
    }
}