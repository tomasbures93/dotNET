using Erweiterungsmethoden____Erweiterung_der_Klasse_String.Models;

namespace Erweiterungsmethoden____Erweiterung_der_Klasse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string haloo = "10";
            Console.WriteLine(haloo.ToInt32());

            string hallo = "hallo";
            Console.WriteLine(hallo.ReverseString());
        }
    }
}
