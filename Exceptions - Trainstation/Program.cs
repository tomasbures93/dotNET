using Exceptions___Trainstation.Models;

namespace Exceptions___Trainstation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Train train1 = new Train(1, 6);
            Train train2 = new Train(2, 10);
            Train train3 = new Train(3, 5);

            RailwayStation station = new RailwayStation("Bochum HbF", 15);

            try
            {
                station.TrainGo();
            }
            catch (RailwayStationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                station.AddTrain(train1);
            } 
            catch(RailwayStationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                station.AddTrain(train2);
            }
            catch (RailwayStationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                station.AddTrain(train3);
            }
            catch (RailwayStationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                station.TrainGo();
            }
            catch (RailwayStationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                station.TrainGo();
            }
            catch (RailwayStationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                station.TrainGo();
            }
            catch (RailwayStationException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
