using System.Text.RegularExpressions;

namespace RegEx___Frosch_König
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> text = new List<string>(); 
            FileStream stream = new FileStream(@"C:\Users\ITA7-TN01\Desktop\dotNet_Desktop\03 - RegEx\frosch.txt", FileMode.Open, FileAccess.Read);
            StreamReader read = new StreamReader(stream);

            string line;
            while ((line = read.ReadLine()) != null)
            {
                text.Add(line);
            }
            read.Close();

            //Einmal inhalt anschauen
            foreach(string inhalt in text)
            {
                Console.WriteLine(inhalt);
            }


            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Alle Zeilen mit einem Umlaut (große und kleine Umlaute).\n");
            int count = 0;
            foreach(string inhalt in text)
            {
                count++;
                if(Regex.IsMatch(inhalt, @"[äöüÄÖÜ]"))
                {
                    Console.WriteLine($"Line {count} - {inhalt}");
                }
            }

            Console.ReadKey();
            Console.Clear();
            count = 0;
            Console.WriteLine(" Alle Zeilen in denen das Wort „der“ alleine steht (d.h. als einzelnes Wort).\n");
            foreach(string inhalt in text)
            {
                count++;
                if(Regex.IsMatch(inhalt, @"\bder\b"))
                {
                    Console.WriteLine($"Line {count} - {inhalt}");
                }
            }


            Console.ReadKey();
            Console.Clear();
            count = 0;
            Console.WriteLine("Alle Zeilen die mit einem großen Buchstaben beginnen.\n");
            foreach(string inhalt in text)
            {
                count++;
                if(Regex.IsMatch(inhalt, @"^[A-Z]"))
                {
                    Console.WriteLine($"Line {count} - {inhalt}");
                }
            }

            Console.ReadKey();
            Console.Clear();
            count = 0;
            Console.WriteLine("Alle Zeilen, in denen das Wort Frosch oder Froschkönig vorkommt.\n");
            foreach(string inhalt in text)
            {
                count++;
                if(Regex.IsMatch(inhalt, @"\bFrosch\b") || Regex.IsMatch(inhalt, @"\bFroschkönig\b"))
                {
                    Console.WriteLine($"Line {count} - {inhalt}");
                }
            }

            Console.ReadKey();
            Console.Clear();
            count = 0;
            Console.WriteLine("Alle Zeilen mit einem . (Punkt) am Ende der Zeile\n");
            foreach(string inhalt in text)
            {
                count++;
                if (Regex.IsMatch(inhalt, @"\.$"))
                {
                    Console.WriteLine($"Line {count} - {inhalt}");
                }
            }

            Console.ReadKey();
            Console.Clear();
            count = 0;
            Console.WriteLine("Alle Zeilen in den ein Wort mit ß am Ende des Wortes steht (daß, saß, heiß, usw.). \n");
            foreach (string inhalt in text)
            {
                count++;
                if(Regex.IsMatch(inhalt, @".*ß\b"))
                {
                    Console.WriteLine($"Line {count} - {inhalt}");
                }
            }

            Console.ReadKey();
            Console.Clear();
            count = 0;
            Console.WriteLine("Die Anzahl der leeren Zeilen im Dokument. Hinweis: Eine leere Zeile ist eine Zeile, bei der am Zeilenanfang das Zeilenende steht\n");
            foreach(string inhalt in text)
            {
                if(Regex.IsMatch(inhalt, @"^$"))
                {
                    count++;
                }
            }
            Console.WriteLine($"{count} - Zeilen");

            Console.ReadKey();
            Console.Clear();
            count = 0;
            Console.WriteLine("Alle Zeilen bei denen am Anfang der Zeile ein Wort mit genau 3 Buchstaben steht (und, der, sie, usw.). Es sollen große und kleine Wörter ausgeben werden.\r\n");
            foreach(string inhalt in text)
            {
                count++;
                if (Regex.IsMatch(inhalt, @"^[A-Za-z]{3}\b"))
                {
                    Console.WriteLine($"Line {count} - {inhalt}");
                }
            }
            Console.ReadKey();
            Console.Clear();
            count = 0;
            Console.WriteLine("Alle Zeilen bei denen am Anfang der Zeile ein Wort mit genau 3 Buchstaben steht (und, der, sie, usw.). Es sollen große und kleine Wörter ausgeben werden.\r\n");
            foreach (string inhalt in text)
            {
                count++;
                if (Regex.IsMatch(inhalt, @"^[A-Za-z]{3}\b"))
                {
                    Match m = Regex.Match(inhalt, @"^[A-Za-z]{3}\b");
                    Console.WriteLine($"Line {count} - {m.Groups[0].Value}");
                }
            }

            Console.ReadKey();
            Console.Clear();
            count = 0;
            Console.WriteLine("Alle Zeilen die einen bestimmten Artikel enthalten (der, die, das). ");
            foreach (string inhalt in text)
            {
                count++;
                if (Regex.IsMatch(inhalt, @"\bder\b") || Regex.IsMatch(inhalt, @"\bdie\b") || Regex.IsMatch(inhalt, @"\bdas\b"))
                {
                    Console.WriteLine($"Line {count} - {inhalt}");
                }
            }

        }
    }
}
