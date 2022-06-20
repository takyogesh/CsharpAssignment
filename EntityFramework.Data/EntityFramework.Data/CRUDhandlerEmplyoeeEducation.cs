using EntityFramework.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Design;

namespace EntityFramework.Data
{
    public class CRUDhandlerEmplyoeeEducation
    {
        DemoDbContext context;
        public CRUDhandlerEmplyoeeEducation()
        {
            context = new DemoDbContext();
        }
        public void AddEducation(EmplyoeeEducation employeEducation)
        {
            context.EmployeeEducation.Add(employeEducation);
            context.SaveChanges();
            Console.WriteLine("done...");
        }
        public void DeleteEdu(int id)
        {
            var deleteeducation = context.EmployeeEducation.Where(edu => edu.ID == id).FirstOrDefault();
            if (deleteeducation != null)
            {
                context.EmployeeEducation.Remove(deleteeducation);
                context.SaveChanges();
                Console.WriteLine("Delete Education ");
            }
            else
            {
                Console.WriteLine("Data Not found To be Delete with Id= {0}", id);
            }
        }
        public void UpdateEdu(int EmployeeId, EmplyoeeEducation employeEducation)
        {
            var updateedu = context.EmployeeEducation.Where(edu => edu.ID == EmployeeId).FirstOrDefault();
            if (updateedu != null)
            {
                updateedu.CourseName = employeEducation.CourseName;
                updateedu.UniversityName = employeEducation.UniversityName;
                updateedu.MarksPercentage = employeEducation.MarksPercentage;
                updateedu.PassingYear = employeEducation.PassingYear;
                context.EmployeeEducation.Update(updateedu);
                context.SaveChanges();
                Console.WriteLine("Updated...");
            }
            else
            {
                Console.WriteLine(" No record Found With ID= {0}", EmployeeId);
            }
        }
        public List<EmplyoeeEducation> ShowAllEmpEducation()
        {
            var listEdu = context.EmployeeEducation.ToList();
            return listEdu;
        }
    }
}
