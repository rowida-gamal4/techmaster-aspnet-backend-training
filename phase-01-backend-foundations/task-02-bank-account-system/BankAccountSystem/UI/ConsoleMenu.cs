using BankAccountSystem.Services;

namespace BankAccountSystem.UI
{
    public class ConsoleMenu
    {
        public void Run(BankService bankService)
        {
            bool exit = false;
            while (!exit)
            {

                Console.WriteLine("1. Create Customer Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Transfer Money");
                Console.WriteLine("5. View Account Details");
                Console.WriteLine("6. View Transaction History");
                Console.WriteLine("7. View All Accounts");
                Console.WriteLine("8. Exit");
                Console.WriteLine("Choose an option:");

                var choice = Console.ReadLine();
                switch (choice)
                {

                    case "1":
                        bankService.CreateCustomerAccount();
                        break;
                    case "2":
                        bankService.DepositMoney();
                        break;
                    case "3":
                        bankService.WithdrawMoney();
                        break;
                    case "4":
                        bankService.TransferMoney();
                        break;
                    case "5":
                        bankService.ViewAccountDetails();
                        break;
                    case "6":
                        bankService.ViewTransactionHistory();
                        break;
                    case "7":
                        bankService.ViewAllAccounts();
                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                if (!exit)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
