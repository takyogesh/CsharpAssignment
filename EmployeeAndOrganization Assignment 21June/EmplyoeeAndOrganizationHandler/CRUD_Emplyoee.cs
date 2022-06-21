using EmployeeAndOrganization;
using EmployeeAndOrganization.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmplyoeeAndOrganizationHandler
{
    public class CRUD_Emplyoee
    {
        DemoDbContext DbContextFile;
        public CRUD_Emplyoee()
        {
            DbContextFile = new DemoDbContext();
        }
        public void InsertEmployeeWithItsOrgnization(Employee employee, List<EmployeeOrganization> employeeOrganizationsList)
        {
            var Employee = new Employee
            {
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                EmployeeOrganizations = employeeOrganizationsList
            };
            DbContextFile.Add(Employee);
            DbContextFile.SaveChanges();
        }
        public void PrintEmployeeById(int Id)
        {
            var emp = DbContextFile.Employees.Where(empl => empl.Id == Id).Include(e => e.EmployeeOrganizations).FirstOrDefault();
            if (emp != null)
            {
                Console.WriteLine("Employe Name   :" + emp.Name);
                Console.WriteLine("Employee Age   :" + emp.Age);
                Console.WriteLine("Employee Address:" + emp.Address);
                Console.WriteLine("==================================");
                foreach (EmployeeOrganization employeeOrganizations in emp.EmployeeOrganizations)
                {
                    Console.WriteLine("Employee Organization  :" + employeeOrganizations.OrganizationName);
                }
            }
            else
            {
                Console.WriteLine(" Record not Found with Id :" + Id);
            }
        }
        public void PrintAllEmployee()
        {
            var empl = DbContextFile.Employees.Include(e => e.EmployeeOrganizations).ToList();
            if (empl != null)
            {
                foreach (Employee emp in empl)
                {
                    Console.WriteLine("Employe Name   :" + emp.Name);
                    Console.WriteLine("Employee Age   :" + emp.Age);
                    Console.WriteLine("Employee Address:" + emp.Address);
                    Console.WriteLine("===============Orgnizations=================");
                    foreach (EmployeeOrganization employeeOrganizations in emp.EmployeeOrganizations)
                    {
                        Console.WriteLine("Employee Organization  :" + employeeOrganizations.OrganizationName);
                    }
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine(" Record not Found with Id :");
            }
        }
        public void DeleteEmployee(int EmpId)
        {
            var delEmp = DbContextFile.Employees.Where(emp => emp.Id == EmpId).Include(e => e.EmployeeOrganizations).First();
            if (delEmp != null)
            {
                DbContextFile.Employees.Remove(delEmp);
                delEmp.EmployeeOrganizations.Clear();
                DbContextFile.SaveChanges();
            }
            else
            {
                Console.WriteLine("No Record Found With This Id : " + EmpId);
            }
        }
        public void UpdateEmployeeAndOrgnization(int empId, string empname, List<EmployeeOrganization> UpdateList)
        {
            var updateEmp = DbContextFile.Employees.Where(emp => emp.Id == empId).Include(e => e.EmployeeOrganizations).First();
            if (updateEmp != null)
            {
                updateEmp.Name = empname;
                updateEmp.EmployeeOrganizations = UpdateList;
                DbContextFile.Employees.Update(updateEmp);
                DbContextFile.SaveChanges();
            }
            else
            {
                Console.WriteLine(" No Record Exist With This Id " + empId);
            }
        }
        public void TheSecondWayToInsertEMP(List<EmployeeOrganization> orgainizationsList)
        {
            DbContextFile.EmployeeOrganizations.AddRange(orgainizationsList);
            DbContextFile.SaveChanges();
            Console.WriteLine("added");
        }
    }
}
