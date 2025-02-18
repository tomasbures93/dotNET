using Generics___Flasche.Models;

namespace Generics___Flasche
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Flasche<Beer> beer = new Flasche<Beer>();
            Console.WriteLine(beer.IstLeer());
            beer.Fuellen(new Beer("Pils"));
            Console.WriteLine(beer.IstLeer());
            //beer.Ausgabe();

            Flasche<Rotwein> Monchery = new Flasche<Rotwein>();
            Console.WriteLine(Monchery.IstLeer());
            Monchery.Fuellen(new Rotwein("CZ"));
            Console.WriteLine(Monchery.IstLeer());
            //Monchery.Ausgabe();
        }
    }
}
