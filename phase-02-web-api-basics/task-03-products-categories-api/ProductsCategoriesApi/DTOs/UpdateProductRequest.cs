
using System.ComponentModel.DataAnnotations;

namespace ProductsCategoriesApi.DTOs
{
    public class UpdateProductRequest
    {

        [Required]
        public string Name {get;set;} = default!;

        [Required]
        public int CategoryId{get;set;} 

        [Range(0.01, double.MaxValue)]
        public decimal Price {get;set;}

        [Range(0, int.MaxValue)]
        public int StockQuantity {get;set;}

        [Required]
        public string SupplierName {get;set;}= default!;
    }
}