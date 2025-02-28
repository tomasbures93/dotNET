using Events___Beobachter_am_Fluss.Models.EventArgumente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events___Beobachter_am_Fluss.Models
{
    internal class Stadt
    {
        private string _name;

        public event EventHandler<FiredeptWarnungEventArgs> FiredeptWarnung;
        public string Name
        {
            get { return _name; }
        }

        public Stadt(string name)
        {
            _name = name;
        }

        public void FlussStand(object sender, FlussWarnungEventArgs e)
        {
            if (e.Wasserstand >= 0 && e.Wasserstand <= 8200)
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
                Console.WriteLine("******** WARNING *******");
                Console.WriteLine($"Message from: {sender.GetType().Name}");
                Console.WriteLine($"Message to: {this._name} | Message send to the Fire Department.");
                Console.WriteLine($"Time: {e.Zeitstempel}");
                Console.WriteLine($"River: {e.Name}");
                Console.WriteLine($"New waterlevel: {e.Wasserstand} mm");
                FiredeptWarnung?.Invoke(this, new FiredeptWarnungEventArgs("Water level to high - Build water barrier"));
            }
        }
    }
}
