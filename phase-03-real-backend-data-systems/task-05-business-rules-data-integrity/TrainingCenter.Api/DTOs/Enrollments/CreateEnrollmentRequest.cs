using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.DTOs
{
    public class CreateEnrollmentRequest
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int TrainingTrackId { get; set; }

        public int ProgressPercentage { get; set; }
    }
}