namespace TrainingCenter.DTOs
{
    public class StudentEnrollmentItemResponse
    {
        public int EnrollmentId { get; set; }

        public int TrackId { get; set; }

        public string TrackTitle { get; set; } = string.Empty;

        public DateTime EnrollmentDate { get; set; }

        public EnrollmentStatus Status { get; set; } 

        public int ProgressPercentage { get; set; }

        public int? FinalResult { get; set; }
    }
}