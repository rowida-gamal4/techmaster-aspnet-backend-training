namespace BookStoreApi.Models
{
    public class Author
    {
        public int AuthorId {get;set;}
        public string FullName {get;set;} = default ! ;
        public string Country {get;set;} = default ! ;
        public DateTime? BirthDate {get;set;}
        public DateTime CreatedAt {get;set;}= DateTime.Now ;
    }
}