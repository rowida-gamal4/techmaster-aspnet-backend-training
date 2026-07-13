using ProductsCategoriesApi.Models;

namespace ProductsCategoriesApi.SeededData
{
    public static class Seed
    {
        public static List<Category> Categories = new()
   {
    new Category {CategoryId = 1,Name = "Electronics", Description = "Electronic devices and accessories",IsActive = true,CreatedAt = DateTime.UtcNow},
    new Category {CategoryId = 2,Name = "Furniture", Description = "Office and home furniture", IsActive = true,CreatedAt = DateTime.UtcNow},
    new Category {CategoryId = 3,Name = "Stationery",Description = "Office stationery supplies",IsActive = true,CreatedAt = DateTime.UtcNow},
    new Category {CategoryId = 4,Name = "Accessories",Description = "Computer and travel accessories",IsActive = true,CreatedAt = DateTime.UtcNow }
   };

        public static  List<Product> Products = new() 
   {

    new Product{ ProductId=1, Name="Laptop", CategoryId=1, Price=35000, StockQuantity=10, IsAvailable=true, SupplierName="Dell", CreatedAt=DateTime.UtcNow},
    new Product{ ProductId=2, Name="Mouse", CategoryId=1, Price=450, StockQuantity=50, IsAvailable=true, SupplierName="Logitech", CreatedAt=DateTime.UtcNow},
    new Product{ ProductId=3, Name="Keyboard", CategoryId=1, Price=900, StockQuantity=35, IsAvailable=true, SupplierName="HP", CreatedAt=DateTime.UtcNow},
    new Product{ ProductId=4, Name="Monitor", CategoryId=1, Price=5200, StockQuantity=15, IsAvailable=true, SupplierName="Samsung", CreatedAt=DateTime.UtcNow},
    new Product{ ProductId=5, Name="USB-C Hub", CategoryId=1, Price=650, StockQuantity=40, IsAvailable=true, SupplierName="Anker", CreatedAt=DateTime.UtcNow},


    new Product{ ProductId=6, Name="Office Chair", CategoryId=2, Price=2800, StockQuantity=12, IsAvailable=true, SupplierName="IKEA", CreatedAt=DateTime.UtcNow},
    new Product{ ProductId=7, Name="Office Desk", CategoryId=2, Price=4500, StockQuantity=8, IsAvailable=true, SupplierName="IKEA", CreatedAt=DateTime.UtcNow},
    new Product{ ProductId=8, Name="Desk Lamp", CategoryId=2, Price=600, StockQuantity=20, IsAvailable=true, SupplierName="Philips", CreatedAt=DateTime.UtcNow},


    new Product{ ProductId=9, Name="Notebook", CategoryId=3, Price=80, StockQuantity=100, IsAvailable=true, SupplierName="Classmate", CreatedAt=DateTime.UtcNow},
    new Product{ ProductId=10, Name="Pen Set", CategoryId=3, Price=120, StockQuantity=80, IsAvailable=true, SupplierName="Parker", CreatedAt=DateTime.UtcNow},
    new Product{ ProductId=11, Name="Marker", CategoryId=3, Price=40, StockQuantity=70, IsAvailable=true, SupplierName="Sharpie", CreatedAt=DateTime.UtcNow},
    new Product{ ProductId=12, Name="Paper Pack", CategoryId=3, Price=220, StockQuantity=60, IsAvailable=true, SupplierName="Double A", CreatedAt=DateTime.UtcNow},


    new Product{ ProductId=13, Name="Backpack", CategoryId=4, Price=950, StockQuantity=25, IsAvailable=true, SupplierName="American Tourister", CreatedAt=DateTime.UtcNow},
    new Product{ ProductId=14, Name="Mouse Pad", CategoryId=4, Price=120, StockQuantity=40, IsAvailable=true, SupplierName="Logitech", CreatedAt=DateTime.UtcNow},
    new Product{ ProductId=15, Name="Laptop Sleeve", CategoryId=4, Price=350, StockQuantity=30, IsAvailable=true, SupplierName="Lenovo", CreatedAt=DateTime.UtcNow},
  };
    }
}