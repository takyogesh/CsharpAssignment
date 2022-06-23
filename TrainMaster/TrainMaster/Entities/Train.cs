using System.ComponentModel.DataAnnotations;

namespace TrainMaster.Entities
{
    public class Train
    {
        public Train()
        {
            trainSchedules=new HashSet<TrainSchedule>();
        }
        [Key]
        public int TrainNo { get; set; }

        public string? TrainName { get; set; }

        public string? FromStation { get; set; }
        public string? ToStation { get; set; }
        public TimeSpan? JourneyStartTime { get; set; } //hr,min
        public TimeSpan? JourneyEndTime { get; set; }

        public ICollection<TrainSchedule>? trainSchedules { get; set; }
        public override string ToString()
        {
            return "ID : " + TrainNo + " Name : " + TrainName + " Address : " + FromStation + " " + ToStation + "";
        }
    }
}