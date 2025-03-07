using Castle.Components.DictionaryAdapter;
using Datenbank___Kleine_Firma.Models;
using System.Threading.Channels;

namespace Datenbank___Kleine_Firma
{
    internal class Program
    {
        // ENTITY FRAMEWORK schutz bisschen gegen SQL Injections!!! 
        static void Main(string[] args)
        {
            CompanyDBContext context = new CompanyDBContext();
            context.Database.EnsureCreated();
            do
            {
                Console.Clear();
                Console.WriteLine("\n\tCompany Database");
                Console.WriteLine();
                Console.WriteLine("\t1 - Show Divisions");
                Console.WriteLine("\t2 - Add Division");
                Console.WriteLine("\t3 - Show Workers");
                Console.WriteLine("\t4 - Add Worker");
                Console.WriteLine("\t5 - Change Division Data");
                Console.WriteLine("\t6 - Change Worker Data");
                Console.WriteLine("\t7 - Delete Division");
                Console.WriteLine("\t8 - Delete Worker");
                Console.WriteLine("\t9 - Exit");
                string input = Console.ReadLine();
                switch (input[0])
                {
                    case '1':
                        Console.Clear();
                        ShowDivisions(context);
                        break;
                    case '2':
                        AddDivision(context);
                        break;
                    case '3':
                        Console.Clear();
                        ShowWorkers(context);
                        break;
                    case '4':
                        AddWorker(context);
                        break;
                    case '5':
                        Console.Clear();
                        EditDivision(context);
                        break;
                    case '6':
                        Console.Clear();
                        EditWorker(context);
                        break;
                    case '7':
                        Console.Clear();
                        DeleteDivision(context);
                        break;
                    case '8':
                        Console.Clear();
                        DeleteWorker(context);
                        break;
                    case '9':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\tWrong input!");
                        break;
                }
                Console.ReadKey();
            } while (true);
        }

        static void DeleteDivision(CompanyDBContext context)
        {
            Console.WriteLine();
            ShowDivisionsSmall(context);
            Console.WriteLine("\tInsert ID from divison you want to delete");
            Console.WriteLine();
            int ID = int.Parse(Console.ReadLine());
            var abteilung = context.Abteilungen.Find(ID);
            if(abteilung.Mitarbeiters.Count == 0)
            {
                context.Abteilungen.Remove(abteilung);
                context.SaveChanges();
            } 
            else
            {
                Console.WriteLine($"In this Division is still someone working. You cant delete it | {abteilung.Mitarbeiters.Count} person/s still working there");
            }
        }

        static void DeleteWorker(CompanyDBContext context)
        {
            Console.WriteLine();
            ShowWorkers(context);
            Console.WriteLine("\tInsert ID from Worker you want to delete");
            Console.WriteLine();
            int ID = int.Parse(Console.ReadLine());
            var worker= context.Mitarbeiters.Find(ID);
            context.Mitarbeiters.Remove(worker);
            context.SaveChanges();
        }

        static void EditDivision(CompanyDBContext context)
        {
            Console.WriteLine();
            ShowDivisionsSmall(context);
            Console.WriteLine();
            Console.WriteLine("\nInsert ID from Division you want to change Name");
            int divisionID = int.Parse(Console.ReadLine());
            Console.WriteLine("\nPlease insert new name");
            string newName = Console.ReadLine();
            var changediv = context.Abteilungen.Where(id => divisionID == id.ID).FirstOrDefault();
            changediv.AbteilungName = newName;
            context.SaveChanges();
        }

        static void ShowDivisions(CompanyDBContext context)
        {
            foreach(var d in context.Abteilungen)
            {
                Console.WriteLine($"\tID: {d.ID} | Name: {d.AbteilungName} - {d.Mitarbeiters.Count} Workers");
                Console.WriteLine($"\t\t {string.Join(", ", d.Mitarbeiters.Select(m => string.Join(' ', m.Vorname + " " + m.Nachname)))}");
                Console.WriteLine();
            }
        }

        static void ShowDivisionsSmall(CompanyDBContext context)
        {
            foreach (var d in context.Abteilungen)
            {
                Console.WriteLine($"\tID: {d.ID} | Name: {d.AbteilungName}");
            }
        }

        static void AddDivision(CompanyDBContext context)
        {
            Console.Clear();
            Console.WriteLine("\tPlease insert name of the New Division");
            string input = Console.ReadLine();
            if(input.ToLower() != "exit")
            {
                Abteilung abteilung = new Abteilung { AbteilungName = input };
                context.Abteilungen.Add(abteilung);
                context.SaveChanges();
                Console.WriteLine($"\tAbteilung : {input} added into Database");
            }
        }

