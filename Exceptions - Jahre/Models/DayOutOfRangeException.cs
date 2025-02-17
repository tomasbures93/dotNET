using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions___Jahre.Models
{
    internal class DayOutOfRangeException : Exception
    {
        public DayOutOfRangeException() : base("Falsche anzahl an Tage") { }
    }
}
