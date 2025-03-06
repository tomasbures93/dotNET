using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LINQ___Durchschnitt_von_kategorien.Models
{
    internal class Produkt
    {
        private string _name;
        private double _price;
        private string _category;

        public string Name 
        { 
            get { return _name; } 
            set { _name = value; } 
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public Produkt(string name, double price, string category)
        {
            _name = name;
            _price = price;
            _category = category;
        }

        public override string ToString()
        {
            return $"{Name,-18} | $ {Price,8:F2} | {Category,12}";
        }
    }
}
