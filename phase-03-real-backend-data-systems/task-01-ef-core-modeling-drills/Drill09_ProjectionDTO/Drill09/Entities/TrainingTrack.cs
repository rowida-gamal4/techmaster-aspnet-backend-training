using System.ComponentModel.DataAnnotations;

namespace Drill09.Entities
{
    public class TrainingTrack
  {
        [Key]
        public int TrackId {get;set;}
        public string TrackName {get;set;} = default ! ;

        public Instructor Instructor {get;set;} = default ! ;
        public int InstructorId  {get;set;}

        public ICollection<Enrollment> Enrollments {get;set;} = new List<Enrollment>() ;

        public DateTime CreatedAt {get;set;}
        public DateTime? UpdatedAt {get;set;}
    
    }
}