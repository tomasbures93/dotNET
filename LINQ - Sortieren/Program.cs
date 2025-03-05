namespace LINQ___Sortieren
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 22, 12, 16, 18, 11, 19, 13 };

            // 1.	Geben Sie das obige Array aufsteigend sortiert aus
            var aufsteigend = numbers.OrderBy(x => x);
            Console.WriteLine(string.Join(',', aufsteigend));

            Console.WriteLine();

            // 2.	Geben Sie das obige Array absteigend sortiert aus
            var absteigend = numbers.OrderByDescending(x => x);
            Console.WriteLine(string.Join(',', absteigend));

            Console.WriteLine();

            // 3.	Geben Sie aus dem obigen Array alle graden Zahlen aufsteigend sortiert aus
            var gradeaufsteigend = numbers
                                    .Where(number => number % 2 == 0)
                                    .OrderBy(number => number);
            Console.WriteLine(string.Join(',', gradeaufsteigend));

            Console.WriteLine();

            string[] numbers2 =
                { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",
                "nine", "ten", "eleven", "twelve", "thirteen", "fourteen" };

            // 1.	Geben Sie das obige Array nach der Länge der Worte aufsteigend sortiert aus
            var langeaufsteigend = numbers2.OrderBy(number => number.Length);
            Console.WriteLine(string.Join(',', langeaufsteigend));

            var langeaufsteigend2 = from number in numbers2
                                    orderby number.Length
                                    select number;
            Console.WriteLine(string.Join(',', langeaufsteigend2));

            Console.WriteLine();

            // 2.	Geben Sie das obige Array nach der Länge der Worte aufsteigend sortiert aus, bei gleicher Länge soll alphabetisch absteigend sortiert werden
            var aufsteigalpha = numbers2
                                .OrderBy(number => number.Length)
                                .ThenByDescending(number => number);
            Console.WriteLine(string.Join(',', aufsteigalpha));

            var aufsteigalpha2 = from number in numbers2
                                 orderby number.Length, number descending
                                 select number;
            Console.WriteLine(string.Join(',', aufsteigalpha2));

            Console.WriteLine();
            // 3.	Drehen Sie die Reihenfolge der Elemente im Array um
            var anderereinfolge = numbers2.Reverse();
            Console.WriteLine(string.Join(',', anderereinfolge));

            var anderereinfolge2 = from number in numbers2.Reverse()
                                   select number;
            Console.WriteLine(string.Join(',', anderereinfolge2));

            Console.WriteLine();

            // Erstellen Sie ein DirectoryInfo-Objekt für ein Verzeichnis Ihrer Wahl. 
            DirectoryInfo info = new DirectoryInfo(@"C:\Users\ITA7-TN01\Desktop\Linux");

            // 4.	Listen Sie alle Dateien in dem Verzeichnis, absteigend nach Namen sortiert auf
            List<string> files = new List<string>();
            foreach (var file in info.GetFiles())
            {
                files.Add(file.Name);
            }

            var absteigsort = files.OrderByDescending(files => files);
            Console.WriteLine(string.Join("\n", absteigsort));

            Console.WriteLine();

            // 5.Listen Sie alle Dateien in dem Verzeichnis, nach Größe aufsteigend sortiert auf
            List<(long, string)> filegrose = new List<(long,string)>();
            foreach(var file in info.GetFiles())
            {
                filegrose.Add((file.Length, file.Name));
            }
            var aufsteigdatei = filegrose.OrderBy(number => number);
            Console.WriteLine(string.Join("\n", aufsteigdatei));

            Console.WriteLine();
            var aufsteigdatei2 = from grose in filegrose
                                 orderby grose
                                 select grose;
            Console.WriteLine(string.Join("\n", aufsteigdatei2));

            Console.WriteLine();

            // 6.	Listen Sie alle Dateien in dem Verzeichnis, nach dem Datum des letzten Zugriffs auf, jüngste Dateien zuerst
            DirectoryInfo info2 = new DirectoryInfo(@"C:\Users\ITA7-TN01\Desktop\Suche");
            List<(DateTime, string)> fileletztezugriff = new List<(DateTime, string)>();
            foreach(var file in info2.GetFiles())
            {
                fileletztezugriff.Add((file.LastAccessTime, file.Name));
            }
            var datumletzte = fileletztezugriff.OrderByDescending(file => file.Item1).ThenBy(file => file.Item2);
            Console.WriteLine(string.Join("\n", datumletzte));

            Console.WriteLine();

            var datumlezte2 = from item in fileletztezugriff
                              orderby item.Item1 descending, item.Item2 descending
                              select item;
            Console.WriteLine(string.Join("\n", datumlezte2));
        }
    }
}
