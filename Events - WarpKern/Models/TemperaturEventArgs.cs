using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events___WarpKern.Models
{
    internal class TemperaturEventArgs : EventArgs
    {
        private double _temp;
        private string _zeitstempel;
        public double Temperatur
        {
            get { return _temp; }
        }

        public string Zeitstempel
        {
            get { return _zeitstempel; }
        }

        public TemperaturEventArgs(double temp)
        {
            this._temp = temp;
            _zeitstempel = DateTime.Now.ToLongTimeString();
        }
    }
}
