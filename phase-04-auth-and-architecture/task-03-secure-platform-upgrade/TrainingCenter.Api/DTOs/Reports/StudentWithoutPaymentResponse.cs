namespace TrainingCenter.DTOs
{
    public class StudentWithoutPaymentResponse
    {
        public int StudentId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string TrackTitle { get; set; } = string.Empty;

        public DateTime EnrollmentDate { get; set; }

        public EnrollmentStatus Status { get; set; }
    }
}