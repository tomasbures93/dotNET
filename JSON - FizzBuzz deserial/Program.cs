using JSON___FizzBuzz_deserial.Models;
using System.Text.Json;

namespace JSON___FizzBuzz_deserial
{
    internal class Program
    {
        static List<JSON> json;

        static void Main(string[] args)
        {
            AusgabeKlassich(100);
            Console.WriteLine();
            Console.WriteLine("Welche datei in C:\\Users\\ITA7-TN01\\Desktop\\dotNet_Desktop\\09b - Serialisierung\\Aufgabe\\ wollen sie einlesen?");
            string input = Console.ReadLine();
            Console.WriteLine($"{input} wurde einegelesen");
            AusgabeJSON(100, $@"C:\Users\ITA7-TN01\Desktop\dotNet_Desktop\09b - Serialisierung\Aufgabe\{input}");
            
        }

        private static void AusgabeKlassich(int endZahl)
        {
            for(int i = 1; i <= endZahl; i++)
            {
                string ausgabe = "";
                if (i % 3 == 0)
                {
                    ausgabe += "Fizz";
                }
                if (i % 5 == 0)
                {
                    ausgabe += "Buzz";
                }
                Console.WriteLine($"{i, 3} - {ausgabe}");
            }
        }

        private static void LoadDatei(string datei)
        {
            try
            {
                using (StreamReader sr = new StreamReader(datei))
                {
                    string input = sr.ReadToEnd();
                    json = JsonSerializer.Deserialize<List<JSON>>(input);
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            
        }

        private static void AusgabeJSON(int endZahl, string datei)
        {
            LoadDatei(datei);
            for (int i = 1; i <= endZahl; i++)
            {
                string ausgabe = "";
                foreach(JSON json in json)
                {
                    if(i % json.Value == 0)
                    {
                        ausgabe += $"{json.Output}";
                    } 
                }
                Console.WriteLine($"{i,3} - {ausgabe}");
            }
        }
    }
}
