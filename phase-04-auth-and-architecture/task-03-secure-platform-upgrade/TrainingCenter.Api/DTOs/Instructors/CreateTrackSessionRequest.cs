using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.DTOs
{
    public class CreateTrackSessionRequest
    {
        [Required]
        public DateTime SessionDate { get; set; }

        [Required]
        public string Title { get; set; } = default!;

        public string? Description { get; set; }

        public string? MeetingLink { get; set; }
    }
}