using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Threading___Dateien_Lesen
{
    internal class Program
    {
        static string pfad = @"C:\Users\ITA7-TN01\Desktop\Texte";
        static List<string> dateien = new List<string>();
        static void Main(string[] args)
        {
            DateienLaden();

            Console.WriteLine($"\tDateien in {pfad}\n");
            foreach (string list in dateien)
            {
                Console.WriteLine("\t" + list);
            }
            Console.WriteLine();

            List<Task> tasks = new List<Task>();
            foreach (string datei in dateien)
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    Heufigkeit(Path.Combine(pfad, datei));
                    Console.WriteLine($"\tTask for {datei} done");
                });
                tasks.Add(task);
            }
            Console.WriteLine();
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("\n\tAll done");
        }

        private static void Heufigkeit(string datei)
        {
            Dictionary<char, int> alphabet = new Dictionary<char, int>();
            using (StreamReader sr = new StreamReader(datei))
            {
                string line;
                Console.WriteLine($"\t{datei} werde bearbeitet.");

                while ((line = sr.ReadLine()) != null)
                {
                    foreach (char c in line)
                    {
                        if (alphabet.ContainsKey(c))
                        {
                            bool value = alphabet.TryGetValue(c, out int nummer);
                            alphabet[c] = nummer + 1;
                        }
                        else
                        {
                            alphabet.Add(c, 1);
                        }
                    }
                }
            }
            var sortedDic = alphabet.OrderBy(k => k.Key).ToDictionary(k => k.Key, k => k.Value);

            // Path.ChangeExtension(Path.Combine(path, filename), ".freq");   <--- das wurde besser
            string neueDatei = datei + ".freq";

            using (StreamWriter sr = new StreamWriter(neueDatei))
            {
                foreach(var buchstabel in sortedDic)
                {
                    sr.WriteLine($"{buchstabel.Key} : {buchstabel.Value}");
                }
            }
        }

        private static void DictionaryLesen(Dictionary<char, int> alphabet)
        {
            foreach (var d in alphabet)
            {
                Console.WriteLine(d.Key + ": " + d.Value);
            }
        }

        private static void DateienLaden()
        {
            DirectoryInfo DI = new DirectoryInfo(pfad);
            if (DI.Exists)
            {
                foreach (FileInfo fi in DI.GetFiles())
                {
                    dateien.Add(fi.Name);
                }
            }
            else
            {
                Console.WriteLine($"{pfad} does not exists!");
                Environment.Exit(0);
            }
        }
    }
}
