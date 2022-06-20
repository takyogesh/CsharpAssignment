using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Data.Entities
{
    public class EmplyoeeEducation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]

        public int ID { get; set; }

        public string? CourseName { get; set; }

        public string? UniversityName { get; set; }

        public int PassingYear { get; set; }

        public int MarksPercentage { get; set; }
        public override string ToString()
        {
            return "ID : " + ID + " CourseName : " + CourseName + " UniversityName : " + UniversityName + " PassingYear : " + PassingYear + " MarksPercentage : " + MarksPercentage + "";
        }
    }
}
