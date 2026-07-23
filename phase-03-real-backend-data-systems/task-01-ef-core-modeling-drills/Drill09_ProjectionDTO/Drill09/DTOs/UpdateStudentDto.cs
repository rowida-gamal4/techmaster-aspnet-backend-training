namespace Drill09.DTOs
{
    public class UpdateStudentDto
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}