using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events___Beobachter_am_Fluss.Models.EventArgumente
{
    internal class FlussWarnungEventArgs : System.EventArgs
    {
        private string _name;
        private double _wasserstand;
        private string _zeitstempel;

        public string Name
        {
            get { return _name; }
        }

        public double Wasserstand
        {
            get { return _wasserstand; }
        }

        public string Zeitstempel
        {
            get { return _zeitstempel; }
        }

        public FlussWarnungEventArgs(string name, double wasserstand)
        {
            _name = name;
            _wasserstand = wasserstand;
            _zeitstempel = DateTime.Now.ToLongTimeString();
        }
    }
}
