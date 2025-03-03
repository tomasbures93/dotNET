namespace Streams___Dateisuche
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variablen und Pfad
            string ordner = @"C:\Users\ITA7-TN01\Desktop\Suche";
            string datei = @"\log.txt";
            string pfad = ordner + datei;
            string text = "";
            string input;
            string datum;

            // Eingabe von text
            do
            {
                Console.WriteLine("Geben sie beliebige text ein! ( . ) am ende speicher das eingabe");
                input = Console.ReadLine();
                datum = DateTime.Now.ToString();
                text = text + " " + input;
                if (input.EndsWith('.'))
                {
                    break;
                } 
            } while (true);
            
            // Gucken ob ordner existiert
            DirectoryInfo di = new DirectoryInfo(ordner);
            if (di.Exists)
            {
                using (StreamWriter sw = new StreamWriter(pfad, true))
                {
                    sw.WriteLine(datum + ": " + text);
                    Console.WriteLine($"{datum} | {text}");
                }
            }
            else
            {
                Console.WriteLine($"{ordner} Existier nicht!");
            }
        }
    }
}
