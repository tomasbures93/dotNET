using Events___Beobachter_am_Fluss.Models.EventArgumente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events___Beobachter_am_Fluss.Models
{
    internal class Firedept
    {
        private string _name;

        public event EventHandler<PoliceWarnungEventArgs> PoliceWarnung;
        public string Name
        {
            get { return _name; }
        }

        public Firedept(string name) {
            _name = name;
        }

        public void FiredeptWarnung(object sender, FiredeptWarnungEventArgs e)
        {
            Console.WriteLine($"******** FireDep *************");
            Console.WriteLine($"Message from: {sender.GetType().Name}");
            Console.WriteLine($"Incoming message: {e.Message}");
            Console.WriteLine($"Sendet: {e.Zeitstempel}");
            PoliceWarnung?.Invoke(this, new PoliceWarnungEventArgs("Protect the Fire Department !!"));
        }
    }
}
