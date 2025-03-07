using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datenbank___Kleine_Firma.Models
{
    public class CompanyDBContext : DbContext
    {
        public DbSet<Abteilung> Abteilungen { get; set; }

        public DbSet<Mitarbeiter> Mitarbeiters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // NORMALEWEISSE auslagern in .json datei !!! Es ist standart!
            // Das hier ist nicht sicher!!! Nicht verwenden!!
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(
                @"Server=.\SQLEXPRESS;Initial Catalog=TestFirmDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
        }
    }
}
