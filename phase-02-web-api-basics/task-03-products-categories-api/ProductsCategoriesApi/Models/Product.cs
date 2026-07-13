using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsCategoriesApi.Models
{
    public class Product
    {
        public int ProductId {get;set;}

        [Required]
        public string Name {get;set;} = default!;

        public int CategoryId{get;set;}

        [Range(0.01, double.MaxValue)]
        public decimal Price {get;set;}

        [Range(0, int.MaxValue)]
        public int StockQuantity {get;set;}
        public bool IsAvailable {get;set;}

        [Required]
        public string SupplierName {get;set;}= default!;
        public DateTime CreatedAt {get;set;}= DateTime.Now ;
    }
}