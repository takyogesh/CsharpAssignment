using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAndOrganization.Entities
{
    public class EmployeeOrganization
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string OrganizationName { get; set; }
        public Employee Employee { get; set; }

    }
}
