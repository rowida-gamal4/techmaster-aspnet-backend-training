using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.Entities
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId {get;set;}

        public int StudentId { get; set; }
        public Student Student {get;set;} = default!;

        public int TrainingTrackId { get; set; }

        public TrainingTrack TrainingTrack {get;set;}  = default!; 
       
        public DateTime EnrollmentDate {get;set;}

        public string Status {get;set;} = "" ;

        public int ProgressPercentage {get;set;}

        public int? FinalResult {get;set;}

        public DateTime CreatedAt {get;set;}
        public DateTime? UpdatedAt {get;set;}

        public ICollection<Payment> Payments {get;set;} = new List<Payment>();

        // public PaymentSummary? PaymentSummary { get; set; }

    }
}