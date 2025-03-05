using System.Xml.Linq;

namespace LINQ____Gruppierung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers =
                { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",
                "nine", "ten", "eleven", "twelve", "thirteen", "fourteen" };

            // 1.	Gruppieren Sie die Worte im obigen Array nach dem Anfangsbuchstaben
            var anfangBuchstabel = numbers.GroupBy(number => number[0]).
                        Select(group => $"{group.Key}: {string.Join(", ", group)}");
            Console.WriteLine(string.Join("\n", anfangBuchstabel));

            Console.WriteLine();

            // 2.	Gruppieren Sie die Worte im obigen Array nach der Länge
            var lange = numbers.GroupBy(number => number.Length).
                        Select(group => $"{group.Key}: {string.Join(",", group)}").
                        OrderBy(group => group);
            Console.WriteLine(string.Join("\n", lange));

            Console.WriteLine();

            // 3.	Gruppieren Sie die Worte im obigen Array nach dem Anfangsbuchstaben und der Länge
            var anfangBuchstabelUndLange = numbers.GroupBy(number => (number[0], number.Length)).     // Erstellt Gruppen basierend auf dem ersten Buchstaben und der Länge des Wortes.
                                    Select(group => $"{group.Key.Item1} {group.Key.Item2}: {string.Join(",", group)}");
            Console.WriteLine(string.Join("\n", anfangBuchstabelUndLange));

            int[] factorsOf300 = { 2, 2, 3, 5, 5 };
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            Console.WriteLine();
            //1.Welche einzelnen Faktoren sind in factorsOf300 vertreten?
            var singleElement = factorsOf300.Distinct();
            Console.WriteLine(string.Join(',', singleElement));
            Console.WriteLine();
           //2.Wie ist die Vereinigungsmenge der beiden Arrays numbersA und numbersB ?
           var unionSet = numbersA.Union(numbersB);
            Console.WriteLine(string.Join(',',unionSet));
            Console.WriteLine();

           //3.Haben die beiden Arrays numbersA und numbersB eine Schnittmenge ?
           var schnittmenge = numbersA.Intersect(numbersB);
            Console.WriteLine(string.Join(',', schnittmenge));
            Console.WriteLine();

           //4.Welche Elemente kommen nur in numbersB vor, aber nicht in numbersA ?
           var differenz = numbersB.Except(numbersA);
            Console.WriteLine(string.Join(',',differenz));
        }
    }
}
