using Datenbank___Migration.Models;
using Microsoft.EntityFrameworkCore;

namespace Datenbank___Migration
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // MODEL WELCHE FUNKTIONIERT

            BuchDBContext context = new BuchDBContext();
            context.Database.EnsureCreated();

            var updateBooks = context.Books.Where(b => b.ID == 1).FirstOrDefault();
            updateBooks.Language = "Czech";
            updateBooks.Pages = 200;
            context.SaveChanges();

            updateBooks = context.Books.Where(b => b.ID == 2).FirstOrDefault();
            updateBooks.Language = "German";
            updateBooks.Pages = 250;
            context.SaveChanges();

            //Buch newBook = new Buch
            //{ 
            //    Titel = "Book 3",
            //    ReleaseDatum = "2.2.3333",
            //    Language = "Chinese",
            //    Pages = 50
            //};
            //context.Books.Add(newBook);
            //context.SaveChanges();

            //Verlag newVerlag = new Verlag
            //{
            //    Name = "Test"
            //};
            //context.Verlags.Add(newVerlag);
            //context.SaveChanges();
            //Verlag newVerlag2 = new Verlag
            //{
            //    Name = "Kekeke"
            //};
            //context.Verlags.Add(newVerlag2);
            //context.SaveChanges();


            updateBooks = context.Books.Where(b => b.ID == 2).FirstOrDefault();
            updateBooks.VerlagID = 1;
            context.SaveChanges();

            updateBooks = context.Books.Where(b => b.ID == 1).FirstOrDefault();
            updateBooks.VerlagID = 2;
            context.SaveChanges();

            foreach (var b in context.Books)
            {
                Console.WriteLine($"{b.ID} | {b.Titel} | {b.ReleaseDatum} | {b.Language} | {b.Pages} | {b.VerlagID}");
            }

            Console.WriteLine();

            foreach(var v in context.Verlags)
            {
                Console.WriteLine($"{v.ID} | {v.Name}");
            }
        }
    }
}
