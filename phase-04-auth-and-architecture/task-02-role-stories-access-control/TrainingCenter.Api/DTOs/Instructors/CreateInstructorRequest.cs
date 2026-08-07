using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.DTOs
{
    public class CreateInstructorRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Specialization { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Bio { get; set; }

        public bool IsActive { get; set; } = true;
        public string Password { get; set; } = default!;
    }
}