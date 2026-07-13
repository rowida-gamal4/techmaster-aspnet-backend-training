using System.ComponentModel.DataAnnotations;

namespace StudentManagementApi.DTOs
{
    public class StudentResponse
    {
        public int StudentId {get;set;}

        public DateTime EnrollmentDate {get;set;} 
        
        public string FullName {get;set;} = default! ;

        public string Email {get;set;} = default!;

        public bool IsActive {get;set;}
        public string PhoneNumber {get;set;} = default!;
        
        public string TrackName {get;set;} = default!;
        public string? GitHubProfileUrl { get; set; }

        public string? LinkedInProfileUrl { get; set; }
    }
}