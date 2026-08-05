using System.ComponentModel.DataAnnotations;
using TrainingCenter.Entities;
namespace TrainingCenter.DTOs.Auth
{
    public class RegisterRequest
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string FullName { get; set; } = default!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; } = default
        !;

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = default ! ;

        [Required]
        public Role Role { get; set; }
    }
}