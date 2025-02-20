using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra___ChecksumCalculator.Models
{
    class ISBN13ChecksumCalculator : ChecksumCalculator
    {
        public ISBN13ChecksumCalculator(string nummer) : base(nummer)
        {

        }

        public override bool IsNumeric(string nummer)
        {
            if (nummer.Contains("-"))
            {
                nummer = nummer.Replace("-", "");
            }
            if(long.TryParse(nummer, out long number))
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
                int pruefSumme = int.Parse(pruffdigit.ToString()), zwischensumme = 0, modulo = 0, berechnung = 0;
                string digits = nummer.Substring(0, nummer.Length - 1);
                int[] array = new int[digits.Length];
                // einzeln in array packen
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = int.Parse(digits[i].ToString());
                }
                // zwischen summe berechnen
                for (int i = 0; i < array.Length; i++)
                {
                    if(i == 0)
                    {
                        zwischensumme = zwischensumme + (array[i] * 1);
                    }
                    else if(i % 2 != 0)
                    {
                        zwischensumme = zwischensumme + (array[i] * 3);
                    } else
                    {
                        zwischensumme = zwischensumme + (array[i] * 1);
                    }
                }
                modulo = zwischensumme % 10;
                berechnung = 10 - modulo;
                if (berechnung == pruefSumme)
                {
                    return true;
                }
                else
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
                    if (i == 0)
                    {
                        zwischensumme = zwischensumme + (array[i] * 1);
                    }
                    else if (i % 2 != 0)
                    {
                        zwischensumme = zwischensumme + (array[i] * 3);
                    }
                    else
                    {
                        zwischensumme = zwischensumme + (array[i] * 1);
                    }
                }
                modulo = zwischensumme % 10;
                modulo = 10 - modulo;
                return modulo.ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
