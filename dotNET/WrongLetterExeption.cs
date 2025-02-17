using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET
{
    internal class WrongLetterExeption : Exception
    {
        public WrongLetterExeption(string message) : base(message)
        { 
        }
    }
}
