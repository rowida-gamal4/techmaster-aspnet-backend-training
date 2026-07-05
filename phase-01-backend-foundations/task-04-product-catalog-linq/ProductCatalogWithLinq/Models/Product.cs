namespace ProductCatalogWithLinq.Models
{
    public class Product
    {
        public int ProductId {get;set;}
        public string Name {get;set;} = default!;
        public string Category {get;set;}=default!;
        public decimal Price {get;set;}
        public int StockQuantity {get;set;}
        public DateTime CreatedAt {get;set;}
        public bool IsAvailable {get;set;}
        public string SupplierName {get;set;} = default!;

        public int? Rating {get;set;}

        public decimal? DiscountPercentage {get;set;} 

    }
}