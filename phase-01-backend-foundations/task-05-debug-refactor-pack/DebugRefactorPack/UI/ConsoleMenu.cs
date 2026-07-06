using DebugRefactorPack.Helper;
using DebugRefactorPack.Models;
using DebugRefactorPack.Services;

namespace DebugRefactorPack.UI
{
    public class ConsoleMenu(OrderCalculator calculator, ValidationHelper helper, ReceiptPrinter printer)
    {
        public void RunMenu()
        {
            Console.Clear();
            Console.WriteLine("=================== Debug Refactor Pack ======================");
            string? customerName;
            bool isValid;
            do
            {
                Console.Write("Enter Customer Name: ");
                customerName = Console.ReadLine();
                isValid = helper.ValidateName(customerName);
                if (!isValid)
                { Console.WriteLine("Customer Name is required"); }

            } while (!isValid);

            string? productName;
            do
            {
                Console.Write("Enter Product Name: ");
                productName = Console.ReadLine();
                isValid = helper.ValidateName(productName);
                if (!isValid)
                { Console.WriteLine("Product Name is required"); }

            } while (!isValid);

            decimal price;
            do
            {
                Console.Write("Enter Price: ");
                if (!decimal.TryParse(Console.ReadLine(), out price))
                {
                    Console.WriteLine("Invalid number.");
                    continue;
                }
                isValid = helper.ValidatePrice(price);
                if (!isValid)
                { Console.WriteLine("Price must be Positive"); }

            } while (!isValid);

            int quantity;
            do
            {
                Console.Write("Enter Quantity: ");
                int.TryParse(Console.ReadLine(), out quantity);
                isValid = helper.ValidateQuantity(quantity);
                if (!isValid)
                { Console.WriteLine("Quantity must be Positive"); }

            } while (!isValid);

            string type;
            do
            {
                Console.Write("Enter Customer Type(Regular/Silver/Gold/VIP): ");
                type = Console.ReadLine();
                isValid = helper.ValidateCustomerType(type);
                if (!isValid)
                { Console.WriteLine("Please enter a valid Customer Type."); }

            } while (!isValid);

            Customer customer = new Customer()
            {
                Name = customerName,
                CustomerType = Enum.Parse<CustomerType>(type,true)
            };
            Order order = new Order()
            {
                ProductName = productName,
                Price = price,
                Quantity = quantity,
                Customer = customer
            };

            decimal total = calculator.CalculateSubtotal(price, quantity);
            decimal discount = calculator.CalculateDiscount(customer.CustomerType, total);
            decimal afterDiscount = calculator.CalculateAfterDiscount(total, discount);
            decimal tax = calculator.CalculateTax(afterDiscount);
            decimal shipping = calculator.CalculateShipping(afterDiscount);
            decimal finalTotal = calculator.CalculateFinalTotal(afterDiscount, tax, shipping);

            printer.PrintReceipt(customer, order, total, discount, tax, shipping, finalTotal);

        }

    }
}