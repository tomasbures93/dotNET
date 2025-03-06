using LINQ___Durchschnitt_von_kategorien.Models;
using System.Text;

namespace LINQ___Durchschnitt_von_kategorien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var produkts = LoadData();
            ShowProducts(produkts);
            Console.WriteLine();

            // Das Programm soll für jede Produktkategorie den Durchschnittspreis ermitteln.

            var durchschnittPrice = produkts.GroupBy(p => p.Category)
                                            .Select(g => new
                                            {
                                                Kategorie = g.Key,
                                                DurchsnittPrice = g.Average(p => p.Price)
                                            });
            foreach( var d in durchschnittPrice)
            {
                Console.WriteLine($"{d.Kategorie,-12} -> $ {d.DurchsnittPrice:F2}");
            }
        }

        public static void ShowProducts(List<Produkt> produkts)
        {
            Console.WriteLine("Name               |      Price |     Category");
            foreach (var produk in produkts)
            {
                Console.WriteLine(produk.ToString());
            }
        }

        public static List<Produkt> LoadData()
        {
            List<Produkt> produkts = new List<Produkt>();
            string path = @"C:\Users\ITA7-TN01\Desktop\produkts.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] strings = line.Split(';');
                        produkts.Add(new Produkt(strings[0], double.Parse(strings[1].Replace('.', ',')), strings[2].Trim()));
                    }
                    return produkts;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return produkts;
            }
        }
    }
}
