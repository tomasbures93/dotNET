using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events___Beobachter_am_Fluss.Models.EventArgumente
{
    internal class PoliceWarnungEventArgs : System.EventArgs
    {
        private string _message;
        private string _zeit;

        public string Message
        {
            get { return _message; }
        }

        public string Zeit
        {
            get { return _zeit; }
        }

        public PoliceWarnungEventArgs(string message)
        {
            _message = message;
            _zeit = DateTime.Now.ToLongTimeString();
        }
    }
}
