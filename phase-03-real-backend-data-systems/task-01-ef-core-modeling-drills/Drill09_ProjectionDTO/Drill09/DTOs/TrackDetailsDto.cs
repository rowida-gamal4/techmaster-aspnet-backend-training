namespace Drill09.DTOs
{
    public class TrackDetailsDto
    {
        public int TrackId { get; set; }
        public string TrackName { get; set; } = default!;
        public string InstructorName { get; set; } = default!;
    }
}