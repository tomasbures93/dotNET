using System.Text.RegularExpressions;

namespace Collections___Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Datei einlesen
            string pfad = @"C:\Users\ITA7-TN01\Desktop\frosch.txt";
            FileStream stream = new FileStream(pfad, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(stream);
            string text = sr.ReadToEnd();
            sr.Close();

            // split auf worter
            string[] splittext = text.Split(' ');

            // Sonderzeichen weg
            char[] sonderzeichen = { '.', ',', '?', '!', '«', '»', ':', '\n', '\r' };
            for (int i = 0; i < splittext.Length; i++)
            {
                splittext[i] = splittext[i].ToLower();
                foreach (char c in sonderzeichen)
                {
                    splittext[i] = splittext[i].Replace(c.ToString(), "");
                }
            }

            // Dictionary erstellen Key - Wort .... Value - zähler für heufigkeit
            Dictionary<string, int> heufigkeit = new Dictionary<string, int>();
            foreach (string wort in splittext)
            {
                if (heufigkeit.ContainsKey(wort))
                {
                    heufigkeit[wort]++;                 // nimmt das wort und speicher es am Key ... und macht ++ mit Value
                } else
                {           
                    heufigkeit[wort] = 1;               // wort auf Key speicher und dann Value auf 1
                }
            }

            // Ein SortedDictionary speichert die Einträge automatisch in aufsteigender Reihenfolge der Schlüssel.
            SortedDictionary<string, int> sortedDicHeufigkeit = new SortedDictionary<string, int>(heufigkeit);
            foreach(var pair in sortedDicHeufigkeit)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }

            //saving in file
            pfad = @"C:\Users\ITA7-TN01\Desktop\save.txt";
            try
            {
                FileStream saving = new FileStream(pfad,FileMode.Open,FileAccess.Write);
                StreamWriter write = new StreamWriter(saving);
                foreach(var pair in sortedDicHeufigkeit)
                {
                    write.WriteLine($"{pair.Key} - {pair.Value}");
                }
                write.Close();
                Console.WriteLine("\n\n\n");
                Console.WriteLine($"File Saved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n\n");
                Console.WriteLine($"Error - {ex.Message}");
            }
        }
    }
}
