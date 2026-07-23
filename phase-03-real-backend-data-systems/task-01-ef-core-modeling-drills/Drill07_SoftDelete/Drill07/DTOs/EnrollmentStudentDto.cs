namespace Drill07.DTOs
{
    public class EnrollmentStudentDto
    {
        public int StudentId { get; set; }

        public string FullName { get; set; } = default!;

        public string Status { get; set; } = default!;

        public DateTime EnrollmentDate { get; set; }

        public int? FinalGrade { get; set; }
    }
}