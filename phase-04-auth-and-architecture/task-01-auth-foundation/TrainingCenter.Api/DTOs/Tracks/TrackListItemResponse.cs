using TrainingCenter.Entities;

namespace TrainingCenter.DTOs
{
    public class TrackListItemResponse
    {
        public int TrackId { get; set; }
        public string Title { get; set; } = default!;
        public string Code { get; set; } = default!;
        public TrackLevel Level { get; set; } = default!;

        public decimal Price { get; set; }
        public string Status { get; set; } = default!;
        public string InstructorName { get; set; } = default!;
    }
}