using System.ComponentModel.DataAnnotations;

namespace Drill10.Entities
{
    public class EnrollmentTrackDto
    {
        public int TrackId { get; set; }
        public string TrackName {get;set;} = default!;
        public string Status {get;set;} = "" ;
        public DateTime EnrollmentDate {get;set;}
        public int? FinalGrade {get;set;}

    }
}