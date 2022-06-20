using Microsoft.EntityFrameworkCore;
using EntityFramework.Data.Entities;
namespace EntityFramework.Data
{
    class DemoDbContext : DbContext
    {
        public DemoDbContext()
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmplyoeeEducation> EmployeeEducation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-00LQG0A;Database=EmployeeData;Trusted_Connection=True;");

        }
    }
}
