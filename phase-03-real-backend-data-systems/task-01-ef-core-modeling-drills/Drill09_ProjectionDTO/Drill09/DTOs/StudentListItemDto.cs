namespace Drill09.DTOs
{
    public class StudentListItemDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}