
using TrainMaster;
using TrainMaster.Entities;

namespace TrainMasterHandler
{
    class Program
    {
        public static void Main(string[] args)
        {
            CRUDmanager CRUDmanager = new CRUDmanager();
            List<TrainSchedule> trainSchedules = new List<TrainSchedule>();
            trainSchedules.Add(new TrainSchedule { TrainRunDays = "sunday" });
            Train obj1 = new Train
            {
                TrainNo = 12010,
                TrainName = "Mangla Express",
                FromStation = "prabalgargh",
                ToStation = "panvel",
                JourneyStartTime = new TimeSpan(2, 30, 00),
                JourneyEndTime = new TimeSpan(6, 00, 00),
                trainSchedules = trainSchedules
            };

            CRUDmanager.AddTrains(obj1);

        List<TrainSchedule> trainSchedules2 = new List<TrainSchedule>();
            trainSchedules2.Add(new TrainSchedule { TrainRunDays = "Sunday" });
            trainSchedules2.Add(new TrainSchedule { TrainRunDays = "Fraiday" });
        Train obj2 = new Train
        {
            TrainNo = 01027,
            TrainName = "GKP Panvel Exp",
            FromStation = "GKP",
            ToStation = "Panvel",
            JourneyStartTime = new TimeSpan(2, 30, 00),
            JourneyEndTime = new TimeSpan(6, 00, 00),
            trainSchedules = trainSchedules2
        };
        CRUDmanager.AddTrains(obj2);

        CRUDmanager.SearchTrain_From_to_station("Bhusawal", "Delhi");

        CRUDmanager.DeleteTrain(01027);

        CRUDmanager.SearchTrain_From_to_station("Pune", "Patna");

        CRUDmanager.TrainSearchByTarinNumberWithDay(12010);

        CRUDmanager.UpdateTrain(12010, obj1);

        CRUDmanager.TrainSearchByTarinNumberWithDay(12010);

        Console.ReadLine();
        }
    }
}