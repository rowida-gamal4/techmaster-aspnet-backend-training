namespace TrainingCenter.DTOs
{
    public class RevenueByTrackResponse
    {
        public int TrackId { get; set; }

        public string TrackName { get; set; } = string.Empty;

        public decimal Revenue { get; set; }
    }
}