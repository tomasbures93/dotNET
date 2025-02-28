using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events___Trigger.Models
{
    internal class CounterHighEventArgs : EventArgs
    {
        private int _zahl;

        public int Zahl { get { return _zahl; } }

        public CounterHighEventArgs(int zahl) { _zahl = zahl; }
    }
}
