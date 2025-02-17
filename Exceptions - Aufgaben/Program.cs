using Exceptions___Aufgaben.Models;

namespace Exceptions___Aufgaben
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person tomas = new Person("Bures", "Tomas", 25);
            Person tomas2 = new Person("Bures", "Tomas", 0);
            Person tomas3 = new Person("Bures", "Tomas", -5);
        }
    }
}
