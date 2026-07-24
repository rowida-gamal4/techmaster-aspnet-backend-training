using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.Entities
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public int EnrollmentId { get; set; }

        public Enrollment Enrollment {get;set;} = default! ;

        public decimal Amount { get; set; }
        public string PaymentMethod {get;set;} = default! ;
        public DateTime PaymentDate { get; set; }

        public PaymentStatus PaymentStatus {get;set;} 

        public int ReferenceNumber {get;set;}
        public string? Note {get;set;}

    }
}