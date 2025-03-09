using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datenbank___Migration.Models
{
    public class BuchDBContext : DbContext
    {

        public DbSet<Buch> Books { get; set; }
        public DbSet<Verlag> Verlags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies()
                .UseSqlServer(@"Server=.\SQLEXPRESS;Initial Catalog=Book;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buch>().HasData(
                new Buch { ID = 1, Titel = "Beste Buch", ReleaseDatum = "1.1.1111" },
                new Buch { ID = 2, Titel = "Buch nummer 2", ReleaseDatum = "2.2.2222 " }
                );
        }
    }
}
