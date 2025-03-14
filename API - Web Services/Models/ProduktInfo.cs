using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API___Web_Services.Models
{

    public class ProduktInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public VendorBase[] vendors { get; set; }
        public string image_link { get; set; }
        public DateTime modified_at { get; set; }
    }
}
