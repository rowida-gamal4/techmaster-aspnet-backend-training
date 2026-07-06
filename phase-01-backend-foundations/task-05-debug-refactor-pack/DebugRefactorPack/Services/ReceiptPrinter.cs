using DebugRefactorPack.Models;

namespace DebugRefactorPack.Services
{
    public class ReceiptPrinter
    {
        public void PrintReceipt(Customer customer,Order order,decimal subtotal,decimal discount,decimal tax,decimal shipping,decimal finalTotal)
        {
            Console.WriteLine();
            Console.WriteLine("=============== Order Receipt ===============");
            Console.WriteLine($"Customer : {customer.Name}");
            Console.WriteLine($"Type     : {customer.CustomerType}");
            Console.WriteLine($"Product  : {order.ProductName}");
            Console.WriteLine($"Price    : {order.Price:C}");
            Console.WriteLine($"Quantity : {order.Quantity}");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Subtotal : {subtotal:C}");
            Console.WriteLine($"Discount : {discount:C}");
            Console.WriteLine($"Tax      : {tax:C}");
            Console.WriteLine($"Shipping : {shipping:C}");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Final Total   : {finalTotal:C}");
            Console.WriteLine("=============================================");
        }
    }
}