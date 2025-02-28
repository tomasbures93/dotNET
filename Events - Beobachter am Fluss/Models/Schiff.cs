using Events___Beobachter_am_Fluss.Models.EventArgumente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events___Beobachter_am_Fluss.Models
{
    internal class Schiff
    {
        private string _name;

        public Schiff(string name)
        {
            _name = name;
        }

        public void FlussStand(object sender, FlussWarnungEventArgs e)
        {
            if(e.Wasserstand < 250)
            {
                Console.WriteLine("******** WARNING *******");
                Console.WriteLine($"Message from: {sender.GetType().Name}");
                Console.WriteLine($"Message to: {this._name} | Please dont move!");
                Console.WriteLine($"Time: {e.Zeitstempel}");
                Console.WriteLine($"River: {e.Name}");
                Console.WriteLine($"New waterlevel: {e.Wasserstand} mm");
            }
            else if(e.Wasserstand >= 250 &&  e.Wasserstand <= 8000)
            {
                Console.WriteLine("******** MESSAGE *******");
                Console.WriteLine($"Message from: {sender.GetType().Name}");
                Console.WriteLine($"Message to: {this._name} | Free to go");
                Console.WriteLine($"Time: {e.Zeitstempel}");
                Console.WriteLine($"River: {e.Name}");
                Console.WriteLine($"New waterlevel {e.Wasserstand} mm");
            }
            else
            {
                Console.WriteLine("******** WARNING *******");
                Console.WriteLine($"Message from: {sender.GetType().Name}");
                Console.WriteLine($"Message to: {this._name} | Please return to the harbour!");
                Console.WriteLine($"Time: {e.Zeitstempel}");
                Console.WriteLine($"River: {e.Name}");
                Console.WriteLine($"New waterlevel: {e.Wasserstand} mm");
            }
        }
    }
}
