using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public class EmployeeService
    {
        public List<Employee> employees = new()
        {
            new("EMP-001", "Mohamed Ayman", "mohamed@test.com", Department.IT, "Backend Developer", 20000, new DateTime(2025, 1, 10)),
            new("EMP-002", "Sara Adel", "sara@test.com", Department.HR, "HR Specialist", 12000, new DateTime(2024, 5, 15)),
            new("EMP-003", "Ahmed Tarek", "ahmed@test.com", Department.IT, "Junior Developer", 9000, new DateTime(2026, 1, 1)),
            new("EMP-004", "Omar Samir", "omar@test.com", Department.Sales, "Sales Executive", 11000, new DateTime(2023, 11, 20)),
            new("EMP-005", "Mariam Hassan", "mariam@test.com", Department.Finance, "Accountant", 14000, new DateTime(2022, 9, 11)),
            new("EMP-006", "Khaled Ali", "khaled@test.com", Department.IT, "DevOps Trainee", 10000, new DateTime(2026, 2, 1)),
            new("EMP-007", "Nour Emad", "nour@test.com", Department.Marketing, "Content Specialist", 9500, new DateTime(2025, 7, 8)),
            new("EMP-008", "Youssef Nabil", "youssef@test.com", Department.Sales, "Sales Manager", 18000, new DateTime(2021, 3, 17), false),
            new("EMP-009", "Dina Farouk", "dina@test.com", Department.HR, "Recruiter", 10500, new DateTime(2024, 2, 13)),
            new("EMP-010", "Hady Mahmoud", "hady@test.com", Department.IT, "QA Engineer", 13000, new DateTime(2025, 10, 1)),
            new("EMP-011", "Salma Taha", "salma@test.com", Department.Finance, "Finance Manager", 26000, new DateTime(2020, 12, 12)),
            new("EMP-012", "Ali Mostafa", "ali@test.com", Department.Support, "Support Agent", 8000, new DateTime(2026, 3, 5))
        };

        private readonly ValidationHelper helper;
        public EmployeeService()
        {
            helper = new ValidationHelper(employees);
        }
        public void AddEmployee()
        {
            Console.Clear();
            Console.WriteLine("================ 1. Add Employee =====================");
            string? name;
            string? email;
            int department;
            string? position;
            decimal salary;
            DateTime date;

            name = helper.ReadName();
            email = helper.ReadEmail();
            department = helper.ReadDepartment();
            position = helper.ReadPosition();
            salary = helper.ReadSalary();
            date = helper.ReadDate();

            Employee employee = new Employee
            {
                EmployeeId = $"EMP-{employees.Count + 1:D3}",
                FullName = name,
                Email = email,
                Department = (Department)department,
                Position = position,
                Salary = salary,
                HireDate = date,
                IsActive = true
            };
            employees.Add(employee);
            Console.WriteLine($"Employee with ID: {employee.EmployeeId}  added successfully.");
        }
        public void UpdateEmployee()
        {
            Console.Clear();
            Console.WriteLine("================ 2. Update Employee =====================");
            Employee employee = helper.GetEmployeeById();
            string email = employee.Email;
            int department = (int)employee.Department;
            string position = employee.Position;
            decimal salary = employee.Salary;

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Choose what do you want to update");
                Console.WriteLine("1.email");
                Console.WriteLine("2.department");
                Console.WriteLine("3.position");
                Console.WriteLine("4.salary");
                Console.WriteLine("0. Save and Exit");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": email = helper.ReadEmail(); break;
                    case "2": department = helper.ReadDepartment(); break;
                    case "3": position = helper.ReadPosition(); break;
                    case "4": salary = helper.ReadSalary(); break;
                    case "0": exit = true; break;
                    default: Console.WriteLine("Invalid choice"); break;
                }

            }
            employee.Email = email;
            employee.Department = (Department)department;
            employee.Position = position;
            employee.Salary = salary;
            Console.WriteLine("Employee updated successfully.");
        }
        public void DeactivateEmployee()
        {
            Console.Clear();
            Console.WriteLine("================ 3. Deactivate Employee =====================");
            Employee? employee = helper.GetEmployeeById();
            if (!employee.IsActive)
            {
                Console.WriteLine("Employee is already inactive");
            }
            else
            {
                employee.IsActive = false;
                Console.WriteLine("Employee deactivated successfully.");
            }
        }
       

    }
}
