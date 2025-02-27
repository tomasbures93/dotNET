using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates___Groß_klein.Models
{
    internal class Character
    {
        // RETURN VOID ... Printed direkt in Console
        public static void UpperCase(string input)
        {
            Console.WriteLine(input.ToUpper());
        }

        public static void LowerCase(string input)
        {
            Console.WriteLine(input.ToLower());
        }

        public static void UpperLower(string input)
        {
            Console.WriteLine(input);
        }


        // TEST mit Return funktion ... Gibt wert zurück
        public static int Characters(string input)
        {
            return input.Length;
        }
    }
}
