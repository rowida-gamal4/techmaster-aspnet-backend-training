namespace BookStoreApi.DTOs
{
    public class SearchAndPagination
    {
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public bool? IsAvailable {get;set;}
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}