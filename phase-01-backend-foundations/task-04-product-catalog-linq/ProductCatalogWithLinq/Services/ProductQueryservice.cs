using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;
using ProductCatalogWithLinq.DTO;
using ProductCatalogWithLinq.Models;

namespace ProductCatalogWithLinq.Services
{
    public class ProductQueryservice
    {
        public List<Product> products = new()
        {
    new() { ProductId = 1, Name = "Laptop Pro 14", Category = "Electronics", Price = 45000, StockQuantity = 5, CreatedAt = new DateTime(2026, 1, 10), IsAvailable = true, SupplierName = "TechSupplier" },
    new() { ProductId = 2, Name = "Wireless Mouse", Category = "Electronics", Price = 650, StockQuantity = 50, CreatedAt = new DateTime(2026, 2, 1), IsAvailable = true, SupplierName = "TechSupplier" },
    new() { ProductId = 3, Name = "Office Chair", Category = "Furniture", Price = 3500, StockQuantity = 10, CreatedAt = new DateTime(2025, 12, 15), IsAvailable = true, SupplierName = "HomeSupplier" },
    new() { ProductId = 4, Name = "Standing Desk", Category = "Furniture", Price = 8000, StockQuantity = 3, CreatedAt = new DateTime(2026, 3, 5), IsAvailable = true, SupplierName = "HomeSupplier" },
    new() { ProductId = 5, Name = "Notebook Pack", Category = "Stationery", Price = 120, StockQuantity = 100, CreatedAt = new DateTime(2026, 1, 20), IsAvailable = true, SupplierName = "PaperSupplier" },
    new() { ProductId = 6, Name = "Pen Set", Category = "Stationery", Price = 75, StockQuantity = 200, CreatedAt = new DateTime(2026, 1, 25), IsAvailable = true, SupplierName = "PaperSupplier" },
    new() { ProductId = 7, Name = "Gaming Keyboard", Category = "Electronics", Price = 2500, StockQuantity = 7, CreatedAt = new DateTime(2026, 2, 12), IsAvailable = true, SupplierName = "TechSupplier" },
    new() { ProductId = 8, Name = "Monitor 27 inch", Category = "Electronics", Price = 9000, StockQuantity = 4, CreatedAt = new DateTime(2026, 2, 20), IsAvailable = true, SupplierName = "TechSupplier" },
    new() { ProductId = 9, Name = "Desk Lamp", Category = "Furniture", Price = 650, StockQuantity = 0, CreatedAt = new DateTime(2025, 11, 1), IsAvailable = false, SupplierName = "HomeSupplier" },
    new() { ProductId = 10, Name = "Backpack", Category = "Accessories", Price = 1200, StockQuantity = 15, CreatedAt = new DateTime(2026, 3, 10), IsAvailable = true, SupplierName = "BagSupplier" },
    new() { ProductId = 11, Name = "USB-C Hub", Category = "Electronics", Price = 1250, StockQuantity = 12, CreatedAt = new DateTime(2026, 4, 1), IsAvailable = true, SupplierName = "TechSupplier" },
    new() { ProductId = 12, Name = "Whiteboard Markers", Category = "Stationery", Price = 95, StockQuantity = 80, CreatedAt = new DateTime(2026, 2, 15), IsAvailable = true, SupplierName = "PaperSupplier" },
    new() { ProductId = 13, Name = "Ergonomic Mouse Pad", Category = "Accessories", Price = 350, StockQuantity = 25, CreatedAt = new DateTime(2026, 5, 1), IsAvailable = true, SupplierName = "BagSupplier" },
    new() { ProductId = 14, Name = "Meeting Table", Category = "Furniture", Price = 12500, StockQuantity = 2, CreatedAt = new DateTime(2025, 10, 20), IsAvailable = true, SupplierName = "HomeSupplier" },
    new() { ProductId = 15, Name = "HD Webcam", Category = "Electronics", Price = 1800, StockQuantity = 6, CreatedAt = new DateTime(2026, 4, 17), IsAvailable = true, SupplierName = "TechSupplier" },
    new() { ProductId = 16, Name = "Printer Paper Box", Category = "Stationery", Price = 450, StockQuantity = 30, CreatedAt = new DateTime(2026, 2, 28), IsAvailable = true, SupplierName = "PaperSupplier" },
    new() { ProductId = 17, Name = "Laptop Stand", Category = "Accessories", Price = 950, StockQuantity = 9, CreatedAt = new DateTime(2026, 3, 30), IsAvailable = true, SupplierName = "BagSupplier" },
    new() { ProductId = 18, Name = "Network Cable 5m", Category = "Electronics", Price = 150, StockQuantity = 60, CreatedAt = new DateTime(2026, 1, 5), IsAvailable = true, SupplierName = "TechSupplier" },
    new() { ProductId = 19, Name = "Storage Cabinet", Category = "Furniture", Price = 6000, StockQuantity = 1, CreatedAt = new DateTime(2025, 9, 10), IsAvailable = true, SupplierName = "HomeSupplier" },
    new() { ProductId = 20, Name = "Sticky Notes", Category = "Stationery", Price = 60, StockQuantity = 0, CreatedAt = new DateTime(2026, 5, 10), IsAvailable = false, SupplierName = "PaperSupplier" },
    new() { ProductId = 21, Name = "Noise Cancelling Headset", Category = "Electronics", Price = 5200, StockQuantity = 4, CreatedAt = new DateTime(2026, 3, 22), IsAvailable = true, SupplierName = "TechSupplier" },
    new() { ProductId = 22, Name = "Desk Organizer", Category = "Accessories", Price = 300, StockQuantity = 40, CreatedAt = new DateTime(2026, 6, 1), IsAvailable = true, SupplierName = "BagSupplier" },
    new() { ProductId = 23, Name = "Projector", Category = "Electronics", Price = 22000, StockQuantity = 2, CreatedAt = new DateTime(2026, 4, 28), IsAvailable = true, SupplierName = "TechSupplier" },
    new() { ProductId = 24, Name = "Office Sofa", Category = "Furniture", Price = 15500, StockQuantity = 1, CreatedAt = new DateTime(2025, 8, 18), IsAvailable = true, SupplierName = "HomeSupplier" },
    new() { ProductId = 25, Name = "Calculator", Category = "Stationery", Price = 250, StockQuantity = 35, CreatedAt = new DateTime(2026, 1, 12), IsAvailable = true, SupplierName = "PaperSupplier" }
};


