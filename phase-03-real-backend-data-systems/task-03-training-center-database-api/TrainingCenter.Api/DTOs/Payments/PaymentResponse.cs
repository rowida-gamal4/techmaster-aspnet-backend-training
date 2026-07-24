namespace TrainingCenter.DTOs
{
    public class PaymentResponse
    {
        public int PaymentId { get; set; }

        public int EnrollmentId { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;

        public DateTime PaymentDate { get; set; }

        public string PaymentStatus { get; set; } = string.Empty;

        public int ReferenceNumber { get; set; } 
    }
}