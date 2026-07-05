
using ProductCatalogWithLinq.Services;

namespace ProductCatalogWithLinq.UI
{
    public class ConsoleMenu
    {
        public void Run(ProductQueryservice service)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("====== Product Catalog LINQ System ======");
                Console.WriteLine("1. View Available Products");
                Console.WriteLine("2. Filter by Category");
                Console.WriteLine("3. Filter by Price Range");
                Console.WriteLine("4. Search by Product Name");
                Console.WriteLine("5. Sort by Price Ascending");
                Console.WriteLine("6. Sort by Price Descending");
                Console.WriteLine("7. Group Products by Category");
                Console.WriteLine("8. Count Products Per Category");
                Console.WriteLine("9. Calculate Total Stock Value");
                Console.WriteLine("10. Stock Value Per Category");
                Console.WriteLine("11. Top 5 Most Expensive Products");
                Console.WriteLine("12. Low Stock Products");
                Console.WriteLine("13. Out of Stock Products");
                Console.WriteLine("14. Product Summary Projection");
                Console.WriteLine("15. Supplier Report");
                Console.WriteLine("16. Recently Added Products");
                Console.WriteLine("17. Category Statistics");
                Console.WriteLine("18. Products Above Average Price");
                Console.WriteLine("19. Search + Filter Combined");
                Console.WriteLine("20. Pagination Simulation");
                Console.WriteLine("21. Exit");

                var choice = Console.ReadLine();
                switch (choice)
                {

                    case "1":
                        service.GetAllProducts();
                        break;
                    case "2":
                        service.FilterByCategory();
                        break;
                    case "3":
                        service.FilterByPriceRange();
                        break;
                    case "4":
                        service.SearchByProductName();
                        break;
                    case "5":
                        service.SortByPriceAscending();
                        break;
                    case "6":
                        service.SortByPriceDescending();
                        break;
                    case "7":
                        service.GroupProductsByCategory();
                        break;
                    case "8":
                        service.CountProductsPerCategory();
                        break;
                    case "9":
                        service.CalculateTotalStockValue();
                        break;
                    case "10":
                        service.StockValuePerCategory();
                        break;
                    case "11":
                        service.TopExpensiveProducts();
                        break;
                    case "12":
                        service.LowStockProducts();
                        break;
                    case "13":
                        service.OutOfStockProducts();
                        break;
                    case "14":
                        service.ProductSummaryDTOProjection();
                        break;
                    case "15":
                        service.SupplierReport();
                        break;
                    case "16":
                        service.RecentlyAddedProducts();
                        break;
                    case "17":
                        service.CategoryStatistics();
                        break;
                    case "18":
                        service.ProductsAboveAvgPrice();
                        break;
                    case "19":
                        service.SearchAndFilterProducts(); 
                        break;
                    case "20":
                        service.PaginationSimulation();
                        break;
                    case "21":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                if (!exit)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}