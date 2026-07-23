using System.ComponentModel.DataAnnotations.Schema;

namespace Drill09.Entities
{
    public class PaymentSummary
    {
        public int Id { get; set; }
        public decimal TotalRequired { get; set; }
        public decimal TotalPaid { get; set; }

        [NotMapped]
        public decimal RemainingAmount => TotalRequired - TotalPaid;

        public PaymentStatus PaymentStatus { get; set; }

        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; } = default!;

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}