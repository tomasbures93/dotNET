namespace LINQ___Aggregation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 22, 12, 16, 18, 11, 19, 13 };

            // 1.	Die Summe aller Werte im Array 
            var summe = numbers.Sum();
            Console.WriteLine(summe);
            
            // 2.	Die kleinste Zahl
            var min = numbers.Min();
            Console.WriteLine(min);
            
            // 3.	Die größte Zahl
            var max = numbers.Max();
            Console.WriteLine(max);

            // 4.	Den Durchschnittswert
            var durchschnitt = numbers.Average();
            Console.WriteLine(durchschnitt);

            // 5.	Die kleinste gerade Zahl
            var mingerade = numbers.Where(number => number % 2 == 0).Min();
            Console.WriteLine(mingerade);

            //6.Die größte ungerade Zahl
            var maxungerade = numbers.Where(number => number % 2 != 0).Max();
            Console.WriteLine(maxungerade);

            // 7.	Die Summe aller geraden Zahlen
            var summegerade = numbers.Where(number => number % 2 == 0).Sum();
            Console.WriteLine(summegerade);

            // 8.	Den Durchschnittswert aller ungeraden Zahlen
            var durchschnittungerade = numbers.Where(number => number % 2 != 0).Average();
            Console.WriteLine(durchschnittungerade);
        }
    }
}
