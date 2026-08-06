using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.DTOs
{
    public class CreatePaymentRequest
    {
        [Range(1, int.MaxValue)]
        public int EnrollmentId { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; } = string.Empty;

        [Required]
        [RegularExpression("Pending|PartiallyPaid|Paid|Failed|Refunded")]
        public string PaymentStatus { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int ReferenceNumber { get; set; }

        [StringLength(500)]
        public string? Note { get; set; }
    }
}