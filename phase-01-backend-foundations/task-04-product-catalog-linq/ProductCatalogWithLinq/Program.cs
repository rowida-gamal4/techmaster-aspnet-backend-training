using ProductCatalogWithLinq.Services;
using ProductCatalogWithLinq.UI;

namespace ProductCatalogWithLinq
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductQueryservice service = new ProductQueryservice();

            ConsoleMenu consoleMenu = new ConsoleMenu();
            
            consoleMenu.Run(service);
        }
    }
}