using System.ComponentModel.DataAnnotations.Schema;

namespace Drill02.Entities
{
    public class Student
    {
        public int Id {get;set;}
        public string FullName {get;set;} = default ! ;
        public string Email {get;set;} = default ! ;
        public DateTime CreatedAt {get;set;}
        public bool IsActive {get;set;}

        public StudentProfile? StudentProfile{get;set;} 

    }
}