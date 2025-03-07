using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Datenbank___Kleine_Firma.Models
{
    public class Mitarbeiter
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Vorname { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Nachname { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [ForeignKey("AbteilungID")]
        public int? AbteilungID { get; set; }               // WENN ICH WILL, DAS ES NULLABLE kann sein dann muss ich "?" das setzen
        public virtual Abteilung? Abteilung { get; set; }
    }
}
