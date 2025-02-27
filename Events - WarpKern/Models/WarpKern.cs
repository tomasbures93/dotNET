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
                if (TempEvent != null)
                {
                    _warpkernTemperatur = value;
                    if (value < 499)
                    {
                        TempEvent(this, new TemperaturEventArgs(value));
                    } else
                    {
                        TempEventFuckedup(this, new TemperaturEventArgs(value));
                    }

                }
            }
        }


    }
}
