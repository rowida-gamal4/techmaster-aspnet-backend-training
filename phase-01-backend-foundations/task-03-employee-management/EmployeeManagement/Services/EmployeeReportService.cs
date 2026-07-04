using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public class EmployeeReportService
    {
        private readonly List<Employee> employees;
        private readonly ValidationHelper helper;

        public EmployeeReportService(List<Employee> employees, ValidationHelper helper)
        {
            this.employees = employees;
            this.helper = helper;
        }

        public void SerachEmployees()
        {
            Console.Clear();
            Console.WriteLine("================ 4. Search Employee =====================");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("---Search By--- ");
                Console.WriteLine("1.EmployeeId");
                Console.WriteLine("2.Full Name");
                Console.WriteLine("0.Exit");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Employee? employee = helper.SearchById();
                        if (employee is null)
                        {
                            Console.WriteLine("Employee Not Found");
                        }
                        else
                        {
                            Console.WriteLine(" Employee :");
                            Console.WriteLine("-------------------------");
                            helper.PrintEmployee(employee);
                        }
                        break;
                    case "2":
                        List<Employee> employees = helper.SearchByName();
                        if (!employees.Any())
                        {
                            Console.WriteLine("No employees found.");
                        }
                        else
                        {
                            foreach (var emp in employees)
                            {
                                Console.WriteLine(" Employee :");
                                Console.WriteLine("-------------------------");
                                helper.PrintEmployee(emp);
                            }
                        }
                        break;
                    case "0": exit = true; break;
                    default: Console.WriteLine("Invalid choice"); break;
                }
            }
        }

        public void FilterByDepartment()
        {
            Console.Clear();
            Console.WriteLine("================ 5. Filter by Department =====================");
            string? deptName;
            do
            {
                Console.Write("Enter Department Name: ");
                deptName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(deptName))
                {
                    Console.WriteLine("Department is required.");
                }
            } while (string.IsNullOrWhiteSpace(deptName));
            var selectedEmployees = employees.Where(e => e.Department.ToString().Equals(deptName, StringComparison.OrdinalIgnoreCase) && e.IsActive);
            if (selectedEmployees.Any())
            {
                foreach (var emp in selectedEmployees)
                {
                    Console.WriteLine(" Employee :");
                    Console.WriteLine("-------------------------");
                    helper.PrintEmployee(emp);
                }
            }
            else
            {
                Console.WriteLine("No active employees found in this department.");
            }
        }

        public void SortEmployees()
        {
            Console.Clear();
            Console.WriteLine("================ 6. Sort Employees =====================");
            List<Employee>? sortedEmployees = null;
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("--------Sort By--------- ");
                Console.WriteLine("1.Salary Ascending");
                Console.WriteLine("2.Salary Descending.");
                Console.WriteLine("3.Hire Date Ascending");
                Console.WriteLine("4.Hire Date Descending");
                Console.WriteLine("5.Name");
                Console.WriteLine("0.Exit");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        sortedEmployees = employees.OrderBy(e => e.Salary).ToList();
                        break;
                    case "2":
                        sortedEmployees = employees.OrderByDescending(e => e.Salary).ToList();
                        break;
                    case "3":
                        sortedEmployees = employees.OrderBy(e => e.HireDate).ToList();
                        break;
                    case "4":
                        sortedEmployees = employees.OrderByDescending(e => e.HireDate).ToList();
                        break;
                    case "5":
                        sortedEmployees = employees.OrderBy(e => e.FullName).ToList();
                        break;
                    case "0": exit = true; break;
                    default: Console.WriteLine("Invalid choice"); continue;
                }
                if (sortedEmployees != null && sortedEmployees.Any())
                {
                    foreach (var item in sortedEmployees)
                    {
                        Console.WriteLine("\nSorted Employees");
                        Console.WriteLine("------------------------------");
                        helper.PrintEmployee(item);
                    }
                }
            }
        }

        public void SalaryReports()
        {
            Console.Clear();
            Console.WriteLine("================ 7. Show Salary Reports =====================");
            decimal averageSalary = employees.Average(e => e.Salary);

            Employee? highestSalaryEmployee = employees.MaxBy(e => e.Salary);

            Employee? lowestSalaryEmployee = employees.MinBy(e => e.Salary);

            decimal totalPayroll = employees.Sum(e => e.Salary);

            int activeCount = employees.Count(e => e.IsActive);

            int inactiveCount = employees.Count(e => !e.IsActive);

            var employeesByDept = employees.GroupBy(e => e.Department).Select(d => new
            {
                Department = d.Key,
                Count = d.Count(),
            });

            Console.WriteLine("----------- Salary Report -----------");
            Console.WriteLine($"Average Salary          : {averageSalary:C}");
            Console.WriteLine($"Total Payroll           : {totalPayroll:C}");
            Console.WriteLine($"Highest Salary Employee : {highestSalaryEmployee?.FullName} ({highestSalaryEmployee?.Salary:C})");
            Console.WriteLine($"Lowest Salary Employee  : {lowestSalaryEmployee?.FullName} ({lowestSalaryEmployee?.Salary:C})");
            Console.WriteLine($"Active Employees        : {activeCount}");
            Console.WriteLine($"Inactive Employees      : {inactiveCount}");
            Console.WriteLine("Employees by Department  :");
            foreach (var department in employeesByDept)
            {
                Console.WriteLine($"{department.Department}: {department.Count}");
            }
            Console.WriteLine("----------------------------------------------------");
        }


        public void ViewAllEmployees()
        {
            Console.Clear();
            Console.WriteLine("================ 8. View All Employees =====================");
            if (!employees.Any())
            {
                Console.WriteLine("No employees found.");
                return;
            }
            Console.WriteLine("All Employees:");
            Console.WriteLine("------------------");
            foreach (var item in employees)
            {
                helper.PrintEmployee(item);
            }
        }
    }
}