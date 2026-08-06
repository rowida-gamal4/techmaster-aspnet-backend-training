using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.DTOs.Auth
{
    public class RefreshTokenRequest
    {
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }
}