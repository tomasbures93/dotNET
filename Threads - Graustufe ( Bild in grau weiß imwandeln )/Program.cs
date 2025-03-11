using SkiaSharp;
using System.IO;

namespace Threads___Graustufe___Bild_in_grau_weiß_imwandeln__
{
    internal class Program
    {
        static string pfad = @"C:\Users\ITA7-TN01\Desktop\Bilder";
        static string save = @"C:\Users\ITA7-TN01\Desktop\Texte";

        static void Main(string[] args)
        {
            using FileSystemWatcher watcher = new FileSystemWatcher(pfad);
            watcher.NotifyFilter = NotifyFilters.Attributes         // Überwacht Änderungen an den Dateiattributen (z. B. "Schreibgeschützt", "Versteckt" usw.).
                                 | NotifyFilters.CreationTime       // Überwacht Änderungen an der Erstellungszeit einer Datei oder eines Verzeichnisses.
                                 | NotifyFilters.DirectoryName      // Überwacht Änderungen am Namen eines Verzeichnisses.
                                 | NotifyFilters.FileName           // Überwacht Änderungen am Namen einer Datei.
                                 | NotifyFilters.LastAccess         // Überwacht, wenn eine Datei oder ein Verzeichnis zuletzt geöffnet/gelesen wurde.
                                 | NotifyFilters.LastWrite          // Überwacht, wenn eine Datei oder ein Verzeichnis zuletzt geschrieben/bearbeitet wurde.
                                 | NotifyFilters.Security           // Überwacht Änderungen an der Sicherheits- bzw. Zugriffssteuerung (z. B. NTFS-Berechtigungen).
                                 | NotifyFilters.Size;              // Überwacht Änderungen an der Dateigröße.
            watcher.Filter = "*.jpg";

            Console.WriteLine($"Looking for everything with end {watcher.Filter}");

            watcher.Created += OnCreated;

            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        public static void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Ha {e.Name}");

            var bitmap = SKBitmap.Decode(e.FullPath);
            string combine = Path.Combine(save, e.Name);

            Task task = Task.Run(() =>
            {
                Console.WriteLine($"Task gestarted mit code {e.Name}");
                ColorToGray(bitmap, combine); 
            }); 
            
        }

        private static void ColorToGray(SKBitmap image, string grayFilename)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    SKColor color = image.GetPixel(x, y);
                    //Console.WriteLine($"Pixel X: {x} | Pixel Y: {y}");
                    byte gray = (byte)(0.2126f * color.Red + 0.7152f * color.Green + 0.0722f *
                   color.Blue);
                    SKColor sKColor = new SKColor(gray, gray, gray, color.Alpha);
                    image.SetPixel(x, y, sKColor);
                }
            }
            try
            {
                using (FileStream grayFileStream = File.Create(grayFilename))
                {
                    image.Encode(grayFileStream, SKEncodedImageFormat.Jpeg, 100);
                    Console.WriteLine($"Task done {grayFilename}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            image.Dispose();
        }
    }
}
