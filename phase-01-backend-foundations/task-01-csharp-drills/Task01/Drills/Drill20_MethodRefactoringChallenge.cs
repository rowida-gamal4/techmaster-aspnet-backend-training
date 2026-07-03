namespace Task01.Drills
{
    public class Drill20_MethodRefactoringChallenge
    {
        public void Run()
        {
            Console.Clear();

            Console.WriteLine("1. Refactored Temperature Converter");
            Console.WriteLine("2. Refactored Grade Calculator");
            Console.WriteLine("3. Refactored ATM Menu");

            switch (Console.ReadLine())
            {
                case "1":
                    RunTemperatureConverter();
                    break;
                case "2":
                    RunGradeCalculator();
                    break;
                case "3":
                    RunATMMenu();
                    break;
            }
        }

        #region Refactored Temperature Converter
        private void RunTemperatureConverter()
        {
            double celsius = InputTemperatureConverter();
            double fahrenheit = ProcessingTemperatureConverter(celsius);
            OutputTemperatureConverter(celsius, fahrenheit);
        }
        private double InputTemperatureConverter()
        {
            Console.Clear();
            Console.WriteLine("----------Temperature Converter-----------");
            bool isParsed;
            double celsius;

            do
            {
                Console.Write("Enter a Celsius temperature: ");
                isParsed = double.TryParse(Console.ReadLine(), out celsius);

                if (!isParsed)
                {
                    Console.WriteLine("Invalid temperature value.");
                }

            } while (!isParsed);

            return celsius;
        }

        private double ProcessingTemperatureConverter(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        private void OutputTemperatureConverter(double celsius, double fahrenheit)
        {
            Console.WriteLine($"{celsius}'C = {fahrenheit:F2}'F");
            Console.WriteLine("------------------------------------");
        }
        #endregion
        #region Refactored Grade Calculator

        private void RunGradeCalculator()
        {
            int score = InputGradeCalculator();
            string grade = ProcessingGradeCalculator(score);
            OutputGradeCalculator(grade);
        }

        private int InputGradeCalculator()
        {
            Console.Clear();
            Console.WriteLine("----------Grade Calculator-----------");

            bool isParsed;
            int score;

            do
            {
                Console.Write("Enter a score from 0 to 100:");
                isParsed = int.TryParse(Console.ReadLine(), out score);

                if (!isParsed)
                {
                    Console.WriteLine("Invalid Please enter a number ");
                }
                else if (score < 0 || score > 100)
                {
                    Console.WriteLine("Score must be between 0 and 100 ");
                }

            } while (!isParsed || score < 0 || score > 100);

            return score;
        }

        private string ProcessingGradeCalculator(int score)
        {
            if (score >= 90)
                return "A";
            else if (score >= 80)
                return "B";
            else if (score >= 70)
                return "C";
            else if (score >= 60)
                return "D";
            else
                return "F";
        }

        private void OutputGradeCalculator(string grade)
        {
            Console.WriteLine($"Grade: {grade}");
            Console.WriteLine("------------------------------------");
        }

        #endregion
        #region Refactored ATM Menu
        private void RunATMMenu()
        {
            Console.Clear();
            Console.WriteLine("----------Simple ATM Menu-----------");

            decimal balance = 1000m;
            bool exit = false;

            while (!exit)
            {
                string choice = ShowMenu();

                switch (choice)
                {
                    case "0":
                        exit = true;
                        break;

                    case "1":
                        PrintBalance(balance);
                        break;

                    case "2":
                        balance = Deposit(balance);
                        PrintBalance(balance);
                        break;

                    case "3":
                        balance = Withdraw(balance);
                        PrintBalance(balance);
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private string ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            return Console.ReadLine()!;
        }

        private void PrintBalance(decimal balance)
        {
            Console.WriteLine($"Current Balance: {balance:F2}");
        }

        private decimal Deposit(decimal currentBalance)
        {
            bool isParsed;
            decimal depositValue;

            do
            {
                Console.Write("Enter Deposit Amount: ");

                isParsed = decimal.TryParse(Console.ReadLine(), out depositValue);

                if (!isParsed || depositValue <= 0)
                {
                    Console.WriteLine("Deposit must be positive ");
                }

            } while (!isParsed || depositValue <= 0);

            return currentBalance + depositValue;
        }

        private decimal Withdraw(decimal currentBalance)
        {
            bool isParsed;
            decimal withdrawalValue;

            do
            {
                Console.Write("Enter Withdrawal Amount: ");

                isParsed = decimal.TryParse(Console.ReadLine(), out withdrawalValue);

                if (!isParsed || withdrawalValue <= 0)
                {
                    Console.WriteLine("Invalid withdrawal value ");
                }
                else if (withdrawalValue > currentBalance)
                {
                    Console.WriteLine("Withdrawal cannot exceed balance ");
                }

            } while (!isParsed || withdrawalValue <= 0 || withdrawalValue > currentBalance);

            return currentBalance - withdrawalValue;
        }

        #endregion
    /*
     Comments explaining the refactor :

        Since I was making a class for each drill, the Main method was already simple and only responsible for calling the required drill.
        So I chosse 3 drills and refactored them further by splitting the logic into smaller methods following the Single Responsibility Principle, and I put each one in a separate #region inside the same class so the mentor can find them easily.

        First, I started with the Temperature Converter. I divided it into 4 functions:
        - RunTemperatureConverter(): coordinates the workflow by calling the other methods.
        - InputTemperatureConverter(): handles reading and validating the Celsius temperature from the user.
        - ProcessingTemperatureConverter(): handles converting the Celsius value to Fahrenheit.
        - OutputTemperatureConverter(): handles displaying the formatted result to the user.

        Second, I refactored the Grade Calculator and divided it into 4 functions:
        - RunGradeCalculator(): coordinates the workflow.
        - InputGradeCalculator(): handles reading and validating the score.
        - ProcessingGradeCalculator(): handles calculating the grade based on the score.
        - OutputGradeCalculator(): handles displaying the final grade.

        Finally, I refactored the Simple ATM Menu. Since the Deposit() and Withdraw() methods were already separated in the original solution, I kept them and focused on making the main workflow smaller by dividing it into the following methods:
        - RunATMMenu(): coordinates the ATM workflow.
        - ShowMenu(): handles displaying the menu and reading the user's choice.
        - Deposit(): handles reading, validating, and processing deposit operations.
        - Withdraw(): handles reading, validating, and processing withdrawal operations.
        - PrintBalance(): handles displaying the current account balance.

This refactoring separates the responsibilities into smaller methods, making the code cleaner, easier to read, easier to maintain, and easier to test.
    */
    }
}
