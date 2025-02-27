using Delegates___Logger.Models;
using System.Runtime.CompilerServices;

namespace Delegates___Logger
{
    internal class Program
    {
        delegate void LoggerHandler(string message);
        static void Main(string[] args)
        {
            string pfad = @"C:\Users\ITA7-TN01\Desktop\log.txt";

            do
            {
                Console.WriteLine("Was willst du in log datei schreiben ?");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    WriteInLogger(pfad,input);
                }
                Console.WriteLine("Noch was loggen ?");
                input = Console.ReadLine();
                if (input == "nein")
                {
                    break;
                }
            } while (true);
        }

        static void WriteInLogger(string pfad, string message)
        {
            Log log = new Log(pfad);
            LoggerHandler LogMich = log.WriteInLog;
            LogMich += log.ConsolePrint;
            LogMich += delegate (string message) { Console.WriteLine(message.ToUpper()); };
            LogMich(message);
            log.CloseLog();
        }
    }
}
