using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datenbank___Migration.Models
{
    public class Buch
    {
        [Key]
        public int ID
        {
            get;
            set;
        }

        [Required]
        [MaxLength(100)]
        public string Titel
        {

            get;
            set;
        }

        [Required]
        [MaxLength(30)]
        public string PublishDate
        {
            get;
            set;
        }

        public int? Pages
        {
            get;
            set;
        }

        public string? Language
        {
            get;
            set;
        }
        /*
         * public virtual override Verlag Verlag {get, set;}
         */

        public int? VerlagID
        {
            get;
            set;
        }

    }
}
