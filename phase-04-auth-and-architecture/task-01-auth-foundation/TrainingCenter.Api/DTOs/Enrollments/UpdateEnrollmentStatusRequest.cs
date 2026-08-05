using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.DTOs
{
    public class UpdateEnrollmentStatusRequest
    {
        [Required]
        [RegularExpression("Active|Completed|Cancelled")]
        public EnrollmentStatus Status { get; set; }
    }
}