

using Datenbank___BucherDB_und_Migration.Models;

namespace Datenbank___BucherDB_und_Migration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BuchDBContext BuchDBcontext = new BuchDBContext();
            BuchDBcontext.Database.EnsureCreated();

            foreach(var b in BuchDBcontext.Books)
            {
                Console.WriteLine($"{b.ID} | {b.Titel} | {b.PublishDate}");
            }
        }
    }
}
