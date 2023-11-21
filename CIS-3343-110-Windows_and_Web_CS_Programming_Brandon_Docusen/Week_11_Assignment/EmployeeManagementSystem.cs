using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Employee
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }

    protected Employee(int id, string firstName, string lastName, string email, decimal salary)
    {
        EmployeeID = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Salary = salary;
    }
    public virtual string GetDetails()
    {
        return String.Format("ID: {0}, Name: {1} {2}, Email: {3}, Salary: {4:C}", EmployeeID, FirstName, LastName, Email, Salary);
    }
    public abstract decimal CalculateSalary();
}
public class FullTimeEmployee : Employee
{
    public decimal Bonus { get; set; }
    public FullTimeEmployee(int id, string firstName, string lastName, string email, decimal salary, decimal bonus)
        : base(id, firstName, lastName, email, salary)
    {
        Bonus = bonus;
    }

    public override decimal CalculateSalary()
    {
        return Salary + Bonus;
    }
}
public class PartTimeEmployee : Employee
{
    public decimal HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    public PartTimeEmployee(int id, string firstName, string lastName, string email, decimal hourlyRate, int hoursWorked)
        : base(id, firstName, lastName, email, hourlyRate * hoursWorked)
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    public override decimal CalculateSalary()
    {
        return HourlyRate * HoursWorked;
    }
}
public class EmployeeRepository
{
    private List<Employee> _employees = new List<Employee>();
    public void AddEmployee(Employee employee)
    {
        try
        {
            _employees.Add(employee);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred while adding employee: " + ex.Message);
        }
    }
    public Employee ViewEmployee(int id)
    {
        try
        {
            return _employees.FirstOrDefault(e => e.EmployeeID == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred while viewing employee: " + ex.Message);
            return null;
        }
    }
    public void UpdateEmployee(int id, Employee updatedEmployee)
    {
        try
        {
            var employee = _employees.FirstOrDefault(e => e.EmployeeID == id);
            if (employee != null)
            {
                employee.FirstName = updatedEmployee.FirstName;
                employee.LastName = updatedEmployee.LastName;
                employee.Email = updatedEmployee.Email;
                employee.Salary = updatedEmployee.Salary;
            }
            else
            {
                throw new Exception("Employee not found");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred while updating employee: " + ex.Message);
        }
    }
    public void DeleteEmployee(int id)
    {
        try
        {
            var employee = _employees.FirstOrDefault(e => e.EmployeeID == id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
            else
            {
                throw new Exception("Employee not found");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred while deleting employee: " + ex.Message);
        }
    }
    public List<Employee> GetAllEmployees()
    {
        try
        {
            return _employees;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred while getting all employees: " + ex.Message);
            return new List<Employee>();
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        try
        {
            EmployeeRepository repository = new EmployeeRepository();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nEmployee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View Employee");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. List All Employees");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddEmployeeUI(repository);
                        break;
                    case 2:
                        ViewEmployeeUI(repository);
                        break;
                    case 3:
                        UpdateEmployeeUI(repository);
                        break;
                    case 4:
                        DeleteEmployeeUI(repository);
                        break;
                    case 5:
                        ListAllEmployeesUI(repository);
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
private static void AddEmployeeUI(EmployeeRepository repository)
{
    Console.WriteLine("\nAdd New Employee");
    Console.Write("Enter Employee ID: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter First Name: ");
    string firstName = Console.ReadLine();
    Console.Write("Enter Last Name: ");
    string lastName = Console.ReadLine();
    Console.Write("Enter Email: ");
    string email = Console.ReadLine();
    Console.Write("Is this a Full Time (F) or Part Time (P) employee? (F/P): ");
    string employeeType = Console.ReadLine();
    if (employeeType.ToUpper() == "F")
    {
        Console.Write("Enter Salary: ");
        decimal salary = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Enter Bonus: ");
        decimal bonus = Convert.ToDecimal(Console.ReadLine());
        FullTimeEmployee fullTimeEmployee = new FullTimeEmployee(id, firstName, lastName, email, salary, bonus);
        repository.AddEmployee(fullTimeEmployee);
    }
    else if (employeeType.ToUpper() == "P")
    {
        Console.Write("Enter Hourly Rate: ");
        decimal hourlyRate = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Enter Hours Worked: ");
        int hoursWorked = Convert.ToInt32(Console.ReadLine());
        PartTimeEmployee partTimeEmployee = new PartTimeEmployee(id, firstName, lastName, email, hourlyRate, hoursWorked);
        repository.AddEmployee(partTimeEmployee);
    }
    else
    {
        Console.WriteLine("Invalid employee type. Please enter 'F' for Full Time or 'P' for Part Time.");
    }
    Console.WriteLine("Employee added successfully.");
}
private static void ViewEmployeeUI(EmployeeRepository repository)
{
    Console.WriteLine("\nView Employee Details");
    Console.Write("Enter Employee ID: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Employee employee = repository.ViewEmployee(id);
    if (employee != null)
    {
        Console.WriteLine("Employee Details:");
        Console.WriteLine(employee.GetDetails());
        Console.WriteLine("Calculated Salary: " + String.Format("{0:C}", employee.CalculateSalary()));
    }
    else
    {
        Console.WriteLine("Employee not found.");
    }
}
private static void UpdateEmployeeUI(EmployeeRepository repository)
{
    Console.WriteLine("\nUpdate Employee Details");
    Console.Write("Enter Employee ID of the employee you want to update: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Employee existingEmployee = repository.ViewEmployee(id);
    if (existingEmployee == null)
    {
        Console.WriteLine("Employee not found.");
        return;
    }
    Console.Write("Enter Updated First Name (leave blank to keep current): ");
    string firstName = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(firstName))
    {
        existingEmployee.FirstName = firstName;
    }
    Console.Write("Enter Updated Last Name (leave blank to keep current): ");
    string lastName = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(lastName))
    {
        existingEmployee.LastName = lastName;
    }
    Console.Write("Enter Updated Email (leave blank to keep current): ");
    string email = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(email))
    {
        existingEmployee.Email = email;
    }
    Console.Write("Enter Updated Salary (leave blank to keep current): ");
    string salaryInput = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(salaryInput))
    {
        decimal salary = Convert.ToDecimal(salaryInput);
        existingEmployee.Salary = salary;
    }
    FullTimeEmployee fullTimeEmployee = existingEmployee as FullTimeEmployee;
    if (fullTimeEmployee != null)
    {
        Console.Write("Enter Updated Bonus (leave blank to keep current): ");
        string bonusInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(bonusInput))
        {
            decimal bonus = Convert.ToDecimal(bonusInput);
            fullTimeEmployee.Bonus = bonus;
        }
    }
    PartTimeEmployee partTimeEmployee = existingEmployee as PartTimeEmployee;
    if (partTimeEmployee != null)
    {
        Console.Write("Enter Updated Hourly Rate (leave blank to keep current): ");
        string hourlyRateInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(hourlyRateInput))
        {
            decimal hourlyRate = Convert.ToDecimal(hourlyRateInput);
            partTimeEmployee.HourlyRate = hourlyRate;
        }
        Console.Write("Enter Updated Hours Worked (leave blank to keep current): ");
        string hoursWorkedInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(hoursWorkedInput))
        {
            int hoursWorked = Convert.ToInt32(hoursWorkedInput);
            partTimeEmployee.HoursWorked = hoursWorked;
        }
    }
    repository.UpdateEmployee(id, existingEmployee);
    Console.WriteLine("Employee updated successfully.");
}
private static void DeleteEmployeeUI(EmployeeRepository repository)
{
    Console.WriteLine("\nDelete Employee");
    Console.Write("Enter Employee ID of the employee you want to delete: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Employee employee = repository.ViewEmployee(id);
    if (employee == null)
    {
        Console.WriteLine("Employee not found.");
        return;
    }
    Console.WriteLine("You are about to delete the following employee:");
    Console.WriteLine(employee.GetDetails());
    Console.Write("Are you sure? (Y/N): ");
    string confirmation = Console.ReadLine();
    if (confirmation.ToUpper() == "Y")
    {
        repository.DeleteEmployee(id);
        Console.WriteLine("Employee deleted successfully.");
    }
    else
    {
        Console.WriteLine("Employee deletion cancelled.");
    }
}
private static void ListAllEmployeesUI(EmployeeRepository repository)
{
    Console.WriteLine("\nList of All Employees");
    List<Employee> employees = repository.GetAllEmployees();
    if (employees.Count == 0)
    {
        Console.WriteLine("There are no employees to display.");
        return;
    }
    Console.WriteLine("Employees:");
    foreach (Employee employee in employees)
    {
        Console.WriteLine(employee.GetDetails());
        Console.WriteLine("Calculated Salary: " + String.Format("{0:C}", employee.CalculateSalary()) + "\n");
    }
}
}