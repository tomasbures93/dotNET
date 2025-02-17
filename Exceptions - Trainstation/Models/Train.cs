using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions___Trainstation.Models
{
    internal class Train
    {
        private int _zugnummer;
        private int _waggons;

        public int ZugNummer 
        { 
            get { return _zugnummer; } 
            set { _zugnummer = value; }
        }

        public int Waggons
        {
            get { return _waggons; }
            set { _waggons = value; }
        }

        public Train(int zugnummer, int waggons)
        {
            ZugNummer = zugnummer;
            Waggons = waggons;
        }
    }
}
