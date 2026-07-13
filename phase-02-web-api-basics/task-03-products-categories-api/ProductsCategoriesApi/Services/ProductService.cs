using ProductsCategoriesApi.DTOs;
using ProductsCategoriesApi.Models;
using ProductsCategoriesApi.SeededData;

namespace ProductsCategoriesApi.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> products = Seed.Products;
        private readonly List<Category> categories = Seed.Categories;

        public ProductResponse CreateProduct(CreateProductRequest productRequest)
        {
            var category = categories.FirstOrDefault(c => c.CategoryId == productRequest.CategoryId);

            if (category is null)
                return null;
            Product product = new()
            {
                ProductId = products.Count + 1,
                Name = productRequest.Name,
                CategoryId = productRequest.CategoryId,
                Price = productRequest.Price,
                StockQuantity = productRequest.StockQuantity,
                IsAvailable = productRequest.StockQuantity > 0 ? true : false,
                SupplierName = productRequest.SupplierName,
                CreatedAt = DateTime.UtcNow
            };
            products.Add(product);
            ProductResponse productResponse = new()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                CategoryId = product.CategoryId,
                CategoryName = category.Name,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                IsAvailable = product.IsAvailable,
                SupplierName = product.SupplierName,
                CreatedAt = product.CreatedAt
            };

            return productResponse;

        }

        public List<ProductResponse> GetAllProducts()
        {
            var availableProducts = products.Where(p => p.IsAvailable);

            List<ProductResponse> productResponses = new();

            foreach (var product in availableProducts)
            {
                var category = categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);

                ProductResponse productResponse = new()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    CategoryName = category?.Name ?? "UnKnown",
                    Price = product.Price,
                    StockQuantity = product.StockQuantity,
                    IsAvailable = product.IsAvailable,
                    SupplierName = product.SupplierName,
                    CreatedAt = product.CreatedAt
                };

                productResponses.Add(productResponse);
            }

            return productResponses;
        }

        public bool? DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            if (product is null)
                return null;
            products.Remove(product);
            return true;
        }



        public ProductResponse GetProductById(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            if (product is null)
                return null;

            var category = categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);
            ProductResponse productResponse = new()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                CategoryId = product.CategoryId,
                CategoryName = category?.Name ?? "UnKnown",
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                IsAvailable = product.IsAvailable,
                SupplierName = product.SupplierName,
                CreatedAt = product.CreatedAt
            };
            return productResponse;

        }

        public ProductResponse UpdateProduct(int id, UpdateProductRequest updateProduct)
        {
            var category = categories.FirstOrDefault(c => c.CategoryId == updateProduct.CategoryId);

            if (category is null)
                return null;

            var product = products.FirstOrDefault(p => p.ProductId == id);

            if (product is null)
                return null;

            product.Name = updateProduct.Name;
            product.CategoryId = updateProduct.CategoryId;
            product.Price = updateProduct.Price;
            product.StockQuantity = updateProduct.StockQuantity;
            product.SupplierName = updateProduct.SupplierName;
            product.IsAvailable = product.StockQuantity > 0;

            ProductResponse productResponse = new()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                CategoryId = product.CategoryId,
                CategoryName = category?.Name ?? "UnKnown",
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                IsAvailable = product.IsAvailable,
                SupplierName = product.SupplierName,
                CreatedAt = product.CreatedAt
            };
            return productResponse;
        }

        public ProductResponse UpdateProductStock(int id, UpdateStockRequest stockRequest)
        {

            var product = products.FirstOrDefault(p => p.ProductId == id);


            if (product is null)
                return null;

            var category = categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);

            product.StockQuantity = stockRequest.StockQuantity;
            product.IsAvailable = product.StockQuantity > 0;


            ProductResponse productResponse = new()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                CategoryId = product.CategoryId,
                CategoryName = category?.Name ?? "UnKnown",
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                IsAvailable = product.IsAvailable,
                SupplierName = product.SupplierName,
                CreatedAt = product.CreatedAt
            };

            return productResponse;
        }

        public List<ProductResponse> GetProductsWithFilterAndSearch(Filter filter)
        {

            var returnedProducts = products.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                returnedProducts = returnedProducts.Where(p => p.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));
            }

            if (filter.CategoryId != null)
            {
                returnedProducts = returnedProducts.Where(p => p.CategoryId == filter.CategoryId);
            }

            if (filter.MinPrice != null)
            {
                returnedProducts = returnedProducts.Where(p => p.Price >= filter.MinPrice);
            }

            if (filter.MaxPrice != null)
            {
                returnedProducts = returnedProducts.Where(p => p.Price <= filter.MaxPrice);
            }

            if (filter.IsAvailable != null)
            {
                returnedProducts = returnedProducts.Where(p => p.IsAvailable == filter.IsAvailable);
            }

            if (filter.LowStock != null)
            {
                returnedProducts = returnedProducts.Where(p => p.StockQuantity <= filter.LowStock);
            }

            List<ProductResponse> productResponses = new();

            foreach (var product in returnedProducts)
            {
                var category = categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);

                ProductResponse productResponse = new()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    CategoryName = category?.Name ?? "UnKnown",
                    Price = product.Price,
                    StockQuantity = product.StockQuantity,
                    IsAvailable = product.IsAvailable,
                    SupplierName = product.SupplierName,
                    CreatedAt = product.CreatedAt
                };

                productResponses.Add(productResponse);
            }

            return productResponses;


        }

        public StockReports StockReports()
        {
            var totalStock = products.Sum(p => p.Price * p.StockQuantity);

            var stockValuePerCategory = products.GroupBy(p => p.CategoryId).ToDictionary(
             g => categories.First(c => c.CategoryId == g.Key).Name,
             g => g.Sum(x => x.Price * x.StockQuantity)
            );

            var lowStock = products.Count(p => p.StockQuantity <= 5);

            var outOfStock = products.Count(p => p.StockQuantity == 0);

            var productsCountPerCategory = products.GroupBy(p => p.CategoryId).ToDictionary(
             g => categories.First(c => c.CategoryId == g.Key).Name,
             g => g.Count()
           );

            return new StockReports
            {
                TotalStockValue = totalStock,
                StockValuePerCategory = stockValuePerCategory,
                LowStockProducts = lowStock,
                OutOfStockProducts = outOfStock,
                ProductsCountPerCategory = productsCountPerCategory
            };

        }
    }
}