        public void PrintProduct(IEnumerable<Product> products)
        {
            if (products.Any())
            {
                System.Console.WriteLine("-----------------------------------------------------");
                foreach (var product in products)
                {
                    
                    Console.WriteLine($"Product Id: {product.ProductId}");
                    Console.WriteLine($"Product Name: {product.Name}");
                    Console.WriteLine($"Category: {product.Category}");
                    Console.WriteLine($"Price: {product.Price:C}");
                    Console.WriteLine($"Stock: {product.StockQuantity}");
                    Console.WriteLine($"Created At: {product.CreatedAt:yyyy-MM-dd}");
                    Console.WriteLine($"Available: {(product.IsAvailable ? "true" : "false")}");
                    Console.WriteLine($"Supplier:{product.SupplierName}");
                    Console.WriteLine("------------------");
                }

            }
            else
            {
                Console.WriteLine("No products found.");
            }


        }
        public void GetAllProducts()
        {
            Console.Clear();
            Console.WriteLine("=========== View All Products =====================");
            var availableProducts = products.Where(p => p.IsAvailable && p.StockQuantity > 0).ToList();
            PrintProduct(availableProducts);
        }

        public void FilterByCategory()
        {
            Console.Clear();
            Console.WriteLine("=========== Filter by Category =====================");
            string? category;
            do
            {
                Console.Write("Enter category name:");
                category = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(category));
            var productsByCategory = products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            PrintProduct(productsByCategory);

        }

        public void FilterByPriceRange()
        {
            Console.Clear();
            Console.WriteLine("=========== Filter by Price Range =====================");
            bool isValid;
            decimal min, max;
            do
            {
                Console.Write("Enter minimum price: ");
                isValid = decimal.TryParse(Console.ReadLine(), out min);

                if (!isValid || min < 0)
                    Console.WriteLine("Please enter a valid minimum price.");
            }
            while (!isValid || min < 0);
            do
            {
                Console.Write("Enter maximum price: ");
                isValid = decimal.TryParse(Console.ReadLine(), out max);

                if (!isValid || max < min)
                    Console.WriteLine("Maximum price can not be lower than minimum price.");
            }
            while (!isValid || max < min);
            var filterdProducts = products.Where(p => p.Price >= min && p.Price <= max);

            PrintProduct(filterdProducts);

        }

