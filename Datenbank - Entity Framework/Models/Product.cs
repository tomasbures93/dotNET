using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datenbank___Entity_Framework.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        public double Price { get; set; }
        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
