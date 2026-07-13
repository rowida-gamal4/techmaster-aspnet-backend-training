using System.ComponentModel.DataAnnotations;

namespace StudentManagementApi.Models
{
    public class Student
    {
        public int StudentId {get;set;}

        [Required]
        public string FullName {get;set;} = default! ;

        [EmailAddress]
        [Required]
        public string Email {get;set;} = default!;

        [Required]
        public string PhoneNumber {get;set;} = default!;
        
        [Required]
        public string TrackName {get;set;} = default!;
        public DateTime EnrollmentDate {get;set;} = DateTime.Now ;
        public bool IsActive {get;set;}
        public string? GitHubProfileUrl {get;set;} 
        public string? LinkedInProfileUrl {get;set;} 
    }
}