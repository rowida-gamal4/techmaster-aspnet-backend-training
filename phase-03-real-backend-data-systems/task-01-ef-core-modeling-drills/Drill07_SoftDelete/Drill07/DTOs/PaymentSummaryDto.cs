using Drill07.Entities;

namespace Drill07.DTOs
{
    public class PaymentSummaryDto
    {
        public int EnrollmentId { get; set; }

        public decimal TotalRequired { get; set; }

        public decimal TotalPaid { get; set; }

        public decimal RemainingAmount { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
    }
}