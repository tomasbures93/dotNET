using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions___Trainstation.Models
{
    internal class RailwayStation
    {
        private string _name;
        private int _maxWaggons;
        private List<Train> trains;

        public string Name 
        { 
            get { return _name; }
            set { _name = value; }
        }    

        public int MaxWaggons
        {
            get { return _maxWaggons; }
            private set { _maxWaggons = value; }
        }

        public RailwayStation(string name, int maxWaggons)
        {
            _name = name;
            _maxWaggons = maxWaggons;
            trains = new List<Train>();
        }

        public void AddTrain(Train train)
        {
            if((Occupancy() + train.Waggons) > MaxWaggons)
            {
                throw new RailwayStationException($"Train {train.ZugNummer} cant be added to the railwaystation.");
            }
            else
            {
                trains.Add(train);
                Console.WriteLine($"Train {train.ZugNummer} has been added to the railwaystation.");
            }
        }

        public void ShowTrains()
        {
            foreach(Train train in trains)
            {
                Console.WriteLine(train.ZugNummer);
            }
        }

        private int Occupancy()
        {
            int occu = 0;
            foreach (Train train in trains)
            {
                occu += train.Waggons;
            }
            return occu;
        } 

        public void TrainGo() {
            int count = trains.Count;
            if(count == 0)
            {
                throw new RailwayStationException("No trains in railwaystation.");
            }
            else
            {
                Console.WriteLine($"Train {trains[0].ZugNummer} left the station.");
                trains.RemoveAt(0);
            }
        }
    }
}
