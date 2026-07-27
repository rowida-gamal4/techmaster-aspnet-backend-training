namespace TrainingCenter.DTOs
{

    public class TrackDetailsResponse
    {
        public int TrackId { get; set; }
        public string Title { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? Description { get; set; }
        public int Level { get; set; } = default!;
        public int Capacity { get; set; }

        public int EnrolledStudents { get; set; }
        public int AvailableSeats { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Status { get; set; } = default!;

        public int InstructorId {get;set;}

        public string InstructorName { get; set; } = default!;
    }
}
