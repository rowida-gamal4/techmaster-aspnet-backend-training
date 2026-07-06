using DebugRefactorPack.Helper;
using DebugRefactorPack.Services;
using DebugRefactorPack.UI;

namespace DebugRefactorPack
{
    public class Program
    {
        static void Main (string[]args)
        {
            OrderCalculator orderCalculator = new OrderCalculator ();
            ValidationHelper validationHelper = new ValidationHelper ();
            ReceiptPrinter printer = new ReceiptPrinter ();
            ConsoleMenu  menu = new ConsoleMenu (orderCalculator,validationHelper,printer);
            menu.RunMenu();
        }
    }
}