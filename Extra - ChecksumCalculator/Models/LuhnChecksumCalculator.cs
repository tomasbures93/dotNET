using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra___ChecksumCalculator.Models
{
    class LuhnChecksumCalculator : ChecksumCalculator
    {
        public LuhnChecksumCalculator(string nummer) : base(nummer)
        {

        }
        public override bool IsNumeric(string nummer)
        {
            if (nummer.Contains("-"))
            {
                nummer = nummer.Replace("-", "");
            }
            if (long.TryParse(nummer, out long number))
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
                int pruefSumme = int.Parse(pruffdigit.ToString()), hilfe = 0, zwischensumme = 0, modulo = 0, zwischenrechnung = 0, pruefziffer = 0;
                string digits = nummer.Substring(0, nummer.Length - 1);
                string text = "";
                int[] array = new int[digits.Length];
                // einzeln in array packen
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = int.Parse(digits[i].ToString());
                }
                // zwischen summe berechnen
                for (int i = 0; i < array.Length; i++)
                {
                    if (i == 0)
                    {
                        zwischensumme = zwischensumme + array[i];
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            zwischensumme = zwischensumme + array[i];
                        }
                        else
                        {
                            if (array[i] * 2 > 9)
                            {
                                hilfe = array[i] * 2;
                                text = hilfe.ToString();
                                zwischensumme = zwischensumme + int.Parse(text[0].ToString()) + int.Parse(text[1].ToString());
                            }
                            else
                            {
                                zwischensumme = zwischensumme + (array[i] * 2);
                            }
                        }
                    }
                }
                if (zwischensumme % 10 == 0)
                {
                    pruefziffer = 0;
                }
                else
                {
                    int naechsteZehnerzahl = (int)(Math.Ceiling(zwischensumme / 10.0) * 10);
                    pruefziffer = naechsteZehnerzahl - zwischensumme;
                }
                if(pruefSumme == pruefziffer)
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
                int hilfe = 0, zwischensumme = 0, modulo = 0, zwischenrechnung = 0, pruefsumme = 0;
                string text = "";
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
                        zwischensumme = zwischensumme + array[i];
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            zwischensumme = zwischensumme + array[i];
                        }
                        else
                        {
                            if (array[i] * 2 > 9)
                            {
                                // wenn mehr als 10
                                hilfe = array[i] * 2;
                                text = hilfe.ToString();
                                zwischensumme = zwischensumme + (int.Parse(text[0].ToString()) + int.Parse(text[1].ToString()));
                            }
                            else
                            {
                                zwischensumme = zwischensumme + (array[i] * 2);
                            }
                        }
                    }
                }
                if (zwischensumme % 10 == 0)
                {
                    return "0";
                }
                else
                {
                    int naechsteZehnerzahl = (int)(Math.Ceiling(zwischensumme / 10.0) * 10);
                    pruefsumme = naechsteZehnerzahl - zwischensumme;
                    return $"{pruefsumme}";
                }
            }
            else
            {
                return "";
            }
        }

    }
}
