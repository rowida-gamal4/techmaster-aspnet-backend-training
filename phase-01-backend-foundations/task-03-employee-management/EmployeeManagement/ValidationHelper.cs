using EmployeeManagement.Models;

namespace EmployeeManagement
{
    public class ValidationHelper(List<Employee> employees)
    {
        public string ReadEmail()
        {
            string? email;
            do
            {
                Console.Write("Enter Email: ");
                email = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(email))
                {
                    Console.WriteLine("Email is required.");
                }
                else if (!email.Contains('@') || !email.Contains('.'))
                {
                    Console.WriteLine("Invalid email format.");
                }

            } while (string.IsNullOrWhiteSpace(email) || !email.Contains('@') || !email.Contains('.'));
            return email;
        }
        public int ReadDepartment()
        {
            bool isValid;
            int department;
            do
            {
                Console.WriteLine("Enter Department: ");
                Console.WriteLine("1. IT");
                Console.WriteLine("2. HR");
                Console.WriteLine("3. Sales");
                Console.WriteLine("4. Finance");
                Console.WriteLine("5. Marketing");
                Console.WriteLine("6. Support");
                isValid = int.TryParse(Console.ReadLine(), out department);
                if (!isValid || (department != 1 && department != 2 && department != 3 && department != 4 && department != 5 && department != 6))
                {
                    Console.WriteLine("Enter valid department option.");
                }


            } while (!isValid || (department != 1 && department != 2 && department != 3 && department != 4 && department != 5 && department != 6));

            return department;
        }
        public string ReadPosition()
        {
            string? position;
            do
            {
                Console.Write("Enter Position: ");
                position = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(position))
                {
                    Console.WriteLine("Position is required.");
                }


            } while (string.IsNullOrWhiteSpace(position));
            return position;
        }
        public decimal ReadSalary()
        {
            decimal salary;
            bool isValid;
            do
            {
                Console.Write("Enter salary: ");
                isValid = decimal.TryParse(Console.ReadLine(), out salary);
                if (!isValid || salary <= 0)
                {
                    Console.WriteLine("salary must be positive.");
                }

            } while (!isValid || salary <= 0);

            return salary;
        }

        public Employee GetEmployeeById()
        {

            Employee? employee = null;
            string emplyeeId;
            do
            {
                Console.Write("Enter EmployeeId: ");
                emplyeeId = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(emplyeeId))
                {
                    employee = employees.FirstOrDefault(e => e.EmployeeId == emplyeeId);
                }
                if (employee == null)
                {
                    Console.WriteLine("Invalid Emplyee ID");
                }
            } while (employee == null);

            return employee!;
        }

        public string ReadName()
        {
            string name;
            do
            {
                Console.Write("Enter Full Name: ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name is required.");
                }

            } while (string.IsNullOrWhiteSpace(name));

            return name;
        }

        public DateTime ReadDate()
        {
            bool isValid;
            DateTime date;
            do
            {
                Console.Write("Enter Hire Date: ");
                isValid = DateTime.TryParse(Console.ReadLine(), out date);
                if (!isValid || date > DateTime.Now)
                {
                    Console.WriteLine("Hire Date can not be in the future.");
                }

            } while (!isValid || date > DateTime.Now);

            return date;
        }
 

        #region SearchEmployee
        public Employee? SearchById()
        {
            string? employeeId;
            do
            {
                Console.Write("Enter Employee Id: ");
                employeeId = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(employeeId))
                {
                    Console.WriteLine("Employee Id is required.");
                }
            } while (string.IsNullOrWhiteSpace(employeeId));

            return employees.FirstOrDefault(e => e.EmployeeId == employeeId);

        }
        public List<Employee> SearchByName()
        {
            string? name;
            do
            {
                Console.Write("Enter Employee Name: ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name is required.");
                }
            } while (string.IsNullOrWhiteSpace(name));

            return employees.Where(e => e.FullName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

        }

        public void PrintEmployee(Employee employee)
        {
            Console.WriteLine($"Name       : {employee.FullName}");
            Console.WriteLine($"Email      : {employee.Email}");
            Console.WriteLine($"Department : {employee.Department}");
            Console.WriteLine($"Position   : {employee.Position}");
            Console.WriteLine($"Salary     :{employee.Salary:C}");
            Console.WriteLine($"Hire Date  : {employee.HireDate:dd/MM/yyyy}");
            Console.WriteLine($"Status     :{(employee.IsActive ? "Active" : "Inactive")}");
            Console.WriteLine("----------------------------------------------------------");
        }
        #endregion
    }
}