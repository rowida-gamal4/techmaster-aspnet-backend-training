using Drill06.Entities;

namespace Drill06.DTOs
{
    public class StudentWithEnrollmentsDto
    {
        public int Id { get; set; }

        public string FullName { get; set; } = default!;

        public List<EnrollmentTrackDto> Tracks { get; set; } = [];
    }
}