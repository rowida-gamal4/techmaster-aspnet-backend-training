namespace TrainingCenter.DTOs
{
    public class InstructorDetailsResponse
    {
        public int InstructorId { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Specialization { get; set; } = default!;
        public string? Bio { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}