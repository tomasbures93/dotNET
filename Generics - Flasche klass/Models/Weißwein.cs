using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics___Flasche_klass.Models
{
    internal class Weißwein : Wein
    {
        public Weißwein(string herkunft) : base(herkunft)
        {
        }

        public override void Ausgabe()
        {
            Console.WriteLine(this.GetType().Name);
            Console.WriteLine(Herkunft);
        }
    }
}
