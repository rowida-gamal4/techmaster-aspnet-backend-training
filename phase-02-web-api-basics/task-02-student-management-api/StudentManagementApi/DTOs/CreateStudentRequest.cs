using System.ComponentModel.DataAnnotations;

namespace StudentManagementApi.DTOs
{
    public class CreateStudentRequest
    {
        [Required]
        public string FullName {get;set;} = default! ;

        [EmailAddress]
        [Required]
        public string Email {get;set;} = default!;

        [Required]
        public string PhoneNumber {get;set;} = default!;
        
        [Required]
        public string TrackName {get;set;} = default!;

        public string? GitHubProfileUrl { get; set; }

        public string? LinkedInProfileUrl { get; set; }
    }
}