using EmployeeManagement.Services;

namespace EmployeeManagement.UI
{
    public class ConsoleMenu
    {
           public void Run(EmployeeService employeeService , EmployeeReportService reportService)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("====== Employee Management System ======");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Update Employee");
                Console.WriteLine("3. Deactivate Employee");
                Console.WriteLine("4. Search Employee");
                Console.WriteLine("5. Filter by Department");
                Console.WriteLine("6. Sort Employees");
                Console.WriteLine("7. Show Salary Reports");
                Console.WriteLine("8. View All Employees");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {

                    case "1":
                        employeeService.AddEmployee();
                        break;
                    case "2":
                        employeeService.UpdateEmployee();
                        break;
                    case "3":
                        employeeService.DeactivateEmployee();
                        break;
                    case "4":
                        reportService.SerachEmployees();
                        break;
                    case "5":
                        reportService.FilterByDepartment();
                        break;
                    case "6":
                        reportService.SortEmployees();
                        break;
                    case "7":
                        reportService.SalaryReports();
                        break;
                    case "8":
                        reportService.ViewAllEmployees();
                        break;    
                    case "9":
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