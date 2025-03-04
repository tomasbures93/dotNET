using JSON___Verzeichnisinformationen.Models;
using System;
using System.Text.Json;

namespace JSON___Verzeichnisinformationen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo info = new DirectoryInfo(@"C:\Windows");
            List<DirInfo> listserial = new List<DirInfo>();

            // C:\Windows durchsuchen
            if (info.Exists)
            {
                DirectoryInfo[] dirs = info.GetDirectories("*");
                foreach (DirectoryInfo dir in dirs)
                {
                    try
                    {
                        Console.WriteLine($"{dir.FullName} | Angelegt {dir.CreationTime} | Anzahl SubDirectories {dir.GetDirectories().Length} | Anzahl dateien {dir.GetFiles().Length}");
                        listserial.Add(new DirInfo(dir.FullName, dir.CreationTime.ToString(), dir.GetDirectories().Length + dir.GetFiles().Length));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            } else
            {
                Console.WriteLine($"We have a problem. ");
            }
            Console.WriteLine("Liste erzeugt, möchtest du es sehen ?");
            Console.ReadKey();
            Console.WriteLine();

            ListAusgeben(listserial);
            Console.WriteLine("Möchtest du Data in .json datei speichern ?");
            Console.ReadKey();

            Console.WriteLine();

            // In JSON umwandeln und speichern
            string path = @"C:\Users\ITA7-TN01\Desktop\json.json";
            using (StreamWriter stream = new StreamWriter(path, true))
            {
                foreach (DirInfo dir in listserial)
                {
                    // AM BESTEN SPEICHER JEDER DATEN SATZT AUF NEUE ZEILE
                    // BEI AUSLESEN HABEN WIR WENIGER PROBLEME
                    DirInfo save = new DirInfo()
                    {
                        Name = dir.Name,
                        CreationTime = dir.CreationTime,
                        CountSub = dir.CountSub
                    };
                    string json = JsonSerializer.Serialize(save);
                    stream.WriteLine(json);
                }
            }
            Console.WriteLine("Möchtest du Data in .json wieder auslesen ?");
            Console.ReadKey();
            Console.WriteLine();

            List<DirInfo> listdese = new List<DirInfo>();
            // ZEILWEISE LESEN, WEIL DESERIALIZE WILL NUR EIN JSON DATEN SATZ
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    DirInfo data = JsonSerializer.Deserialize<DirInfo>(line);
                    listdese.Add(data);
                }
            }
            Console.WriteLine("Möchtest du neue liste anschauen ?");
            Console.ReadKey();
            Console.WriteLine();

            ListAusgeben(listdese);
            Console.ReadKey();
        }

        static void ListAusgeben(List<DirInfo> list)
        {
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("\tFolder\t\t\t    | Created\t\t   | Files");
            Console.WriteLine("-----------------------------------------------------------------------------");
            foreach (DirInfo dir in list)
            {
                Console.WriteLine(dir.ToString());
            }
            Console.WriteLine("-----------------------------------------------------------------------------");
        }
    }
}
