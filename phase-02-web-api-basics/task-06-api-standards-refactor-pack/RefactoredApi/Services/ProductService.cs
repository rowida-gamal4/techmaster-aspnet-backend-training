using RefactoredApi.DTOs;
using RefactoredApi.Models;

namespace RefactoredApi.Services
{
    public class ProductService : IProductService
    {
        private static readonly List<Product> products = new List<Product>();
        public ProductResponse CreateProduct(CreateProductRequest productRequest)
        {
            Product product = new()
            {
                Id = products.Count + 1,
                Name = productRequest.Name,
                Price = productRequest.Price,
                Stock = productRequest.Stock,
            };
            products.Add(product);
            ProductResponse productResponse = new()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
            };

            return productResponse;

        }

        public List<ProductResponse> GetAllProducts()
        {

            List<ProductResponse> productResponses = new();

            foreach (var product in products)
            {
                ProductResponse productResponse = new()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock,
                };
                productResponses.Add(productResponse);
            }

            return productResponses;
        }

        public ProductResponse? GetProductById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product is null)
                return null;

            ProductResponse productResponse = new()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock,
                };
            return productResponse;
        } 
    }
}