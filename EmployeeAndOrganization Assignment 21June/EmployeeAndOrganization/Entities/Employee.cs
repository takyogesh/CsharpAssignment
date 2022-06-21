using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAndOrganization.Entities
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }
        [Column(TypeName = "integer")]
        public int Age { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string? Address { get; set; }
        public ICollection<EmployeeOrganization> EmployeeOrganizations { get; set; }
    }
}
