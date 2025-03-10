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
            //    PublishDate = "2.2.3333",
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
                Console.WriteLine($"{b.ID} | {b.Titel} | {b.PublishDate} | {b.Language} | {b.Pages} | {b.VerlagID}");
            }

            Console.WriteLine();

            foreach(var v in context.Verlags)
            {
                if(v.Description == "Please Change")
                {
                    Console.WriteLine($"Verlag ID:{v.ID} Description has to be Changed!!!!!");
                    Console.WriteLine($"{v.ID} | {v.Name} | {v.Description} | {v.Score}");
                } else
                {
                    Console.WriteLine($"{v.ID} | {v.Name} | {v.Description} | {v.Score}");
                }
            }

            var updateVerlag = context.Verlags.Where(v => v.ID == 1).FirstOrDefault();
            updateVerlag.Description = "Etwas test daten";
            context.SaveChanges();
            Console.WriteLine();
            foreach (var v in context.Verlags)
            {
                if (v.Description == "Please Change")
                {
                    Console.WriteLine($"Verlag ID:{v.ID} Description has to be Changed!!!!!");
                    Console.WriteLine($"{v.ID} | {v.Name} | {v.Description} | {v.Score}");
                } else
                {
                    Console.WriteLine($"{v.ID} | {v.Name} | {v.Description} | {v.Score}");
                }
            }
        }
    }
}
