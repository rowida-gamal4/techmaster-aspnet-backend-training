namespace TrainingCenter.DTOs
{
    public class TrackProgressResponse
    {
        public int TrackId { get; set; }
        public string TrackTitle { get; set; } = default!;
        public int TotalStudents { get; set; }
        public decimal AverageProgress { get; set; }
    }
}