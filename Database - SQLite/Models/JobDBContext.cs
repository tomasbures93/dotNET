using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database___SQLite.Models
{
    public class JobDBContext : DbContext
    {

        public DbSet<JobApplication> jobApplications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Database.db");
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite($"Filename={path}");
        }
    }
}
