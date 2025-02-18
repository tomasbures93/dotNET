using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics___Flasche_klass.Models
{
    class Bier : IGetraenk
    {
        public string Brauerei { get; }

        public Bier(string brauerei)
        {
            Brauerei = brauerei;
        }

        public void Ausgabe()
        {
            Console.WriteLine(this.GetType().Name);         
            Console.WriteLine(Brauerei);
        }
    }
}
