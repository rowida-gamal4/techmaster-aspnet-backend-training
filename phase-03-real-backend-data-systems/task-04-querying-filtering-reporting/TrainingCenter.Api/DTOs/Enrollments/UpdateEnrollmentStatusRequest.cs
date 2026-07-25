using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.DTOs
{
    public class UpdateEnrollmentStatusRequest
    {
        [Required]
        public EnrollmentStatus Status { get; set; }
    }
}