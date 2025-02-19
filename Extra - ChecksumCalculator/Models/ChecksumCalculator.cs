using Extra___ChecksumCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra___ChecksumCalculator.Models
{
    abstract class ChecksumCalculator : IChecksumCalculator
    {
        protected string _nummer;

        public ChecksumCalculator(string nummer)
        {
            _nummer = nummer;
        }

        public abstract bool IsNumeric(string input);

        public abstract bool Validate(string input);

        public abstract bool CalculateCheckDigit(string input);
    }
}
