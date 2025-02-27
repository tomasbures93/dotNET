using Events___WarpKern.Models;

namespace Events___WarpKern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Diese objekt wurde Beobachtet
            WarpKern kern1 = new WarpKern();

            // Das sind der beobachter
            LocalFire feuerwear = new LocalFire(kern1);
            WarpkernConsole konsole = new WarpkernConsole(kern1);

            kern1.WarpKernTemperatur = 100;  // OK
            Console.ReadKey();
            kern1.WarpKernTemperatur = 300;  // Warnung
            Console.ReadKey();
            kern1.WarpKernTemperatur = 510;  // Kritisch
            Console.ReadKey();
        }
    }
}
