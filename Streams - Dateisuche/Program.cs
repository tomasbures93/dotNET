namespace Streams___Dateisuche
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            string input;
            string datum;
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

            string ordner = @"C:\Users\ITA7-TN01\Desktop\Suche";
            string datei = @"\pica.txt";
            string pfad = ordner + datei;
            Console.WriteLine(pfad);
            DirectoryInfo di = new DirectoryInfo(ordner);
            if (di.Exists)
            {
                using (StreamWriter sw = new StreamWriter(pfad, true))
                {
                    sw.WriteLine(datum + ": " + text);
                }
            }
        }
    }
}
