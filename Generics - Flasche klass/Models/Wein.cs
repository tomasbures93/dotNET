using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics___Flasche_klass.Models
{
    abstract class Wein : IGetraenk
    {
        public string Herkunft { get; }

        public Wein(string herkunft)
        {
            Herkunft = herkunft;
        }

        public abstract void Ausgabe();
    }
}
