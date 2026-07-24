using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.Entities
{
    public class TrainingTrack
  {
        [Key]
        public int TrackId {get;set;}

        [Required]
        public string Title {get;set;} = default ! ;

        public string Code {get;set;} = default ! ;

        public string Description {get;set;} = default ! ;

        public int Level {get;set;}

        public DateTime StartDate {get;set;}
        public DateTime EndDate {get;set;}

        public string Status {get;set;} = default! ;
      
        public Instructor Instructor {get;set;} = default ! ;
        public int InstructorId  {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.UtcNow ;

        public bool IsDeleted {get;set;}

        public int Capacity { get; set; }
        public ICollection<Enrollment> Enrollments {get;set;} = new List<Enrollment>() ;   
    }
}