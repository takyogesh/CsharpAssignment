using EntityFramework.Data;
using EntityFramework.Data.Entities;

using System;

namespace Handler
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Emplyoee
            CRUDhandlerEmployee obj = new CRUDhandlerEmployee();

            /* Console.WriteLine("Adding a new Employee");
             obj.Insert(new Employee { Name = "Yogesh", Address = "Pune" });
             obj.Insert(new Employee { Name = "Vinay", Address = "Texas" });
             obj.Insert(new Employee { Name = "Piyush", Address = "Nagpur" });
             PrintAllEmployees();*/

            /*  Console.WriteLine("Updating Employee with EmployeeId 17");
              obj.Update(17, new Employee { Name = "Akash", Address = "Mumbai" });
              PrintAllEmployees();*/

            /* Console.WriteLine("Retrieving Employee details for EmployeeId 17");
             var employee = obj.GetEmplpoyeeById(17);
             Console.WriteLine($"Employee Name of employee ID 17 is {employee.Name}");*/

            Console.WriteLine("Deleting Employee details for EmployeeId 17");
            obj.Delete(17);
            PrintAllEmployees();
            #endregion

            #region EmplyoyeeEducation
            /* CRUDhandlerEmplyoeeEducation employeEducation = new CRUDhandlerEmplyoeeEducation();
             employeEducation.AddEducation(new EmplyoeeEducation { CourseName = "BE", UniversityName = "NMU", PassingYear = 2018, MarksPercentage = 75, ID = 3 });
             employeEducation.AddEducation(new EmplyoeeEducation { CourseName = "BE", UniversityName = "NMU", PassingYear = 2019, MarksPercentage = 72, ID = 2 });
             var edu = employeEducation.ShowAllEmpEducation();
             foreach (var employeeEdu in edu)
             {
                 Console.WriteLine(employeeEdu);
                 Console.WriteLine();
             }
             employeEducation.UpdateEdu(1, new EmplyoeeEducation { CourseName = "IT", UniversityName = "NMU", PassingYear = 2021, MarksPercentage = 87, ID = 1 });
             edu = employeEducation.ShowAllEmpEducation();
             foreach (var employeeEdu in edu)
             {
                 Console.WriteLine(employeeEdu);
                 Console.WriteLine();
             }
             employeEducation.DeleteEdu(2);
             edu = employeEducation.ShowAllEmpEducation();
             foreach (var employeeEdu in edu)
             {
                 Console.WriteLine(employeeEdu);
                 Console.WriteLine();
             }*/
            #endregion

            Console.ReadLine();
        }
        private static void PrintAllEmployees()
        {
            Console.WriteLine("Printing all Employees");
            CRUDhandlerEmployee obj = new CRUDhandlerEmployee();
            foreach (Employee employee in obj.GetAllEmployees())
            {
                Console.WriteLine(employee);
               // Console.WriteLine($"Employee Name is {employee.Name} and address is {employee.Address}");
            }
        } 
    }
}
