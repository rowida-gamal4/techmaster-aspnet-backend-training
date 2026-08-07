using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.DTOs
{
    public class UpdatePaymentStatusRequest
    {
        [Required]
        [RegularExpression("Pending|PartiallyPaid|Paid|Failed|Refunded")]
        public string PaymentStatus { get; set; } = string.Empty;
    }
}