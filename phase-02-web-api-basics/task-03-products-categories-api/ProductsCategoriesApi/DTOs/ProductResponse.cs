namespace ProductsCategoriesApi.DTOs
{
    public class ProductResponse
    {
        public int ProductId {get;set;}
   
        public string Name {get;set;} = default!;
        public int CategoryId{get;set;}

        public string CategoryName {get;set;} = default!;
  
        public decimal Price {get;set;}

        public int StockQuantity {get;set;}
        public bool IsAvailable {get;set;}
        public string SupplierName {get;set;}= default!;
        public DateTime CreatedAt {get;set;}
    }
}