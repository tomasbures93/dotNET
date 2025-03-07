using Datenbank___Entity_Framework.Models;

namespace Datenbank___Entity_Framework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // DEMO für Entity Framework

            Console.WriteLine("Hello, EFCore!");

            ProductsDBContext context = new ProductsDBContext();
            context.Database.EnsureCreated();

            Console.WriteLine();

            //Category software = new Category { CategoryName = "Software" };
            //Product p = new Product 
            //{ 
            //    ProductName = "Visual Studio 2022", 
            //    Price = 350, 
            //    Category = software 
            //};

            //context.Products.Add(p);
            //context.SaveChanges();

            //Auslesen aus DB
            foreach (var c in context.Categories)
            {
                Console.WriteLine($"{c.CategoryName} - {c.Products.Count} Produkte");
                Console.WriteLine($"\t Produkte: {string.Join(", ", c.Products.Select(p => (p.ProductName, p.Price)))}");
            }

            Console.WriteLine();

            foreach (var p in context.Products)
            {
                Console.WriteLine($"{p.ID} - {p.ProductName} - {p.Price} - {p.Category.CategoryName}");
            }

            Console.WriteLine();

            //etwas changen
            //var el = context.Categories.Where(c => c.CategoryName == "Hardware - B").FirstOrDefault();
            //el.CategoryName = "Hardware";
            //context.SaveChanges();

            //foreach (var p in context.Products)
            //{
            //    Console.WriteLine($"{p.ID} - {p.ProductName} - {p.Price} - {p.Category.CategoryName}");
            //}

            // Etwas löschen .. aber löscht auch alles was verknupft ist !!!
            var el2 = context.Categories.Find(1);
            context.Categories.Remove(el2);
            context.SaveChanges();

            //Category category = new Category { CategoryName = "Electronics" };
            //context.Categories.Add(category);
            //context.SaveChanges();
        }
    }
}
