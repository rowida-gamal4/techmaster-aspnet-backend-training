namespace TrainingCenter.DTOs
{
    public class StudentEnrollmentHistoryResponse
    {
        public int StudentId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public List<StudentEnrollmentItemResponse> Enrollments { get; set; } = new();
    }
}