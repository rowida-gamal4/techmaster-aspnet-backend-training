using Task01.Drills;

namespace Task01
{
    public class Program
{
    static void Main(string[] args)
    {
        bool exit = false ;
        while (!exit)
        {
            Console.WriteLine("-----------Choose Number from 0:20-----------");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1.Temperature Converter");
            Console.WriteLine("2.Grade Calculator");
            Console.WriteLine("3.Simple Login Validator");
            Console.WriteLine("4.Even/Odd Analyzer");
            Console.WriteLine("5.Maximum and Minimum Finder");
            Console.WriteLine("6.Word Counter");
            Console.WriteLine("7.Name Formatter");
            Console.WriteLine("8.Password Strength Checker");
            Console.WriteLine("9.Shopping Cart Total");
            Console.WriteLine("10.Simple ATM Menu");
            Console.WriteLine("11.Duplicate Number Detector");
            Console.WriteLine("12.Email Validator");
            Console.WriteLine("13.Palindrome Checker");
            Console.WriteLine("14.Simple Expense Tracker");
            Console.WriteLine("15.Array Rotation");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "0": exit = true ; break ;                 
                case "1": new Drill01_TemperatureConverter().Run(); break;
                case "2": new Drill02_GradeCalculator().Run(); break;
                case "3": new Drill03_SimpleLoginValidator().Run(); break;
                case "4": new Drill04_EvenOddAnalyzer().Run(); break;
                case "5": new Drill05_MaximumAndMinimumFinder().Run(); break;
                case "6": new Drill06_WordCounter().Run(); break;
                case "7": new Drill07_NameFormatter().Run(); break;
                case "8": new Drill08_PasswordStrengthChecker().Run(); break;
                case "9": new Drill09_ShoppingCartTotal().Run(); break;
                case "10": new Drill10_SimpleATMMenu().Run(); break;
                case "11": new Drill11_DuplicateNumberDetector().Run(); break;
                case "12": new Drill12_EmailValidator().Run(); break;
                case "13": new Drill13_PalindromeChecker().Run(); break;
                case "14": new Drill14_SimpleExpenseTracker().Run();
                break;
                case "15": new Drill15_ArrayRotation().Run();
                break;

                default:Console.WriteLine("Invalid choice."); break;
            }
            if (!exit)
            {
                
                Console.WriteLine("Press any key to return to the menu...\n");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

}

}
