using System;
using System.Collections.Generic;

namespace TrainMaster.Models
{
    public partial class TrainSchedule
    {
        public int Id { get; set; }
        public string? TrainRunDays { get; set; }
        public int? TrainNo { get; set; }

        public virtual Train? TrainNoNavigation { get; set; }
        public override string ToString()
        {
            return "TrainRunOnDays : " + TrainRunDays + " ";
        }
    }
}
