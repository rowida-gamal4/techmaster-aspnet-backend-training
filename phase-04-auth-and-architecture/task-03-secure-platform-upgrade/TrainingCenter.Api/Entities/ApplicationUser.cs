namespace TrainingCenter.Entities
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default
        !;
        public Role Role { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        public DateTime? LastLoginAt {get;set;}

        public int? StudentId {get;set;}

        public int? InstructorId{get;set;}
        

    }
}