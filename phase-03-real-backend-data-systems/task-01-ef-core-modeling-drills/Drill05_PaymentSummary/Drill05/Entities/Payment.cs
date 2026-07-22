namespace Drill05.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public int PaymentSummaryId { get; set; }
        public PaymentSummary PaymentSummary { get; set; } = default!;
    }
}