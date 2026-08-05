using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.DTOs
{
    public class CreateEnrollmentRequest
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int TrainingTrackId { get; set; }

        [Required]
        [RegularExpression("Active|Completed|Cancelled")]
        public string Status { get; set; } = "Active";

        [Range(0, 100)]
        public int ProgressPercentage { get; set; }
    }
}