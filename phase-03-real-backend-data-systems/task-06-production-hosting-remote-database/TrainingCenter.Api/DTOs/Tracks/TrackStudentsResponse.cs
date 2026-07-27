namespace TrainingCenter.DTOs
{
    public class TrackStudentsResponse
    {
        public int TrackId { get; set; }

        public string TrackName { get; set; } = string.Empty;

        public List<TrackStudentItemResponse> Students { get; set; } = new();
    }
}