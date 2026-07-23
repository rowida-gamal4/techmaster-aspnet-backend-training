using System.ComponentModel.DataAnnotations.Schema;

namespace Drill08.Entities
{
    public class Student
    {
        public int Id {get;set;}
        public string FullName {get;set;} = default ! ;
        public string Email {get;set;} = default ! ;
        public bool IsActive {get;set;}

        public StudentProfile? StudentProfile{get;set;} 
        public ICollection<Enrollment> Enrollments {get;set;} = new List<Enrollment>() ;

        public bool IsDeleted {get;set;}  
        public DateTime? DeletedAt {get;set;}

        public DateTime CreatedAt {get;set;}
        public DateTime? UpdatedAt {get;set;}

    }
}