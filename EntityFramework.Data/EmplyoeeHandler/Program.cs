using EntityFramework.Data;
using EntityFramework.Data.Entities;
using System;

namespace EmplyoeeHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUDhandler obj = new CRUDhandler();

            Console.WriteLine("Adding a new Employee");
            obj.Insert(new Employee { Name = "Yogesh", Address = "Pune" });
            obj.Insert(new Employee { Name = "Vinay", Address = "Texas" });
            PrintAllEmployees();

            Console.WriteLine("Updating Employee with EmployeeId 2");
            obj.Update(2, new Employee { Name = "Akash", Address = "Mumbai" });
            PrintAllEmployees();

            Console.WriteLine("Retrieving Employee details for EmployeeId 2");
            var employee = obj.GetEmplpoyeeById(2);
            Console.WriteLine($"Employee Name of employee ID 2 is {employee.Name}");

            Console.WriteLine("Deleting Employee details for EmployeeId 2");
            obj.Delete(2);
            PrintAllEmployees();

            Console.ReadLine();
        }
        private static void PrintAllEmployees()
        {
            Console.WriteLine("Printing all Employees");
            CRUDhandler obj = new CRUDhandler();
            foreach (Employee employee in obj.GetAllEmployees())
            {
                Console.WriteLine($"Employee Name is {employee.Name} and address is {employee.Address}");
            }
        }
    }
}
