using System.Net;

namespace Stream___FileSystemWatcher
{
    internal class Program
    {
        static string ordner = @"C:\Users\ITA7-TN01\Desktop\Suche";
        static int counter = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Program start - Verzeichniss beobachtung.");
            Console.WriteLine($"{ordner} wird beobachtet !!");

            using FileSystemWatcher watcher = new FileSystemWatcher(ordner);

            // Was für enderungen wir beobachten
            watcher.NotifyFilter = NotifyFilters.Attributes         // Überwacht Änderungen an den Dateiattributen (z. B. "Schreibgeschützt", "Versteckt" usw.).
                                 | NotifyFilters.CreationTime       // Überwacht Änderungen an der Erstellungszeit einer Datei oder eines Verzeichnisses.
                                 | NotifyFilters.DirectoryName      // Überwacht Änderungen am Namen eines Verzeichnisses.
                                 | NotifyFilters.FileName           // Überwacht Änderungen am Namen einer Datei.
                                 | NotifyFilters.LastAccess         // Überwacht, wenn eine Datei oder ein Verzeichnis zuletzt geöffnet/gelesen wurde.
                                 | NotifyFilters.LastWrite          // Überwacht, wenn eine Datei oder ein Verzeichnis zuletzt geschrieben/bearbeitet wurde.
                                 | NotifyFilters.Security           // Überwacht Änderungen an der Sicherheits- bzw. Zugriffssteuerung (z. B. NTFS-Berechtigungen).
                                 | NotifyFilters.Size;              // Überwacht Änderungen an der Dateigröße.

            watcher.Filter = "*.lookup";        // Was wir wollen beobachten

            Console.WriteLine($"Looking for {watcher.Filter}");
            Console.WriteLine("-----------------------------------------");

            //watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            //watcher.Renamed += OnRenamed;
            //watcher.Deleted += OnDeleted;

            // begint beobachtung
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        //public static void OnDeleted(object sender, FileSystemEventArgs e)
        //{
        //    Console.WriteLine($"File {e.Name} has been deleted.");
        //}

        //public static void OnRenamed(object sender, FileSystemEventArgs e)
        //{
        //    Console.WriteLine($"File renamed | {e.Name} | {e.FullPath}");
        //}

        //public static void OnChanged(object sender, FileSystemEventArgs e)
        //{
        //    Console.WriteLine($"Neue datei hinzugefügt | {e.Name} | {e.FullPath}");
        //}

        public static void SaveResolved(List<string> resolved, string name)
        {
            string datei = @"\ergebnisse"+counter+".resolved";
            counter++;
            string pfad = ordner + datei;
            Console.WriteLine(pfad);
            if(resolved == null)
            {
                Console.WriteLine($"List leer!");
            } else
            {
                using (StreamWriter wf = new StreamWriter(pfad))
                {
                    foreach(string text in resolved)
                    {
                        wf.WriteLine(text);
                    }
                }
            }
            Console.WriteLine("***** Datei saving done");
        }

        public static void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("****");
            Console.WriteLine($"File Created | {e.Name} | {e.FullPath}");
            List<string> resolved = new List<string>();
            string pfad = e.FullPath;
            using (StreamReader sr = new StreamReader(e.FullPath))
            {
                string line;
                
                while ((line = sr.ReadLine()) != null)
                { 
                    Console.Write($"Processing IP: {line} | ");
                    try
                    {
                        IPHostEntry hostinfo = Dns.GetHostEntry(line);
                        Console.Write($"Host: {hostinfo.HostName} \n");
                        resolved.Add($"{hostinfo.HostName} - {line}");
                    }
                    catch (Exception ex)
                    {
                        Console.Write($"Host: Unknown IP \n");
                    }
                }
            }
            Console.WriteLine("****");
            SaveResolved(resolved, e.Name);
        }
    }
}
