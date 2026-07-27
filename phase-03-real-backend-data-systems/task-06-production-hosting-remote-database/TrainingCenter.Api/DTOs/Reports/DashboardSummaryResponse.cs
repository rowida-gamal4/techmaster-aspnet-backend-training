namespace TrainingCenter.DTOs
{
    public class DashboardSummaryResponse
    {
        public int TotalStudents { get; set; }

        public int TotalInstructors { get; set; }

        public int TotalTracks { get; set; }

        public int TotalEnrollments { get; set; }

        public decimal TotalRevenue { get; set; }
    }
}