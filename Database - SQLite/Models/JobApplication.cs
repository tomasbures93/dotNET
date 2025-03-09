using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database___SQLite.Models
{
    public class JobApplication
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }

        public string? ContactPerson { get; set; }

        public string Contact { get; set; }

        public string? City { get; set; }

        [Required]
        public string JobPosition { get; set; }

        public string? JobDescribtion { get; set; }

        [Required]
        public string WhenApplied { get; set; }

        public string? StartDate { get; set; }

        public string URL { get; set; }

        public string? Notes { get; set; }
    }
}
