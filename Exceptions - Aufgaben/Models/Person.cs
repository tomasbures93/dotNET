using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions___Aufgaben.Models
{
    internal class Person
    {
        private int _alter;
        public string Name { get; set; }
        public string Vorname 
        {
            get;
            set;
        }
        public int Alter 
        { 
            get { return _alter; } 
            set {
                try
                {
                    IsOldEnough(value);
                }
                catch(ExceptionsAlter ex)
                {
                    Console.WriteLine(ex.Message);
                    value = 0;
                }
                _alter = value;
            } 
        }

        public Person(string name, string vorname, int alter)
        {
            this.Name = name;
            this.Vorname = vorname;
            this.Alter = alter;
        }

        public static int IsOldEnough(int value)
        {
            if(value < 0)
            {
                throw new ExceptionsAlter();
            }
            return value;
        }
    }
}
