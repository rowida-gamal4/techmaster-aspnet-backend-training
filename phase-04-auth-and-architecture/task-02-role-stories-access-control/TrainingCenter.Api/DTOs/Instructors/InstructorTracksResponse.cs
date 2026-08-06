using TrainingCenter.Entities;

namespace TrainingCenter.DTOs
{
    public class InstructorTracksResponse
    {
        public int TrackId { get; set; }
        public string Title { get; set; } = default!;
        public string Code { get; set; } = default!;
        public TrackLevel Level { get; set; } = default!;
        public string Status { get; set; } = default!;
    }
}