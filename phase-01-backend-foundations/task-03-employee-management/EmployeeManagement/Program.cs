using EmployeeManagement.Services;
using EmployeeManagement.UI;

namespace EmployeeManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            EmployeeService employeeService = new EmployeeService ();

            ValidationHelper helper = new ValidationHelper(employeeService.employees);

            EmployeeReportService reportService= new EmployeeReportService(employeeService.employees,helper);

            ConsoleMenu consoleMenu = new ConsoleMenu();
            
            consoleMenu.Run(employeeService,reportService);
        }
    }
}