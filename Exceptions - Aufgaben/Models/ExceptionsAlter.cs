using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions___Aufgaben.Models
{
    internal class ExceptionsAlter : Exception
    {
        public ExceptionsAlter() : base("Kein negatives Alter erlaubt!") { }
    }
}
