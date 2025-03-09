using Database___SQLite.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Database___SQLite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JobDBContext context = new JobDBContext();
            context.Database.EnsureCreated();

            foreach (var j in context.jobApplications)
            {
                Console.WriteLine($"{j.JobPosition}");
            }

            Console.WriteLine("keke nichts");

            //JobApplication application = new JobApplication
            //{
            //    CompanyName = "Test Company",
            //    ContactPerson = "Dave",
            //    Contact = "123456789",
            //    JobPosition = "Entwickler",
            //    JobDescribtion = "Something I would probably like",
            //    WhenApplied = "1.1.2026",
            //    URL = "www.keke.co",
            //    Notes = "jahahahahahaa"
            //};
            //context.jobApplications.Add(application);
            //context.SaveChanges();

            foreach (var j in context.jobApplications)
            {
                Console.WriteLine($"{j.ID} \n {j.Notes} \n {j.JobPosition}");
            }
        }
    }
}
