namespace RefactoredCode.DTOs
{
    public class PaymentResponse
    {
        public int PaymentId { get; set; }

        public int EnrollmentId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string Status { get; set; } = default!;
    }
}