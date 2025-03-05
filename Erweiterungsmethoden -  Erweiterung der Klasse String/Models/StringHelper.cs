using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erweiterungsmethoden____Erweiterung_der_Klasse_String.Models
{
    static class StringHelper
    {
        public static int ToInt32(this string str)
        {
            try
            {
                return int.Parse(str);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        public static string ReverseString(this string str)
        {
            char[] strings = str.ToCharArray();
            char[] result = new char[str.Length];
            for(int i = 0; i < str.Length; i++)
            {
                result[i] = strings[str.Length - i - 1];
            }
            string output = new string(result);
            return output;
        }

        public static bool IsPalindrome(this string str)
        {
            char[] word = str.ToLower().ToCharArray();
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (word[i] != word[str.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
