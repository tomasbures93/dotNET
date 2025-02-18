using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics___Flasche.Models
{
    internal class Weiswein : IGetrank
    {
        public string Herkunft {  get; set; }

        public Weiswein(string herkunft)
        {
            Herkunft = herkunft;
        }

        public void Ausgabe()
        {
            Console.WriteLine(this.GetType().Name);
            Console.WriteLine($"Herkunft: {Herkunft}");
        }
    }
}
