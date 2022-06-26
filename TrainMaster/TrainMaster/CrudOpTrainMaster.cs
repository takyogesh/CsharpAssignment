using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainMaster.Models;

namespace TrainMaster
{
    public class CrudOpTrainMaster
    {


        TrainMasterDFContext? trainMasterContext;
        public CrudOpTrainMaster()
        {
            trainMasterContext = new TrainMasterDFContext();

        }
        public void AllTrainList()
        {
            var alltrn = trainMasterContext.Trains.Include(d => d.TrainSchedules).ToList();
            if (alltrn.Count > 0)
            {
                foreach (var train in alltrn)
                {
                    Console.WriteLine(train);
                    Console.WriteLine("Train Avilable on ");
                    foreach (var trainSchedule in train.TrainSchedules)
                    {
                        Console.WriteLine(trainSchedule);
                    }
                    Console.WriteLine();
                }
            }
        }
        public void AddTrains(Train train)
        {
            trainMasterContext.Trains.Add(train);
            trainMasterContext.SaveChanges();
            Console.WriteLine("Train Addes Successfully");
        }
        public void UpdateTrain(int TrainNumber, Train train)
        {
            var trn = trainMasterContext.Trains.Where(tr => tr.TrainNo == TrainNumber).FirstOrDefault();
            if (trn != null)
            {
                trn.TrainName = train.TrainName;
                trn.TrainNo = train.TrainNo;
                trn.FromStation = train.FromStation;
                trn.ToStation = train.ToStation;
                trn.JourneyStartTime = train.JourneyStartTime;
                trn.JourneyEndTime = train.JourneyEndTime;
                trainMasterContext.Trains.Update(trn);
                trainMasterContext.SaveChanges();
                Console.WriteLine("Update Successfully...");
            }
            else
                Console.WriteLine(" Train Not Found ");
        }
        public void DeleteTrain(int TrainNumber)
        {
            var trn = trainMasterContext.Trains.Where(tr => tr.TrainNo == TrainNumber).FirstOrDefault();

            if (trn != null)
            {
                trainMasterContext.Trains.Remove(trn);
                trainMasterContext.SaveChanges();
                Console.WriteLine("Train Delted With Number :" + TrainNumber);
            }
            else
            {
                Console.WriteLine(" Train Not Found ");
            }
        }
        public void TrainSearchByNumber(int Trainnumber)
        {
            var trn = trainMasterContext.Trains.Where(tr => tr.TrainNo == Trainnumber).FirstOrDefault();
            if (trn != null)
            {
                Console.WriteLine(trn);
            }
            else
                Console.WriteLine(" Train Not Found ");

        }
        public void SearchTrain_From_to_station(string from, string to)
        {
            var trn = trainMasterContext.Trains.Where(tr => tr.FromStation == from && tr.ToStation == to).ToList();
            if (trn != null)
            {
                foreach (var train in trn)
                {
                    Console.WriteLine(train);
                }
            }
            else
                Console.WriteLine("No tarins Available...");
        }
        public void TrainSearchByTarinNumberWithNumber(int Trainnumber)
        {
            var train = trainMasterContext.Trains.Where(tr => tr.TrainNo == Trainnumber).Include(d => d.TrainSchedules).FirstOrDefault();
            if (train != null)
            {
                Console.WriteLine(train);
                Console.WriteLine("train Available Days");
                foreach (var trainSchedule in train.TrainSchedules)
                {
                    Console.WriteLine(trainSchedule);
                }
            }
            else
            {
                Console.WriteLine(" Train Not Found ");
            }

        }
    }
}
