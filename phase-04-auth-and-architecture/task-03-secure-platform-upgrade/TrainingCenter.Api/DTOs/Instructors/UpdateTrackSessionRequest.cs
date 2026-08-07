namespace TrainingCenter.DTOs
{
    public class UpdateTrackSessionRequest
    {
        public DateTime SessionDate { get; set; }

        public string Title { get; set; } = default!;

        public string? Description { get; set; }

        public string? MeetingLink { get; set; }

        public bool IsCompleted { get; set; }
    }
}