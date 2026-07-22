namespace Drill04.DTOs
{
    public class TrackWithStudentsDto
    {
        public int TrackId { get; set; }

        public string TrackName { get; set; } = default!;

        public List<EnrollmentStudentDto> Students { get; set; } = [];
    }
}