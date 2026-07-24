namespace TrainingCenter.DTOs
{
    public class EnrollmentDetailsResponse
    {
        public int EnrollmentId { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public string TrackName { get; set; } = string.Empty;

        public DateTime EnrollmentDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public string PaymentStatus {get;set;} = string.Empty ;

        public int ProgressPercentage { get; set; }

        public int? FinalResult { get; set; }
    }
}