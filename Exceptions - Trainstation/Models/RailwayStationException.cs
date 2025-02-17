using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions___Trainstation.Models
{
    internal class RailwayStationException : Exception
    {
        public RailwayStationException(string message) : base(message) { }
    }
}
