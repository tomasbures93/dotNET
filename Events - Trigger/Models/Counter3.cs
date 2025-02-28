using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Events___Trigger.Models
{
    internal class Counter3
    {
        private int _counter;

        private Func<int, bool> prufMethode;
        private Action<int> zahlerErreicht;

        public Counter3(Func<int, bool> prufMethode, Action<int> action)
        {
            this.prufMethode = prufMethode;
            zahlerErreicht += action;
        }

        public void ZahlerstandErhohen(int x)
        {
            _counter += x;
            if (prufMethode(_counter))
            {
                zahlerErreicht?.Invoke(_counter);
            }
        }

        public void Clear() => _counter = 0;

        public void Print() => Console.WriteLine(_counter);
    }
}
