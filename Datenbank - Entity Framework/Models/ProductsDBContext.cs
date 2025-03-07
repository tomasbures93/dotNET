using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datenbank___Entity_Framework.Models
{
    public class ProductsDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Initial Catalog wenn wir haben mehr als 1 Datenbank auf unseren server

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(
                @"Server=.\SQLEXPRESS;Initial Catalog=Produkte;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");

            //optionsBuilder.LogTo(Console.WriteLine);
        
        }
    }
}
