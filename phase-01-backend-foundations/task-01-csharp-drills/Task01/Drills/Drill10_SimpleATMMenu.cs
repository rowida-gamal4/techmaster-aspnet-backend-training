namespace Task01.Drills
{
    public class Drill10_SimpleATMMenu
    {

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("----------Simple ATM Menu-----------");

            decimal initialBalance = 1000;
            bool exit = false;
            while (!exit)
            {

                Console.WriteLine("1.Check Balance");
                Console.WriteLine("2.Deposit");
                Console.WriteLine("3.Withdraw");
                Console.WriteLine("0.Exit");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        exit = true;
                        break;
                    case "1":
                        Console.WriteLine($"Balance : {initialBalance:F2}");
                        Console.WriteLine();
                        break;
                    case "2":
                        initialBalance = Deposit(initialBalance);
                        Console.WriteLine($"New Balance: {initialBalance:F2}");
                        Console.WriteLine();
                        break;
                    case "3":
                        initialBalance = Withdraw(initialBalance);
                        Console.WriteLine($"New Balance: {initialBalance:F2}");
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
        public decimal Deposit(decimal currentBalance)
        {
            bool isParsed;
            decimal depositValue;
            Console.WriteLine("Enter Deposit Amount: ");
            do
            {

                isParsed = decimal.TryParse(Console.ReadLine(), out depositValue);

                if (!isParsed || depositValue <= 0)
                {
                    Console.WriteLine("Deposit must be positive.");
                }

            } while (!isParsed || depositValue <= 0);

            currentBalance = currentBalance + depositValue;
            return currentBalance;
        }
        public decimal Withdraw(decimal currentBalance)
        {
            bool isParsed;
            decimal withdralValue;
            Console.WriteLine("Enter withdrawal  Amount: ");
            do
            {

                isParsed = decimal.TryParse(Console.ReadLine(), out withdralValue);

                if (!isParsed || withdralValue <= 0)
                {
                    Console.WriteLine("Invalid withdrawal Value");
                }
                else if (withdralValue > currentBalance)
                {
                    Console.WriteLine("withdrawal cannot exceed balance");
                }

            } while (!isParsed || withdralValue <= 0 || withdralValue > currentBalance);

            currentBalance = currentBalance - withdralValue;
            return currentBalance;
        }

    }
}