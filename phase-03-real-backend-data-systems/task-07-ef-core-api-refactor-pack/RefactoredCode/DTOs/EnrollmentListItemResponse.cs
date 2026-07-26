namespace RefactoredCode.DTOs
{
    public class EnrollmentListItemResponse
    {
        public int EnrollmentId { get; set; }

        public string StudentName { get; set; } = default!;

        public string TrackTitle { get; set; } = default!;

        public EnrollmentStatus Status { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}