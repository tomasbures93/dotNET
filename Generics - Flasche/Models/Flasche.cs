using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics___Flasche.Models
{
    internal class Flasche<T> where T : IGetrank
    {
        private T _inhalt;
        public T Inhalt
        {
            get { return _inhalt; }
            set { _inhalt = value; }
        }

        public bool IstLeer()
        {
            return Object.Equals(_inhalt, default(T));
        }

        public void Fuellen(T inhalt)
        {
            _inhalt = inhalt;
        }

        public T Leeren()
        {
            T puffer = _inhalt;
            Inhalt = default;
            return puffer;
        }

        public void Ausgabe()
        {
            Inhalt.Ausgabe();
        }
    }
}
