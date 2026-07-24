namespace TrainingCenter.DTOs
{
    public class CreateInstructorRequest
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Specialization { get; set; } = default!;
        public string? Bio { get; set; }
        public bool IsActive { get; set; }
    }
}