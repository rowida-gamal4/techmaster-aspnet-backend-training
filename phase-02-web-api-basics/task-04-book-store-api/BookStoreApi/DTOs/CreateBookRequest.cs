using System.ComponentModel.DataAnnotations;

namespace  BookStoreApi.DTOs
{
    public class CreateBookRequest
    {
        [Required]
        public string Title {get;set;} = default ! ;
        [Required]
        public string ISBN {get;set;} = default ! ;
        public int PublishedYear {get;set;}  

        [Range(0.01, double.MaxValue)]
        public decimal Price {get;set;}

        [Range(0, int.MaxValue)]
        public int StockQuantity {get;set;}

        [Required]
        public int AuthorId {get;set;}

        [Required]
        public int CategoryId {get;set;}
    }
}