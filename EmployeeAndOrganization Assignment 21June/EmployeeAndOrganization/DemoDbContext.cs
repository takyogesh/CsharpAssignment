using EmployeeAndOrganization.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAndOrganization
{
    public class DemoDbContext :DbContext
    {
        public DemoDbContext() { }

        public DbSet<Employee> Employees { set; get; }
        public DbSet<EmployeeOrganization> EmployeeOrganizations { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-00LQG0A;Database=EmployeeAndOrganizationData;Trusted_Connection=True;");
        }
    }
}