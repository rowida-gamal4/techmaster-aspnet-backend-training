using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.DTOs
{
    public class UpdateStudentRequest
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public bool IsActive { get; set; }
    }
}