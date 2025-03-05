using Erweiterungsmethoden____Erweiterung_der_Klasse_String.Models;

namespace Erweiterungsmethoden____Erweiterung_der_Klasse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string haloo = "abg";
            Console.WriteLine(haloo.ToInt32());
            string halloo = "10";
            Console.WriteLine(halloo.ToInt32());

            string hallo = "hallo";
            Console.WriteLine(hallo.ReverseString());

            string palindrom = "kokokttkokok";
            Console.WriteLine($"Ist {palindrom} ein Palindrom ? {palindrom.IsPalindrome()}");
        }
    }
}
