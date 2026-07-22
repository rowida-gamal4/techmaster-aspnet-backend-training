using System.ComponentModel.DataAnnotations;

namespace Drill04.Entities
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId {get;set;}

        public int StudentId { get; set; }
        public Student Student {get;set;} = default!;

        public int TrainingTrackId { get; set; }

        public TrainingTrack TrainingTrack {get;set;}  = default!; 

        public string Status {get;set;} = "" ;
        public DateTime EnrollmentDate {get;set;}

        public int? FinalGrade {get;set;}

    }
}