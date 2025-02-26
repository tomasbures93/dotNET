using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections___Schach
{
    internal class Pferd
    {
        private int _x;         // 0 - 7
        private int _y;         // 0 - 7
        private Dictionary<string, string> _positions;

        public Pferd()
        {
            _positions = new Dictionary<string, string>();
            _x = 1;
            _y = 1;
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public bool WarSchonDa(string x, string y)
        {
            if (!_positions.ContainsKey(x) || !_positions.ContainsValue(y))
            {
                return false;
            } else
            {
                return true;
            }
        }

        public void AddInZuge(string x, string y)
        {
            _positions.Add(x, y);
        }
    }
}
