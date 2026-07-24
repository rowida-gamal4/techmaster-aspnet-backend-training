using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.DTOs
{
    public class UpdatePaymentStatusRequest
    {
        [Required]
        public string PaymentStatus { get; set; } = string.Empty;
    }
}