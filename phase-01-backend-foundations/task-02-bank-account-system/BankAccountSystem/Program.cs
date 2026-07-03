using BankAccountSystem.Services;
using BankAccountSystem.UI;

namespace BankAccountSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            BankService bankService = new BankService();
            ConsoleMenu consoleMenu = new ConsoleMenu();
            consoleMenu.Run(bankService);
        }
    }
}