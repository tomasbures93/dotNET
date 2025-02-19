using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra___ChecksumCalculator.Interfaces
{
    interface IChecksumCalculator
    {
        bool Validate(string input);
        bool CalculateCheckDigit(string input);
    }
}
