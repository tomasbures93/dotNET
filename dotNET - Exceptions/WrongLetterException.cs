using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET
{
    internal class WrongLetterException : Exception
    {
        public WrongLetterException(string message) : base(message)
        {
        }
    }
}
