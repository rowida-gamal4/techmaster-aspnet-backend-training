namespace Drill10.DTOs
{
    public class CreateStudentDto
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}