using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Datenbank___Migration.Models
{
    public class Verlag
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