        public void SearchByProductName()
        {
            Console.Clear();
            Console.WriteLine("=========== Search by Name =====================");
            string? name;
            do
            {
                Console.Write("Enter product name:");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Empty keyword is invalid");
                }
            } while (string.IsNullOrWhiteSpace(name));
            var filterdProducts = products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

            PrintProduct(filterdProducts);
        }

        public void SortByPriceAscending()
        {
            Console.Clear();
            Console.WriteLine("=========== Sort by Price Ascending =====================");
            var filterdProducts = products.OrderBy(p => p.Price).ToList();

            PrintProduct(filterdProducts);

        }

        public void SortByPriceDescending()
        {
            Console.Clear();
            Console.WriteLine("=========== Sort by Price Descending =====================");
            var filterdProducts = products.OrderByDescending(p => p.Price).ToList();
            PrintProduct(filterdProducts);

        }

        public void GroupProductsByCategory()
        {
            Console.Clear();
            Console.WriteLine("=========== Group Products by Category =====================");
            var groupedProducts = products.GroupBy(p => p.Category);
            foreach (var group in groupedProducts)
            {
                Console.WriteLine();
                Console.WriteLine($"Category: {group.Key}");
                Console.WriteLine("--------------------------------");

                PrintProduct(group);
            }

        }

        public void CountProductsPerCategory()
        {
            Console.Clear();
            Console.WriteLine("=========== Count Products per Category =====================");
            var groupedProducts = products.GroupBy(p => p.Category);
            foreach (var group in groupedProducts)
            {
                Console.WriteLine($"Category: {group.Key} - Count: {group.Count()}");
            }
        }

        public void CalculateTotalStockValue()
        {
            Console.Clear();
            Console.WriteLine("=========== Calculate Total Stock Value =====================");
            var TotalValue = products.Sum(p => p.Price * p.StockQuantity);
            System.Console.WriteLine($"Total Stock Value: {TotalValue:C}");
        }

        public void StockValuePerCategory()
        {
            Console.Clear();
            Console.WriteLine("=========== Stock Value per Category =====================");
            var groupedProducts = products.GroupBy(p => p.Category).Select(g => new
            {
                Category = g.Key,
                TotalValue = g.Sum(p => p.Price * p.StockQuantity)

            });
            foreach (var group in groupedProducts)
            {
                Console.WriteLine($"Category: {group.Category} - Stock Value: {group.TotalValue}");
            }
        }

        public void TopExpensiveProducts()
        {
            Console.Clear();
            Console.WriteLine("=========== Top 5 Most Expensive Products =====================");
            var topProducts = products.OrderByDescending(p => p.Price).Take(5);
            PrintProduct(topProducts);
        }

        public void LowStockProducts()
        {
            Console.Clear();
            Console.WriteLine("=========== Low Stock Products =====================");
            var lowStockProducts = products.Where(p => p.StockQuantity <= 5).OrderBy(p => p.StockQuantity);
            if (lowStockProducts.Any())
            {
                foreach (var item in lowStockProducts)
                {
                    Console.WriteLine($"Product Name: {item.Name} - Quantity: {item.StockQuantity}");
                }
            }
        }

        public void OutOfStockProducts()
        {
            Console.Clear();
            Console.WriteLine("=========== Out of Stock Products =====================");
            var outofStocks = products.Where(p => p.StockQuantity == 0 || !p.IsAvailable);
            PrintProduct(outofStocks);
        }

        public void ProductSummaryDTOProjection()
        {
            Console.Clear();
            Console.WriteLine("=========== Product Summary  =====================");
            var summaries = products.Select(p => new ProductSummary
            {
                Name = p.Name,
                Category = p.Category,
                Price = p.Price,
                StockStatus = p.StockQuantity > 0 ? "In Stock" : "Out of Stock"
            });

            foreach (var item in summaries)
            {
                Console.WriteLine($"Name        : {item.Name}");
                Console.WriteLine($"Category    : {item.Category}");
                Console.WriteLine($"Price       : {item.Price:C}");
                Console.WriteLine($"Stock Status: {item.StockStatus}");
                Console.WriteLine("--------------------------------");
            }
        }

