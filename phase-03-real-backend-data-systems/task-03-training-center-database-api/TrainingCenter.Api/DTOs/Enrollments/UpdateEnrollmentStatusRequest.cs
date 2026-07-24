using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.DTOs
{
    public class UpdateEnrollmentStatusRequest
    {
        [Required]
        public string Status { get; set; } = string.Empty;
    }
}