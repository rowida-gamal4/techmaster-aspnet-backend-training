namespace Drill08.DTOs
{
    public class InstructorWithTracksDto
    {
        public int Id { get; set; }

        public string FullName { get; set; } = default!;

        public List<TrackDto> TrainingTracks { get; set; } = [];
    }
}