        public void SupplierReport()
        {
            Console.Clear();
            Console.WriteLine("=========== SupplierReport =====================");
            var groupedProducts = products.GroupBy(p => p.SupplierName).Select(g => new
            {
                Supplier = g.Key,
                TotalCount = g.Count(),
                StockValue = g.Sum(p => p.Price * p.StockQuantity),
                AveragePrice = g.Average(p => p.Price)

            });
            foreach (var group in groupedProducts)
            {
                Console.WriteLine();
                Console.WriteLine($"Supplier      :{group.Supplier}");
                Console.WriteLine($"Count         :{group.TotalCount}");
                Console.WriteLine($"Stock Value   :{group.StockValue:C}");
                Console.WriteLine($"Average Value :{group.AveragePrice}");
                Console.WriteLine("----------------");

            }
        }

        public void RecentlyAddedProducts()
        {
            Console.Clear();
            Console.WriteLine("=========== Recently Added Products =====================");
            var recentroducts = products.Where(p => p.CreatedAt >= DateTime.Today.AddDays(-60)).ToList();
            PrintProduct(recentroducts);
        }

        public void CategoryStatistics()
        {
            Console.Clear();
            Console.WriteLine("=========== Category Statistics =====================");
            var groupedProducts = products.GroupBy(p => p.Category).Select(g => new
            {
                Category = g.Key,
                TotalCount = g.Count(),
                StockValue = g.Sum(p => p.Price * p.StockQuantity),
                minPrice = g.Min(p => p.Price),
                maxPrice = g.Max(p => p.Price),
                AveragePrice = g.Average(p => p.Price)

            });
            foreach (var group in groupedProducts)
            {
                Console.WriteLine();
                Console.WriteLine($"Category        :{group.Category}");
                Console.WriteLine($"Count           :{group.TotalCount}");
                Console.WriteLine($"Average Price   :{group.AveragePrice}");
                Console.WriteLine($"Minimum Price   :{group.minPrice}");
                Console.WriteLine($"Maximun Price   :{group.maxPrice}");
                Console.WriteLine($"Stock Value     :{group.StockValue}");
                Console.WriteLine("----------------");

            }
        }

        public void ProductsAboveAvgPrice()
        {
            Console.Clear();
            Console.WriteLine("=========== Products Above Average Price =====================");
            var avg = products.Average(p => p.Price);
            var aboveAvgProducts = products.Where(p => p.Price > avg);
            Console.WriteLine($"Average Price Is: {avg:C}");
            Console.WriteLine();
            PrintProduct(aboveAvgProducts);

        }

        public void SearchAndFilterProducts()
        {
            Console.Clear();
            Console.WriteLine("=========== Search And Filter Products =====================");

            string? category;
            do
            {
                Console.Write("Enter category: ");
                category = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(category))
                    Console.WriteLine("Category is required.");
            }
            while (string.IsNullOrWhiteSpace(category));

            bool isValid;
            decimal min, max;
            do
            {
                Console.Write("Enter minimum price: ");
                isValid = decimal.TryParse(Console.ReadLine(), out min);

                if (!isValid || min < 0)
                    Console.WriteLine("Please enter a valid minimum price.");
            }
            while (!isValid || min < 0);
            do
            {
                Console.Write("Enter maximum price: ");
                isValid = decimal.TryParse(Console.ReadLine(), out max);

                if (!isValid || max < min)
                    Console.WriteLine("Maximum price can not be lower than minimum price.");
            }
            while (!isValid || max < min);

            var filtteredProducts = products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).Where(p => p.Price >= min).Where(p => p.Price <= max).Where(p => p.IsAvailable).ToList();



            PrintProduct(filtteredProducts);
        }
   
    
        public void PaginationSimulation()
        {
            Console.Clear();
            Console.WriteLine("=========== Pagination Simulation =====================");
            bool isValid;
            int pageNumber, pageSize;
            do
            {
                Console.Write("Enter Page number: ");
                isValid = int.TryParse(Console.ReadLine(), out pageNumber);

                if (!isValid || pageNumber <= 0)
                    Console.WriteLine("Page number must be > 0.");
            }
            while (!isValid || pageNumber <= 0);
            do
            {
                Console.Write("Enter page size: ");
                isValid = int.TryParse(Console.ReadLine(), out pageSize);

                if (!isValid || pageSize <= 0)
                    Console.WriteLine("Enter valid page size");
            }
            while (!isValid || pageSize <= 0);

            var returnedPages = products.Skip((pageNumber - 1) * pageSize).Take(pageSize) ;
            PrintProduct(returnedPages);
        }
    }
}