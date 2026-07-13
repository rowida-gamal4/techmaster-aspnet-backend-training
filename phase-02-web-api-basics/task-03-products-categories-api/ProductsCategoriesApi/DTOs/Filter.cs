namespace ProductsCategoriesApi.DTOs
{
    public class Filter
    {
        public string? Name {get;set;} 
        public int? CategoryId {get;set;}
        public int? MinPrice {get;set;}
        public int? MaxPrice {get;set;}
        public int? LowStock {get;set;}

        public bool? IsAvailable {get;set;}

    }
}