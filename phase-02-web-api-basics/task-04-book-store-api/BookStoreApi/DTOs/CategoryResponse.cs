namespace BookStoreApi.DTOs
{
    public class CategoryResponse
    {
        public int CategoryId {get;set;}
        public string Name {get;set;} = default ! ;
        public string Description {get;set;} = default ! ;
        public bool IsActive {get;set;} 
    }
}