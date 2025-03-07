using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datenbank___Kleine_Firma.Models
{
    public class Abteilung
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string AbteilungName { get; set; } = string.Empty;

        public virtual List<Mitarbeiter> Mitarbeiters { get; set; } = new List<Mitarbeiter>();
    }
}
