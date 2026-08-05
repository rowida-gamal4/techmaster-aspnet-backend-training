using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.Entities
{
    public class Instructor
    {
        [Key]
        public int InstructorId {get;set;}

        [Required]
        public string FullName {get;set;} = default ! ;

        [Required]
        public string Email {get;set;} = default ! ;

        public string Specialization {get;set;} = default ! ;

        public string? Bio {get;set;} 

        public DateTime CreatedAt {get;set;} = DateTime.UtcNow;

        public bool IsActive {get;set;}
        
        public ICollection<TrainingTrack> TrainingTracks {get;set;} = new List<TrainingTrack>(); 

     

    }
}