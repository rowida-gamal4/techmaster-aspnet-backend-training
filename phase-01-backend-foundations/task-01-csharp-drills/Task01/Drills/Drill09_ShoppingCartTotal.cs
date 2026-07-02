namespace Task01.Drills
{
    public class Drill09_ShoppingCartTotal
    {


        public void Run()
        {
            Console.Clear();
            Console.WriteLine("----------Shopping Cart Total-----------");

            bool isParsed;
            int items;
            do
            {
                Console.WriteLine("How Many Items ? :");
                isParsed = int.TryParse(Console.ReadLine(), out items);

                if (!isParsed)
                    Console.WriteLine("Please Enter a Valid Number");
                else if (items <= 0)
                    Console.WriteLine("The items Must be > 0");
            } while (!isParsed || items <= 0);

            decimal price;
            int quantity;
            decimal total = 0;
            decimal subtotal = 0;
            for (int i = 0; i < items; i++)
            {
                do
                {
                    Console.Write($"Enter Item {i + 1} Price : ");

                    isParsed = decimal.TryParse(Console.ReadLine(), out price);

                    if (!isParsed || price <= 0)
                    {
                        Console.WriteLine("Invalid price (must be > 0).");
                    }

                } while (!isParsed || price <= 0);
                do
                {
                    Console.Write($"Enter Item {i + 1} Quantity : ");

                    isParsed = int.TryParse(Console.ReadLine(), out quantity);

                    if (!isParsed || quantity <= 0)
                    {
                        Console.WriteLine("Invalid Quantity (must be > 0).");
                    }

                } while (!isParsed || quantity <= 0);

                subtotal = price * quantity;
                total += subtotal;
            }


            if (total > 1000)
            {
                decimal discount = total * 0.10m;
                decimal final = total - discount;
                Console.WriteLine($"Total :{total:F2}, Discount : {discount:F2}, Final : {final:F2}");
            }
            else
            {
                Console.WriteLine($"Total :{total:F2}, No discount , Final : {total:F2}");
            }

            Console.WriteLine("--------------------------------------------------------------------");

        }
    }
}