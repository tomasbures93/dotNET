using System.Net.Http.Json;
using System.Reflection;
using System.Security.Principal;
using System.Text.Json;

namespace API___Feiertag_Service
{
    internal class Program
    {
        static ServiceAntwort data = new ServiceAntwort();
        static int year;
        static string land;
        static string[] lander = { "bw", "by", "be", "bb", "hb",
                                    "hh", "he", "mv", "ni", "nw", "rp",
                                    "sl" , "sn", "st", "sh", "th"};
        static async Task Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"Please insert a year you would like to see ( {DateTime.Now.Year} - {DateTime.Now.Year + 2} )");
                year = int.Parse(Console.ReadLine());
                if (year == DateTime.Now.Year || year == DateTime.Now.Year + 1 || year == DateTime.Now.Year + 2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Year - Try Again");
                }
                Console.ReadKey();
            } while (true);
            do
            {
                Console.Clear();
                Console.WriteLine($"Year - {year}\n");
                Bundeslander();
                Console.WriteLine();
                Console.WriteLine("Please insert which Bundesland would you like to see (bw oder BE)");
                land = Console.ReadLine().ToLower();
                if (lander.Contains(land))
                {
                    try
                    {
                        string website = $@"https://get.api-feiertage.de?years={year.ToString()}&states={land}";
                        data = await LoadData(website);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Problem mit API");
                        Console.WriteLine(ex.Message);
                    }
                    Console.WriteLine();
                    Console.Clear();
                    ShowFeiertageAll();
                } 
                else
                {
                    Console.WriteLine("Wrong input");
                }
                Console.ReadKey();
            } while (true);
        }

        private static void ShowFeiertageAll()
        {
            Console.WriteLine($"Jahr: {year} | Land: {land}");
            foreach (var item in data.feiertage)
            {
                Console.WriteLine($"Name: {item.fname,-52} | Datum: {item.date,12}");
            }
        }

        private static void Bundeslander()
        {
            Console.WriteLine("BW - Baden-Wunberg");
            Console.WriteLine("BY - Bayern");
            Console.WriteLine("BE - Berlin");
            Console.WriteLine("BB - Brandenburg");
            Console.WriteLine("HB - Bremen");
            Console.WriteLine("HH - Hamburg");
            Console.WriteLine("HE - Hessen");
            Console.WriteLine("MV - Necjkebvzrg");
            Console.WriteLine("NI - Niedersachsen");
            Console.WriteLine("NW - Nordrhein - Westfalen");
            Console.WriteLine("RP - Rheinland - Pfalz");
            Console.WriteLine("SL - Saarland");
            Console.WriteLine("SN - Sachsen");
            Console.WriteLine("ST - Sachsen - Anhalt");
            Console.WriteLine("SH - Schleswig - Holstein");
            Console.WriteLine("TH - Thüringen");
        }

        private static async Task<ServiceAntwort> LoadData(string path)
        {
            HttpClient client = new HttpClient();
            ServiceAntwort data = await client.GetFromJsonAsync<ServiceAntwort>(path);
            return data;
        }

        public class ServiceAntwort
        {
            public string status { get; set; }
            public Feiertage[] feiertage { get; set; }
        }

        public class Feiertage
        {
            public string date { get; set; }
            public string fname { get; set; }
            public string all_states { get; set; }
            public string bw { get; set; }
            public string by { get; set; }
            public string be { get; set; }
            public string bb { get; set; }
            public string hb { get; set; }
            public string hh { get; set; }
            public string he { get; set; }
            public string mv { get; set; }
            public string ni { get; set; }
            public string nw { get; set; }
            public string rp { get; set; }
            public string sl { get; set; }
            public string sn { get; set; }
            public string st { get; set; }
            public string sh { get; set; }
            public string th { get; set; }
            public string comment { get; set; }
            public object augsburg { get; set; }
            public string katholisch { get; set; }

        }

    }
}
