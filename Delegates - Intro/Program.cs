namespace Delegates___Intro
{
    internal class Program
    {
        public delegate double MathOperationHandler(double x, double y);
        static void Main(string[] args)
        {
            MathOperationHandler operation;
            Dictionary<char, MathOperationHandler> liste = new Dictionary<char, MathOperationHandler>();
            liste.Add('+', delegate (double x, double y) { return x + y; });            // anonyme funktion
            liste.Add('-', delegate (double x, double y) { return x - y; });            // anonyme funktion

            int eins = 4;
            int zwei = 5;
            char c = '+';
            double erg = 0;

            erg = liste[c](eins, zwei);             // rufe delegat an
        }
    }
}
