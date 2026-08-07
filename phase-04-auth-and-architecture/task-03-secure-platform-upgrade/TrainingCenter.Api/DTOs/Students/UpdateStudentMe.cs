using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.DTOs
{
    public class UpdateStudentMe
    {
        [Required]
        public string FullName { get; set; } = default!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;

        public string? PhoneNumber { get; set; }
    }
}