using Events___Beobachter_am_Fluss.Models.EventArgumente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events___Beobachter_am_Fluss.Models
{
    internal class Fluss
    {
        private string _name;
        private double _wasserstand;
        public event EventHandler<FlussWarnungEventArgs> FlussStand;

        public Fluss(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Wasserstand
        {
            get { return _wasserstand; }
            set 
            {
                if(value >= 100 && value <= 10000)
                {
                    _wasserstand = value;
                    FlussStand?.Invoke(this, new FlussWarnungEventArgs(Name, value));
                }
            }
        }
    }
}
