namespace Task01.Drills
{
    public class Drill14_SimpleExpenseTracker
    {

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("----------Simple Expense Tracker-----------");

            bool isParsed;
            int count;
            do
            {
                Console.WriteLine("Enter Expenses Count :");
                isParsed = int.TryParse(Console.ReadLine(), out count);

                if (!isParsed)
                    Console.WriteLine("Please Enter a Valid Count");
                else if (count <= 0)
                    Console.WriteLine("The Count Must be > 0");
            } while (!isParsed || count <= 0);

            List<Expense> expenses = new List<Expense>();

            for (int i = 0; i < count; i++)
            {
                string? name;
                int amount;

                do
                {
                    Console.Write($"Enter Expense {i + 1} Name : ");
                    name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Name Cannot be empty");
                    }

                } while (string.IsNullOrWhiteSpace(name));
                do
                {
                    Console.Write($"Enter Expense {i + 1} amount : ");

                    isParsed = int.TryParse(Console.ReadLine(), out amount);

                    if (!isParsed || amount <= 0)
                    {
                        Console.WriteLine("Invalid Amount (must be > 0).");
                    }

                } while (!isParsed || amount <= 0);
                Expense expense = new Expense(name, amount);
                expenses.Add(expense);
            }
            int total = expenses.Sum(e => e.Amount);
            double average = expenses.Average(e => e.Amount);
            int maxAmount = expenses.Max(e => e.Amount);
            List<Expense> highestExpenses = expenses.Where(e => e.Amount == maxAmount).ToList();
            Console.WriteLine($"Total : {total} , Average : {average:F2} , Higest : {string.Join(", ", highestExpenses.Select(e => e.Name))} ({maxAmount})");


            Console.WriteLine("--------------------------------------------------------------------");

        }
    }
    public class Expense
    {
        public Expense(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}