using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Events___WarpKern.Models
{
    delegate void TemperaturEventHandler(object sender, TemperaturEventArgs e);

    internal class WarpKern
    {
        private double _warpkernTemperatur;
        public event TemperaturEventHandler TempEvent;
        public event TemperaturEventHandler TempEventFuckedup;
        public double WarpKernTemperatur 
        { 
            get 
            { return _warpkernTemperatur; }
            set
            {
                _warpkernTemperatur = value;
                if (TempEvent != null && TempEventFuckedup != null)
                {
                    if (value < 499)
                    {
                        TempEvent(this, new TemperaturEventArgs(value));
                        // geht auch mit TempEvent?.Invoke(this, new TemperaturEventArgs(value));       ? prüft ob es nicht null
                    }
                    else
                    {
                        TempEventFuckedup(this, new TemperaturEventArgs(value));
                    }

                }
            }
        }


    }
}
