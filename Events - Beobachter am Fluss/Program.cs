using Events___Beobachter_am_Fluss.Models;

namespace Events___Beobachter_am_Fluss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fluss labe = new Fluss("Labe");

            Schiff titanic = new Schiff("Titanic");
            Klarwerk werk = new Klarwerk("We do nothing s.r.o");
            Stadt stadt = new Stadt("Mnichovo Hradiste");
            Firedept FDep = new Firedept("Mnichovo Hradiste FireDepartment");
            PoliceDepartment PDep = new PoliceDepartment("Cops MH");

            labe.FlussStand += titanic.FlussStand;
            labe.FlussStand += werk.FlussStand;
            labe.FlussStand += stadt.FlussStand;
            stadt.FiredeptWarnung += FDep.FiredeptWarnung;
            FDep.PoliceWarnung += PDep.PoliceWarnung;
            

            labe.Wasserstand = 100;
            Console.ReadKey();

            Console.Clear();
            labe.Wasserstand = 5000;
            Console.ReadKey();

            Console.Clear();
            labe.Wasserstand = 10000;
            Console.ReadKey();

            Console.Clear();
            labe.Wasserstand = 7000;
            Console.ReadKey();

            Console.Clear();
            labe.Wasserstand = 8250;
            Console.ReadKey();

            Console.Clear();
            labe.Wasserstand = 500;
        }
    }
}
