namespace TrainingCenter.DTOs
{
    public class TrackStudentItemResponse
    {
        public int StudentId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public DateTime EnrollmentDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public int ProgressPercentage { get; set; }

        public int? FinalResult { get; set; }
    }
}