using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.DTOs
{
    public class CreateTrackRequest
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Code { get; set; } = string.Empty;

        public string Description { get; set; } = default ! ;

        public int Level { get; set; } 

        public int Capacity { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public int InstructorId { get; set; }
    }
}