using TrainingCenter.Entities;

namespace TrainingCenter.DTOs.Auth
{
    public class AuthResponse
    {
        public string AccessToken {get;set; } = default ! ;
        public DateTime ExpiresAt {get;set;}
        public int UserId {get;set;}

        public string FullName {get;set;} = default ! ;
        public string Email {get;set;} = default ! ;

        public Role Role {get;set;}

    }
}