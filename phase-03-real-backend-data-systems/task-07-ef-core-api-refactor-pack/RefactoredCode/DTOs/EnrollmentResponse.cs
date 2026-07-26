namespace RefactoredCode.DTOs
{
    public class EnrollmentResponse
    {
        public int EnrollmentId { get; set; }

        public string StudentName { get; set; } = default!;

        public string TrackTitle { get; set; } = default!;

        public DateTime EnrollmentDate { get; set; }

        public EnrollmentStatus Status { get; set; }

        public int ProgressPercentage { get; set; }

        public int? FinalResult { get; set; }

        public string PaymentStatus { get; set; } = default!;
    }
}