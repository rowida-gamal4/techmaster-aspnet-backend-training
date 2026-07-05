namespace ProductCatalogWithLinq.DTO
{
    public class ProductSummary
    {
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string Category { get; set; } = default!;
        public string StockStatus { get; set; } = default!;
    }
}