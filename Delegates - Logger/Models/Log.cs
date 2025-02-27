using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates___Logger.Models
{
    internal class Log
    {
        private string _pfad;
        private StreamWriter logger;

        public Log(string pfad)
        {
            _pfad = pfad;
            logger = new StreamWriter(pfad, true);
        }

        public void WriteInLog(string message)
        {
            logger.WriteLine($"{DateTime.Now} | {message}");
        }
        public void ConsolePrint(string message)
        {
            Console.WriteLine($"{DateTime.Now} | {message}");
        }
        public void CloseLog()
        {
            logger.Close();
        }
    }
}
