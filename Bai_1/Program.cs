using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            Employee[] employees = new Employee[0]; // Khởi tạo mảng động để quản lý Employee

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Find Employee with Highest Salary");
                Console.WriteLine("3. Find Employee by Name");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee(ref employees);
                        break;
                    case "2":
                        FindHighestPaidEmployees(employees);
                        break;
                    case "3":
                        FindEmployeeByName(employees);
                        break;
                    case "4":
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
        }

        public static void AddEmployee(ref Employee[] employees)
        {
            try
            {
                Console.WriteLine("Add Employee:");
                Console.Write("Enter employee name: ");
                string name = Console.ReadLine();
                Console.Write("Enter hourly wage: ");
                double paymentPerHour = Convert.ToDouble(Console.ReadLine());

                Array.Resize(ref employees, employees.Length + 1);
                employees[employees.Length - 1] = new FullTimeEmployee(name, paymentPerHour); // Default to adding a FullTime employee
                Console.WriteLine("Employee added successfully.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input data. Please try again.");
            }
        }

        public static void FindHighestPaidEmployees(Employee[] employees)
        {
            double maxSalaryFullTime = double.MinValue;
            double maxSalaryPartTime = double.MinValue;
            FullTimeEmployee highestPaidFullTime = null;
            PartTimeEmployee highestPaidPartTime = null;

            foreach (var employee in employees)
            {
                if (employee is FullTimeEmployee)
                {
                    double salary = employee.CalculateSalary();
                    if (salary > maxSalaryFullTime)
                    {
                        maxSalaryFullTime = salary;
                        highestPaidFullTime = (FullTimeEmployee)employee;
                    }
                }
                else if (employee is PartTimeEmployee)
                {
                    double salary = employee.CalculateSalary();
                    if (salary > maxSalaryPartTime)
                    {
                        maxSalaryPartTime = salary;
                        highestPaidPartTime = (PartTimeEmployee)employee;
                    }
                }
            }

            Console.WriteLine($"Employee with highest salary in FullTime: {highestPaidFullTime}, Salary: {maxSalaryFullTime}");
            Console.WriteLine($"Employee with highest salary in PartTime: {highestPaidPartTime}, Salary: {maxSalaryPartTime}");
        }

        public static void FindEmployeeByName(Employee[] employees)
        {
            Console.Write("Enter the name of the employee to find: ");
            string name = Console.ReadLine();
            bool found = false;

            foreach (var employee in employees)
            {
                if (employee.ToString().Contains(name))
                {
                    Console.WriteLine($"Employee found: {employee}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No employee found with that name.");
            }
        }
    }
}
