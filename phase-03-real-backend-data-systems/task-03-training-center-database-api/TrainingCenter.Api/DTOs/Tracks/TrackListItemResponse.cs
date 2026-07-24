namespace TrainingCenter.DTOs
{
    public class TrackListItemResponse
    {
        public int TrackId { get; set; }
        public string Title { get; set; } = default!;
        public string Code { get; set; } = default!;
        public int Level { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string InstructorName { get; set; } = default!;
    }
}