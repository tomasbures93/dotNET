using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON___Produkte.Models
{
    class Warenkorb
    {
        private string _category;
        private string _partName;
        private double _partPrice;

        public string Category
        { 
            get { return _category; } 
            set { _category = value; } 
        }

        public string PartName
        {
            get { return _partName; }
            set { _partName = value; }
        }

        public double PartPrice
        {
            get { return _partPrice; }
            set { _partPrice = value; }
        }

        public Warenkorb()
        {

        }

        public Warenkorb(string category, string partName, double partPrice)
        {
            _category = category;
            _partName = partName;
            _partPrice = partPrice;
        }

        public override string ToString()
        {
            return $"{Category} | {PartName} | {PartPrice}";
        }
    }
}
