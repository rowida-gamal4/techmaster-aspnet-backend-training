using System.ComponentModel.DataAnnotations;

namespace  RefactoredCode.DTOs
{
    public class CreateEnrollmentRequest
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int TrainingTrackId { get; set; }

        public int ProgressPercentage { get; set; } = 0;
    }
}