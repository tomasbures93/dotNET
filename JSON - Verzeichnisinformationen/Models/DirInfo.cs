using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON___Verzeichnisinformationen.Models
{
    internal class DirInfo
    {
        private string _name;
        private string _creationTime;
        private int _countsub;

        public string Name 
        { 
            get { return _name; } 
            set { _name = value; }
        }

        public string CreationTime
        {
            get { return _creationTime; }
            set { _creationTime = value; }
        }

        public int CountSub
        {
            get { return _countsub; }
            set { _countsub = value; }
        }

        public DirInfo()
        {

        }

        public DirInfo(string name, string creationTime, int countsub)
        {
            _name = name;
            _creationTime = creationTime;
            _countsub = countsub;
        }

        public override string ToString()
        {
            return $"{Name,-35} | {CreationTime,20} | {CountSub,7}"; 
        }
    }
}
