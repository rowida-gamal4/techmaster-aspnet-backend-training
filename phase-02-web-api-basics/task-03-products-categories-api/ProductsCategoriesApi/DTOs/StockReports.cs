namespace ProductsCategoriesApi.DTOs
{
    public class StockReports
    {
        public decimal TotalStockValue {get;set;}
        public Dictionary<string,decimal>StockValuePerCategory {get;set;} = new();

        public int LowStockProducts {get;set;}
        public int OutOfStockProducts {get;set;}

        public Dictionary<string,int>ProductsCountPerCategory {get;set;} = new();
    }
}