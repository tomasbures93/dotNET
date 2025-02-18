using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics___Flasche.Models
{
    internal class Rotwein : IGetrank
    {
        public string Herkunft {  get; set; }

        public Rotwein(string herkunft) 
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
