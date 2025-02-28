using Events___Beobachter_am_Fluss.Models.EventArgumente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events___Beobachter_am_Fluss.Models
{
    internal class PoliceDepartment
    {
        private string _name;

        public string Name { get { return _name; } }

        public PoliceDepartment(string name)
        {
            _name = name;
        }

        public void PoliceWarnung(object sender, PoliceWarnungEventArgs e)
        {
            Console.WriteLine($"******** Cops *************");
            Console.WriteLine($"Message from: {sender.GetType().Name}");
            Console.WriteLine($"Incoming message: {e.Message}");
            Console.WriteLine($"Sendet: {e.Zeit}");
        }
    }
}
