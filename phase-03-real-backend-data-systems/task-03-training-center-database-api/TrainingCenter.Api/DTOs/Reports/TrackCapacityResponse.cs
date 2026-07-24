namespace TrainingCenter.DTOs
{
    public class TrackCapacityResponse
    {
        public int TrackId { get; set; }

        public string TrackName { get; set; } = string.Empty;

        public int Capacity { get; set; }

        public int EnrolledStudents { get; set; }

        public int AvailableSeats { get; set; }
    }
}