using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions___Jahre.Models
{
    internal class MonthOutOfRangeException : Exception
    {
        public MonthOutOfRangeException() : base("Nur monate zwischen 1 - 12.") { }
    }
}
