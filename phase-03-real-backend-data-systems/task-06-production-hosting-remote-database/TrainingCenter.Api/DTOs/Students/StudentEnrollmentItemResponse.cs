namespace TrainingCenter.DTOs
{
    public class StudentEnrollmentItemResponse
    {
        public int EnrollmentId { get; set; }

        public int TrackId { get; set; }

        public string TrackName { get; set; } = string.Empty;

        public DateTime EnrollmentDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public int ProgressPercentage { get; set; }

        public int? FinalResult { get; set; }
    }
}