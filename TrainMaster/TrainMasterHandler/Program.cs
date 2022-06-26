using TrainMaster;
using TrainMaster.Models;

namespace TrainMasterHandler
{
    class Program
    {
        public static void Main(string[] args)
        {
            CrudOpTrainMaster CRUDmanager = new CrudOpTrainMaster();
           /* List<TrainSchedule> trainSchedules = new List<TrainSchedule>();
            trainSchedules.Add(new TrainSchedule { TrainRunDays = "sunday" });
            Train obj1 = new Train()
            {
                TrainNo = 12010,
                TrainName = "Mangla Express",
                FromStation = "prabalgargh",
                ToStation = "panvel",
                JourneyStartTime = new TimeSpan(2, 30, 00),
                JourneyEndTime = new TimeSpan(6, 00, 00),
                TrainSchedules = trainSchedules
            };*/

           // CRUDmanager.AddTrains(obj1);
          //  CRUDmanager.AllTrainList();

           /* List<TrainSchedule> trainSchedules2 = new List<TrainSchedule>();
            trainSchedules2.Add(new TrainSchedule { TrainRunDays = "Fraiday" });
            Train obj2 = new Train
            {
                TrainNo = 01027,
                TrainName = "GKP Panvel Exp",
                FromStation = "GKP",
                ToStation = "Panvel",
                JourneyStartTime = new TimeSpan(2, 30, 00),
                JourneyEndTime = new TimeSpan(6, 00, 00),
                TrainSchedules = trainSchedules2
            };
            CRUDmanager.AddTrains(obj2);*/

            CRUDmanager.AllTrainList();

           // CRUDmanager.SearchTrain_From_to_station("GKP", "Panvel");

           //CRUDmanager.DeleteTrain(01027);


           CRUDmanager.TrainSearchByTarinNumberWithNumber(12010);

           // CRUDmanager.UpdateTrain(12010, obj1);

          //  CRUDmanager.TrainSearchByTarinNumberWithDay(12010);

            Console.ReadLine();
        }
    }
}