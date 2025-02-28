using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events___Beobachter_am_Fluss.Models.EventArgumente
{
    internal class FiredeptWarnungEventArgs : System.EventArgs
    {
        private string _message;
        private string _zeitstemper;

        public string Message
        {
            get { return _message; }
        }

        public string Zeitstempel
        {
            get { return _zeitstemper; }
        }

        public FiredeptWarnungEventArgs(string message)
        {
            _message = message;
            _zeitstemper = DateTime.Now.ToLongTimeString();
        }
    }
}
