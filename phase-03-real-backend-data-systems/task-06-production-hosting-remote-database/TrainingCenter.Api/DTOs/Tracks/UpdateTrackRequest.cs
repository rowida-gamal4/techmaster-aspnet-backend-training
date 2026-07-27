namespace TrainingCenter.DTOs
{
    public class UpdateTrackRequest
    {
        public string Title { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string Description { get; set; } = default ! ;
        public int Level { get; set; }
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = default!;
        public int InstructorId { get; set; }
    }
}