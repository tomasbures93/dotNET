using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events___Trigger.Models
{
    internal class Counter
    {
        private int _wert;

        public event EventHandler<CounterHighEventArgs> CounterHigh;
        public int Wert 
        {  
            get { return _wert; }
        }

        public Counter() => _wert = 0;

        public void ZahlerstandErhohen(int wert)
        {
            _wert += wert;
            if (_wert >= 1000)
            {
                CounterHigh?.Invoke(this, new CounterHighEventArgs(Wert));
            }
        }

        public void Clear() => _wert = 0;

        public void Print() => Console.WriteLine(Wert);

        public void EventCounter(object sender, CounterHighEventArgs e) => Console.WriteLine($"Zählerstand erreicht: {e.Zahl}");

    }
}
