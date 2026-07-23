using System.ComponentModel.DataAnnotations;

namespace Drill07.Entities
{
    public class StudentProfile
    {
        [Key]
        public int NationalId {get;set;}
        public string Address {get;set;} = default ! ;
        public string EmergencyPhone {get;set;} = default ! ;
        public DateTime DateOfBirth {get;set;}
       public Student Student {get;set;} = default! ;
       public int StudentId { get; set; }

    }
}