        static void AddWorker(CompanyDBContext context)
        {
            Console.Clear();
            Console.WriteLine("\tPlease insert First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("\tPlease insert Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("\tPlease insert Email");
            string email = Console.ReadLine();
            Console.WriteLine();
            ShowDivisionsSmall(context);
            Console.WriteLine();
            Console.WriteLine("\tPlease insert Division ID ( optional )");
            int division = 0;
            try
            {
                division = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if(division != 0)
            {
                Mitarbeiter person = new Mitarbeiter
                {
                    Vorname = firstName,
                    Nachname = lastName,
                    Email = email,
                    AbteilungID = division,
                };
                context.Mitarbeiters.Add(person);
                context.SaveChanges();
            } 
            else
            {
                Mitarbeiter person = new Mitarbeiter
                {
                    Vorname = firstName,
                    Nachname = lastName,
                    Email = email,
                };
                context.Mitarbeiters.Add(person);
                context.SaveChanges();
            }
        }

        static void EditWorker(CompanyDBContext context)
        {
            Console.WriteLine();
            ShowWorkers(context);
            Console.WriteLine();
            Console.WriteLine("\tPlease insert Worker ID you would like to edit");
            int ID = int.Parse(Console.ReadLine());
            Console.WriteLine("\tWhat would you like to Edit ?");
            Console.WriteLine();
            Console.WriteLine("\t1 - FirstName");
            Console.WriteLine("\t2 - LastName");
            Console.WriteLine("\t3 - Email");
            Console.WriteLine("\t4 - Division");
            Console.WriteLine("\t5 - Everything");
            string menu = Console.ReadLine();
            switch (menu[0])
            {
                case '1':
                    EditWorkerFirstName(context, ID);
                    break;
                case '2':
                    EditWorkerLastName(context, ID);
                    break;
                case '3':
                    EditWorkerEmail(context, ID);
                    break;
                case '4':
                    EditWorkerDivision(context, ID);
                    break;
                case '5':
                    EditWorkerFirstName(context, ID);
                    EditWorkerLastName(context, ID);
                    EditWorkerEmail(context, ID);
                    EditWorkerDivision(context, ID);
                    break;
                default:
                    Console.WriteLine("\tWrong input!");
                    break;
            }
        }

        private static void EditWorkerDivision(CompanyDBContext context, int ID)
        {
            Console.WriteLine();
            ShowDivisionsSmall(context);
            Console.WriteLine();
            Console.WriteLine("\tPlease insert new Division ID");
            int inputID = int.Parse(Console.ReadLine());
            var newDivision = context.Mitarbeiters.Where(id => id.ID == ID).FirstOrDefault();
            newDivision.AbteilungID = inputID;
            context.SaveChanges();
        }

        private static void EditWorkerEmail(CompanyDBContext context, int ID)
        {
            Console.WriteLine("\tPlease insert new Email");
            string input = Console.ReadLine();
            var newEmail = context.Mitarbeiters.Where(id => id.ID == ID).FirstOrDefault();
            newEmail.Email = input;
            context.SaveChanges();
        }

        private static void EditWorkerLastName(CompanyDBContext context, int ID)
        {
            Console.WriteLine("\tPlease insert new Last Name");
            string input = Console.ReadLine();
            var newLastName = context.Mitarbeiters.Where(id => id.ID == ID).FirstOrDefault();
            newLastName.Nachname = input;
            context.SaveChanges();
        }

        private static void EditWorkerFirstName(CompanyDBContext context, int ID)
        {
            Console.WriteLine("\tPlease insert new First Name");
            string input = Console.ReadLine();
            var newFirstName = context.Mitarbeiters.Where(id => id.ID == ID).FirstOrDefault();
            newFirstName.Vorname = input;
            context.SaveChanges();
        }

        static void ShowWorkers(CompanyDBContext context)
        {
            Console.WriteLine();
            foreach(var w in context.Mitarbeiters)
            {
                if(w.Abteilung == null)
                {
                    Console.WriteLine($"\tID {w.ID,3} | {w.Vorname,-13} {w.Nachname,-13} | {w.Email,-30} | NONE");
                }
                else
                {
                    Console.WriteLine($"\tID {w.ID,3} | {w.Vorname,-13} {w.Nachname,-13} | {w.Email,-30} | {w.Abteilung.AbteilungName,-15}");
                }
            }
        }
    }
}
