namespace Task01.Drills
{
    public class Drill19_SimpleTicketPriceCalculator
    {
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("----------Simple Ticket Price Calculator----------");


            const decimal basePrice = 100m;
            // Read and validate the customer's age.
            bool isParsed;
            int age;

            do
            {
                Console.Write("Enter Age: ");
                isParsed = int.TryParse(Console.ReadLine(), out age);

                if (!isParsed || age < 0)
                {
                    Console.WriteLine("Invalid age.");
                }

            } while (!isParsed || age < 0);
            // Read and validate whether the customer is a student.
            bool isStudent = false;
            string? input;
            do
            {
                Console.Write("Are you a student? (yes/no): ");
                input = Console.ReadLine()?.Trim().ToLower();
                if (input == "yes")
                {
                    isStudent = true;
                    break;
                }
                else if (input == "no")
                {
                    isStudent = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter yes or no.");
                }

            }
            while (true);
            // Determine the discount.
            decimal discount = 0m;
            if (age < 12)
            {
                discount = Math.Max(discount, 0.50m);
            }

            if (age > 60)
            {
                discount = Math.Max(discount, 0.30m);
            }

            if (isStudent)
            {
                discount = Math.Max(discount, 0.20m);
            }

            // Calculate the final ticket price.
            decimal finalPrice = basePrice * (1 - discount);

            // Display the result.
            Console.WriteLine($"Base Price : {basePrice:F2},Discount: {discount:F2},Final Price: {finalPrice:F2}");
          

            Console.WriteLine("-------------------------------------------------");


        }
    }
}
/*
Approach :
- Read and validate the customer's age.
- Read and validate whether the customer is a student.
- Calculate the best discount.
- Calculate the final ticket price.
- Display the result.
*/