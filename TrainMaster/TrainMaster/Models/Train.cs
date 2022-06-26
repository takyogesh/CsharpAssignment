using System;
using System.Collections.Generic;

namespace TrainMaster.Models
{
    public partial class Train
    {
        public Train()
        {
            TrainSchedules = new HashSet<TrainSchedule>();
        }

        public int TrainNo { get; set; }
        public string? TrainName { get; set; }
        public string? FromStation { get; set; }
        public string? ToStation { get; set; }
        public TimeSpan? JourneyStartTime { get; set; }
        public TimeSpan? JourneyEndTime { get; set; }

        public virtual ICollection<TrainSchedule> TrainSchedules { get; set; }
        public override string ToString()
        {
            return "ID : " + TrainNo + " Name : " + TrainName + " Address : " + FromStation + " " + ToStation + "";
        }
    }
}
