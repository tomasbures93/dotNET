using System.Diagnostics;

namespace Threads___PI_berechnen
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(Math.PI);

            double pi = 0;
            const int anzahlAufrufe = 12;
            Stopwatch sw = new Stopwatch();
            List<Task<double>> tasks = new List<Task<double>>();

            sw.Start();

            for (int i = 1; i < anzahlAufrufe + 1; i++)
            {
                Task<double> task = Task<double>.Factory.StartNew(() =>
                {
                   return PI_Berechnung(i, anzahlAufrufe);
                });
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());
            for (int i = 0; i < tasks.Count; i++)
            {
                pi += tasks[i].Result;
            }

            sw.Stop();

            Console.WriteLine(pi);

            Console.WriteLine("Dauer {0:N0} Millisekunden", sw.ElapsedMilliseconds);
        }

        // Nach John Machin (http://de.wikipedia.org/wiki/John_Machin)
        private static double PI_Berechnung(int startwert, int schrittweite)
        {
            const double durchlaeufe = 1_000_000_000;
            double x, y = 1 / durchlaeufe;
            double summe = 0;
            double pi;

            for (double i = startwert; i <= durchlaeufe; i += schrittweite)
            {
                x = y * (i - 0.5);
                summe += 4.0 / (1 + x * x);
            }

            pi = y * summe;

            return pi;
        }
    }
}
