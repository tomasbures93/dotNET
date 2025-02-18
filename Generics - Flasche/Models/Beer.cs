using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics___Flasche.Models
{
    internal class Beer : IGetrank
    {
        public string Pivovar {  get; set; }

        public Beer(string pivovar)
        {
            Pivovar = pivovar;
        }

        public void Ausgabe()
        {
            Console.WriteLine($"{this.GetType().Name}");
            Console.WriteLine($"Pivovar: {Pivovar}");
        }
    }
}
