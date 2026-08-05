using TrainingCenter.Entities;

namespace TrainingCenter.DTOs.Auth
{
    public class CurrentUserResponse
    {
        public int UserId { get; set; }

        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;

        public Role Role { get; set; }
        public int? LinkedStudentId { get; set; }
        public int? LinkedInstructorId { get; set; }

    }
}