namespace EmployeeManagement.Models
{
    public class Employee
    {
        public string EmployeeId { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public Department Department { get; set; }
        public string Position { get; set; } = default!;
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }

        public string? PhoneNumber { get; set; }

        public string? ManagerName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Employee()
        {
        }
        public Employee(string employeeId,string fullName,string email,Department department, string position,decimal salary, DateTime hireDate, bool isActive = true)
        {
            EmployeeId = employeeId;
            FullName = fullName;
            Email = email;
            Department = department;
            Position = position;
            Salary = salary;
            HireDate = hireDate;
            IsActive = isActive;
        }

    }
}