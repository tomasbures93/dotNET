using Exceptions___Jahre.Models;

namespace Exceptions___Jahre
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleDate date = new SimpleDate(1993, 6, 6);
            SimpleDate date2 = new SimpleDate(2024, 2, 29);
            Console.WriteLine(date.ToString());
            Console.WriteLine(date2.ToString());
        }
    }
}
