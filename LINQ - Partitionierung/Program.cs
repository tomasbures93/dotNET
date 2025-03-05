namespace LINQ___Partitionierung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 22, 12, 16, 18, 11, 19, 13 };

            // 1.	Ermitteln Sie die ersten 5 Elemente im Array
            var erstefunf = numbers.Take(5);
            Console.WriteLine(string.Join(',', erstefunf));

            // 2.	Ermitteln Sie die letzten 5 Elemente im Array
            var letztefunf = numbers.Skip(numbers.Length - 5);
            Console.WriteLine(string.Join(',', letztefunf));

            // 3.	Ermitteln Sie alle Elemente, bis auf die ersten und letzten drei Elemente 
            var erstundletzteweg = numbers.Skip(1).Take(numbers.Length - 2);
            Console.WriteLine(string.Join(',', erstundletzteweg));

            // 4.	Ermitteln Sie alle Elemente, beginnend vom ersten Element, die größer als 0 sind
            var vier = numbers.Where(x => x > 0);
            Console.WriteLine(string.Join(',', vier));

            // 5.	Ermitteln Sie alle Elemente, beginnend vom ersten Element, die nach der 12 im Array stehen
            var funf = numbers.SkipWhile(x => x != 12).Skip(1);
            Console.WriteLine(string.Join(',', funf));

            // Erstellen Sie ein DirectoryInfo-Objekt für ein Verzeichnis Ihrer Wahl. 
            // 7.	Listen Sie die fünf neuesten Dateien in dem Verzeichnis auf
            Console.WriteLine();
            DirectoryInfo info = new DirectoryInfo(@"C:\Users\ITA7-TN01\Desktop\Suche");
            List<(DateTime, string)> DateiList = new List<(DateTime, string)>();
            foreach(var dateiinfo in info.GetFiles())
            {
                DateiList.Add((dateiinfo.CreationTime, dateiinfo.Name));
            }
            var erstefunfdateien = DateiList.OrderByDescending(datum => datum.Item1).ThenBy(name => name.Item2).Take(5);
            Console.WriteLine(string.Join("\n", erstefunfdateien));

            // 8.	Listen Sie alle Dateien in dem Verzeichnis in „Seiten“ zu je 5 Dateien auf

            DirectoryInfo info2 = new DirectoryInfo(@"C:\Users\ITA7-TN01\Desktop\Linux");
            // ???
        }
    }
}
