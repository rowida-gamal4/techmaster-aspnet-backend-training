using System.ComponentModel.DataAnnotations;
namespace TrainingCenter.Entities
{
    public class Student
    {
        [Key]
        public int StudentId {get;set;}

        [Required]
        public string FullName {get;set;} = default ! ;

        [Required]
        public string Email {get;set;} = default ! ;

        public string? PhoneNumber {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.UtcNow ;
        public DateTime? UpdatedAt {get;set;}
        public bool IsActive {get;set;}

        public bool IsDeleted {get;set;}  
        public DateTime? DeletedAt {get;set;}

        public ICollection<Enrollment> Enrollments {get;set;} = new List<Enrollment>() ; 

    }
}