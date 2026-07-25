namespace TrainingCenter.DTOs
{
    public class TopTrackResponse
    {
        public int TrackId { get; set; }

        public string TrackTitle { get; set; } = string.Empty;

        public int ActiveEnrollmentCount { get; set; }
    }
}