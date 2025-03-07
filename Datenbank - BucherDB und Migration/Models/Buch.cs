using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Datenbank___BucherDB_und_Migration.Models
{
    public class Buch
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Titel { get; set; }

        [Required]
        public string PublishDate { get; set; }

        public int? HowMuchPages { get; set; }

    }
}
