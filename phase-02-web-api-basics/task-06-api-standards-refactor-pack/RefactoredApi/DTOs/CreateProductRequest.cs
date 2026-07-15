using System.ComponentModel.DataAnnotations;

namespace RefactoredApi.DTOs
{
    public class CreateProductRequest
    {
        [Required]
        public string Name {get;set;} = default!;

        [Range(0.01, double.MaxValue)]
        public decimal Price {get;set;}

        [Range(0, 5000)]
        public int Stock {get;set;}

    }
}