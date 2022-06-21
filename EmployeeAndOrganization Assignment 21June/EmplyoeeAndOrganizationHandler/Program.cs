﻿//https://aka.ms/new-console-template for more information
using EmployeeAndOrganization.Entities;

namespace EmplyoeeAndOrganizationHandler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CRUD_Emplyoee cRUD_OperationforEmployee = new CRUD_Emplyoee();
            Employee employee = new Employee { Name = "Yogesh", Age = 24, Address = "Jalgaon" };
            List<EmployeeOrganization> EmployeeOrganization = new List<EmployeeOrganization>();
            EmployeeOrganization.Add(new EmployeeOrganization { OrganizationName = "Telco" });
            EmployeeOrganization.Add(new EmployeeOrganization { OrganizationName = "Capgemini" });
            EmployeeOrganization.Add(new EmployeeOrganization { OrganizationName = "KelltonTech" });
            cRUD_OperationforEmployee.InsertEmployeeWithItsOrgnization(employee, EmployeeOrganization);


            cRUD_OperationforEmployee.PrintEmployeeById(1);

            Console.WriteLine("delete 2");
            cRUD_OperationforEmployee.DeleteEmployee(2);


            cRUD_OperationforEmployee.PrintEmployeeById(1);

            Console.WriteLine("updating ...");
            List<EmployeeOrganization> update = new List<EmployeeOrganization>();
            update.Add(new EmployeeOrganization { OrganizationName = "Infosys" });
            update.Add(new EmployeeOrganization { OrganizationName = "Wipro" });
            update.Add(new EmployeeOrganization { OrganizationName = "Maxtton" });

            cRUD_OperationforEmployee.UpdateEmployeeAndOrgnization(3, "Akash", update);


            cRUD_OperationforEmployee.PrintEmployeeById(2);
            cRUD_OperationforEmployee.PrintEmployeeById(1);
            Employee newemp = new Employee { Name = "Vinay", Age = 25, Address = "Pune" };
            List<EmployeeOrganization> secondwaytoinsert = new List<EmployeeOrganization>();
            secondwaytoinsert.Add(new EmployeeOrganization { OrganizationName = "Infosys", Employee = newemp });
            secondwaytoinsert.Add(new EmployeeOrganization { OrganizationName = "Collabera", Employee = newemp });
            cRUD_OperationforEmployee.TheSecondWayToInsertEMP(secondwaytoinsert);

            cRUD_OperationforEmployee.PrintAllEmployee();
            Console.WriteLine("DONE...");
            Console.ReadKey();

        }
    }

}

