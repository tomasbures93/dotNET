using API___Namen_service.Models;
using System.Net.Http.Json;
namespace API___Namen_service
{
    internal class Program
    {
        static Gender gender = new Gender();
        static Age age = new Age();
        static Nationality nationality= new Nationality();
        static List<LandEncoded> land = new List<LandEncoded>();
        static async Task Main(string[] args)
        {
            // Auskommentiert weil nur 100x requests am Tag

            //Console.WriteLine("Please insert a name you would look to look up:");
            //string input = Console.ReadLine();
            //using (HttpClient client = new HttpClient())
            //{
            //    gender = await client.GetFromJsonAsync<Gender>("https://api.genderize.io/?name=" + input);
            //    age = await client.GetFromJsonAsync<Age>("https://api.agify.io/?name=" + input);
            //    nationality = await client.GetFromJsonAsync<Nationality>("https://api.nationalize.io/?name=" + input);
            //}

            //Console.Clear();

            //Console.WriteLine($"\nYou have chosen name {input}");
            //Console.WriteLine($"Gender: {gender.gender} | How much %: {gender.probability}");
            //Console.WriteLine($"{input} is probably {age.age} years old");

            //foreach(var listeLand in nationality.country)
            //{
            //    Console.WriteLine(listeLand.country_id + " " + listeLand.probability * 100);
            //    using (HttpClient client = new HttpClient())
            //    {
            //        nationality = await client.GetFromJsonAsync<Nationality>("https://restcountries.com/v3.1/alpha/" + listeLand.country_id);
            //    }
            //}

            Console.WriteLine("Insert country code: CZ/ DE / etwas");
            string country = Console.ReadLine();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    LandEncoded[] lander = await client.GetFromJsonAsync<LandEncoded[]>("https://restcountries.com/v3.1/alpha/" + country);
                    land.Add(lander[0]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine("Name: " + land[0].name.official);
            Console.WriteLine("Capital City: " + string.Join(", ", land[0].capital));
            Console.WriteLine(land[0].status);
            Console.WriteLine(land[0].currencies);
            Console.WriteLine(land[0].maps.googleMaps);
        }

    }
}
