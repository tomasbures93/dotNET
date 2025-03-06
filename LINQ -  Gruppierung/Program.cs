using System.Diagnostics;
using System.Linq;
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

            // Version 2
            var anfangBuchstabelUndLange2 = numbers.GroupBy(number => new { FirstLetter = number[0], Length = number.Length });     // Erstellt Gruppen basierend auf dem ersten Buchstaben und der Länge des Wortes.        

            foreach(var item in anfangBuchstabelUndLange2.OrderBy(g => g.Key.Length).ThenBy(g => g.Key.FirstLetter))
            {
                Console.WriteLine($"Key: {item.Key.Length} , {item.Key.FirstLetter}");
                Console.WriteLine(string.Join(", ", item));
            }


            Console.WriteLine();

            // 1.	Geben Sie die Prozesse auf Ihrem System gruppiert nach der Anzahl der Threads aus
            Process[] process = Process.GetProcesses();
            var groupByThreads = process.GroupBy(g => g.Threads.Count)
                                .OrderBy(g => g.Key)
                                .Select(group => $"{group.Key} - {string.Join(", ", group.Select(g => g.ProcessName))}");
                                
            Console.WriteLine(string.Join("\n", groupByThreads));

            Console.WriteLine();

            // 2.	Geben Sie die Prozesse auf Ihrem System gruppiert nach der Anzahl der Module aus
            Process[] processe = Process.GetProcesses();
            var groupByModule = process.Select(g =>
                                    {
                                        try
                                        {
                                            return new { Process = g, ModuleCount = g.Modules.Count };
                                        }
                                        catch (Exception ex)
                                        {
                                            return new { Process = g, ModuleCount = -1 };
                                        }
                                    })
                                .GroupBy(g => g.ModuleCount)
                                .OrderBy(g => g.Key)
                                .Select(g => $"{g.Key} - {string.Join(", ", g.Select(p => p.Process.ProcessName))}");
                                

            Console.WriteLine(string.Join("\n", groupByModule));

            Console.WriteLine();

            // 3.	Geben Sie die Prozesse auf Ihrem System gruppiert nach der Anzahl der Module aus, in der Ausgabe sollen die Namen der Prozesse alphabetisch aufsteigend sortiert sein
            var groupByModuleAlphabetisch = process.Select(g =>
            {
                try
                {
                    return new { Process = g, ModuleCount = g.Modules.Count};
                }
                catch (Exception ex)
                {
                    return new { Process = g, ModuleCount = -1};            // Da wo wir haben kein zugriff
                }
            })
                .GroupBy(g => g.ModuleCount)
                .OrderBy(g => g.Key)
                .Select(g => $"{g.Key} - {string.Join(", ", g.Select(p => p.Process.ProcessName).OrderBy(n => n))}");

            Console.WriteLine(string.Join("\n", groupByModuleAlphabetisch));

            Console.WriteLine();

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
