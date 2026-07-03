using System.ComponentModel.DataAnnotations;

namespace BankAccountSystem.Models
{
    public class Customer
    {
        public int CustomerId {get; set;}

        [Required]
        public string FullName {get;set;} = default! ;

        [Required]
        public string Email {get;set;} = default! ;

        [Required]
        public string PhoneNumber {get;set;} = default ! ;

        public DateTime CreatedAt {get;set;} = DateTime.Now ;

    }
}