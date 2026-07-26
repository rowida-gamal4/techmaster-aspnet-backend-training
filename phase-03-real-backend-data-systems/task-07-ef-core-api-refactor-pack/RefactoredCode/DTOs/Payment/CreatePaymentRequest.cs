using System.ComponentModel.DataAnnotations;

namespace RefactoredCode.DTOs
{
    public class CreatePaymentRequest
    {
        [Required]
        public int EnrollmentId { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; } = default!;

        [Required]
        public string PaymentStatus { get; set; } = default!;

        public int ReferenceNumber { get; set; }

        public string? Note { get; set; }
    }
}
