using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Events___Trigger.Models
{
    public delegate bool Bedingung(int counter);
    public delegate void Aktion(int counter);
    internal class Counter2
    {
        private int _counter;



        public event Aktion zahlerErreicht;

        private Bedingung prufMethode;

        public Counter2(Bedingung prufMethode, Aktion aktion)
        {
            this.prufMethode = prufMethode;
            zahlerErreicht += aktion;
        }

        public void ZahlerstandErhohen(int x)
        {
            _counter += x;
            if (prufMethode(_counter) && zahlerErreicht != null)
            {
                zahlerErreicht(_counter);
            }
        }

        public void Clear() => _counter = 0;

        public void Print() => Console.WriteLine($"{_counter}");

        
    }
}
