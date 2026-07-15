namespace BookStoreApi.Models
{
    public class Category
    {
        public int CategoryId {get;set;}
        public string Name {get;set;} = default ! ;
        public string Description {get;set;} = default ! ;
        public bool IsActive {get;set;} 
    }
}