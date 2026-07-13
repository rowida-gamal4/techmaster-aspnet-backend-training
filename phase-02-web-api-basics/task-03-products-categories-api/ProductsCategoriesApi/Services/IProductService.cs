using ProductsCategoriesApi.DTOs;

namespace ProductsCategoriesApi.Services
{
    public interface IProductService
    {
        public ProductResponse CreateProduct(CreateProductRequest productRequest);

        public List<ProductResponse> GetAllProducts();

        public ProductResponse GetProductById(int id);

        public ProductResponse UpdateProduct(int id, UpdateProductRequest updateProduct);

        public bool? DeleteProduct(int id);

        public ProductResponse UpdateProductStock(int id, UpdateStockRequest stockRequest);

        public List<ProductResponse> GetProductsWithFilterAndSearch(Filter filter);

        public StockReports StockReports();
    }
}