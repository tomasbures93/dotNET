using Events___Beobachter_am_Fluss.Models.EventArgumente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events___Beobachter_am_Fluss.Models
{
    internal class Klarwerk
    {
        private string _name;

        public string Name
        {
            get { return _name; }
        }

        public Klarwerk(string name)
        {
            _name = name;
        }

        public void FlussStand(object sender, FlussWarnungEventArgs e)
        {
            if (e.Wasserstand >= 0 && e.Wasserstand < 3000)
            {
                Console.WriteLine("******** MESSAGE *******");
                Console.WriteLine($"Message from: {sender.GetType().Name}");
                Console.WriteLine($"Message to: {this._name} | Lets gooooo ... do something!");
                Console.WriteLine($"Time: {e.Zeitstempel}");
                Console.WriteLine($"River: {e.Name}");
                Console.WriteLine($"New waterlevel: {e.Wasserstand} mm");
            }
            else if (e.Wasserstand >= 3000 && e.Wasserstand < 8000)
            {
                Console.WriteLine("******** MESSAGE *******");
                Console.WriteLine($"Message from: {sender.GetType().Name}");
                Console.WriteLine($"Message to: {this._name} | Everything is fine!");
                Console.WriteLine($"Time: {e.Zeitstempel}");
                Console.WriteLine($"River: {e.Name}");
                Console.WriteLine($"New waterlevel: {e.Wasserstand} mm");
            }
            else
            {
                Console.WriteLine("******** Warning *******");
                Console.WriteLine($"Message from: {sender.GetType().Name}");
                Console.WriteLine($"Message to: {this._name} | Stop the Production!");
                Console.WriteLine($"Time: {e.Zeitstempel}");
                Console.WriteLine($"River: {e.Name}");
                Console.WriteLine($"New waterlevel: {e.Wasserstand} mm");
            }
        }
    }
}
