namespace BookStoreApi.DTOs
{
    public class ReportsSummary
    {
        public int TotalBooks {get;set;}

        public int AvailableBooks {get;set;}

        public int OutOfStocksBooks {get;set;}

        public decimal TotalInventoryValue { get; set; }
        public Dictionary<string,int>BooksPerCategory {get;set;} = new();

        public Dictionary<string,int>BookPerAuthor {get;set;} = new();
    }
}