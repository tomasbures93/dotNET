using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace Extra___ChecksumCalculator.Models
{
    class ISBN10ChecksumCalculator : ChecksumCalculator
    {
        public ISBN10ChecksumCalculator(string nummer) : base(nummer)
        {

        }

        public override bool IsNumeric(string nummer)
        {
            char pruffdigit = nummer[^1];                           
            string digits = nummer.Substring(0, nummer.Length - 1);       
            if (digits.Contains("-"))
            {
                digits = nummer.Replace("-", "");
            }                                   
            if (int.TryParse(digits, out int number) && 
                ((pruffdigit == 'X' || pruffdigit == 'x') || int.TryParse(pruffdigit.ToString(), out int number2)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Validate(string nummer)
        {
            if (this.IsNumeric(nummer))
            {
                char pruffdigit = nummer[^1];
                int pruefSumme = 0, zwischensumme = 0, modulo = 0;
                string digits = nummer.Substring(0, nummer.Length - 1);
                int[] array = new int[digits.Length];
                // was für pruefsumme haben wir
                if(pruffdigit ==  'X' || pruffdigit == 'x')
                {
                    pruefSumme = 10;
                } 
                else
                {
                    pruefSumme = int.Parse(pruffdigit.ToString());
                }
                // einzeln in array packen
                for(int i = 0; i < array.Length; i++)
                {
                    array[i] = int.Parse(digits[i].ToString());
                }
                // zwischen summe berechnen
                for(int i = 0; i < array.Length; i++)
                {
                    zwischensumme = zwischensumme + (array[i] * i);
                }
                modulo = zwischensumme % 11;
                if(modulo == pruefSumme)
                {
                    return true;
                } else
                {
                    return false;
                }
            } 
            else
            {
                return false;
            }
        }

        public override string CalculateCheckDigit(string nummer)
        {
            if (this.IsNumeric(nummer))
            {
                int pruefSumme = 0, zwischensumme = 0, modulo = 0;
                int[] array = new int[nummer.Length];
                // einzeln in array packen
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = int.Parse(nummer[i].ToString());
                }
                // zwischen summe berechnen
                for (int i = 0; i < array.Length; i++)
                {
                    zwischensumme = zwischensumme + (array[i] * i);
                }
                modulo = zwischensumme % 11;
                if(modulo == 10)
                {
                    return "X";
                } else
                {
                    return modulo.ToString();
                }
            }
            else
            {
                return "";
            }
        }
    }
}
