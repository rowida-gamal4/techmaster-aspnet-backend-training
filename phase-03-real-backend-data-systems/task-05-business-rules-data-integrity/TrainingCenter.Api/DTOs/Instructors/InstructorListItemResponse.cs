namespace TrainingCenter.DTOs
{
    public class InstructorListItemResponse
    {
        public int InstructorId { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Specialization { get; set; } = default!;
    }
}