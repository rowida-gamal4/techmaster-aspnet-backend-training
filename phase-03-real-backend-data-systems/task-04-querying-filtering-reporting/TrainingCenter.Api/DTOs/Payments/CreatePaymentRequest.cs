using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.DTOs
{
    public class CreatePaymentRequest
    {
        [Required]
        public int EnrollmentId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;

        public string PaymentStatus { get; set; } = string.Empty;

        public int ReferenceNumber { get; set; } 

        public string? Note { get; set; }
    }
}