using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra___ChecksumCalculator.Models
{
    class ISBN10ChecksumCalculator : ChecksumCalculator
    {
        public ISBN10ChecksumCalculator(string nummer) : base(nummer)
        {

        }

        public override bool IsNumeric(string nummer)
        {
            return false;
        }

        public override bool Validate(string nummer)
        {
            if(int.TryParse(nummer, out int number) == true)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public override bool CalculateCheckDigit(string nummer)
        {
            return false;
        }
    }
}
