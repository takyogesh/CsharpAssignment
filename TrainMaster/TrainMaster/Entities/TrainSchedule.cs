using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainMaster.Entities
{
    public class TrainSchedule
    {
        public string? TrainRunDays { get; set; }
        [Key]
        public int? TrainNo { get; set; }
        public virtual Train? Train { get; set; }

        public override string ToString()
        {
            return "TrainRunOnDays : " + TrainRunDays + " ";
        }
    }
}
