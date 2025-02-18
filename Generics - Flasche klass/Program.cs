using Generics___Flasche_klass.Models;

namespace Generics___Flasche_klass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Flasche<Bier> bierFlasche = new Flasche<Bier>();
            Console.WriteLine(bierFlasche.IstLeer());
            bierFlasche.Fuellen(new Bier("Pils"));
            Console.WriteLine(bierFlasche.IstLeer());
            bierFlasche.Ausgabe();

            Flasche<Wein> weinFlasche = new Flasche<Wein>();
            Console.WriteLine(weinFlasche.IstLeer());
            weinFlasche.Fuellen(new Rotwein("Spanien"));
            Console.WriteLine(weinFlasche.IstLeer());
            weinFlasche.Ausgabe();
            weinFlasche.Leeren().Ausgabe();
            Console.WriteLine(weinFlasche.IstLeer());

            weinFlasche.Fuellen(new Weißwein("Italien"));
            weinFlasche.Ausgabe();
        }
    }
}
