using RefactoredApi.DTOs;

namespace RefactoredApi.Services
{
    public interface IProductService
    {
        public ProductResponse CreateProduct(CreateProductRequest productRequest);

        public List<ProductResponse> GetAllProducts();

        public ProductResponse? GetProductById(int id);

       
    }
}