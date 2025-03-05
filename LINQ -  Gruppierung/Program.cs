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
            var anfang = numbers.GroupBy(number => number[0]).
                        Select(group => $"{group.Key}: {string.Join(", ", group)}");
            Console.WriteLine(string.Join("\n", anfang));

            Console.WriteLine();

            // 2.	Gruppieren Sie die Worte im obigen Array nach der Länge
            var lange = numbers.GroupBy(number => number.Length).
                        Select(group => $"{group.Key}: {string.Join(",", group)}").
                        OrderBy(group => group);
            Console.WriteLine(string.Join("\n", lange));

            Console.WriteLine();

            // 3.	Gruppieren Sie die Worte im obigen Array nach dem Anfangsbuchstaben und der Länge
            var anfangundlange = numbers.GroupBy(number => number[0], number => number.Length).
                                    Select(group => $"{group.Key}: {string.Join(",", group.ToString())}");
            Console.WriteLine(string.Join("\n", anfangundlange));
        }
    }
}
