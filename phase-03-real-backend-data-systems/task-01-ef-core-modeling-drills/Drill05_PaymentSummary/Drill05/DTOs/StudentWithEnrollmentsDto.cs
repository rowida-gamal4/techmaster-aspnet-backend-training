using Drill05.Entities;

namespace Drill05.DTOs
{
    public class StudentWithEnrollmentsDto
    {
        public int Id { get; set; }

        public string FullName { get; set; } = default!;

        public List<EnrollmentTrackDto> Tracks { get; set; } = [];
    }
}