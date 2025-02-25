using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatoruberladung.Models
{
    internal class ipadresse
    {
        private uint _erstOktet;
        private uint _zweiteOktet;
        private uint _dritteOktet;
        private uint _vierteOktet;

        public ipadresse() { }

        public ipadresse(uint erst, uint zweitt, uint dritte, uint vierte)
        {
            _erstOktet = erst;
            _zweiteOktet = zweitt;
            _dritteOktet = dritte;
            _vierteOktet = vierte;
        }

        public override string ToString()
        {
            return $"{_erstOktet}.{_zweiteOktet}.{_dritteOktet}.{_vierteOktet}";
        }

        public static bool operator >(ipadresse erst, ipadresse zwei)
        {
            if(erst._erstOktet > zwei._erstOktet)
            {
                return true;
            } 
            else
            {
                if(erst._zweiteOktet > zwei._zweiteOktet)
                {
                    return true;
                } 
                else
                {
                    if(erst._dritteOktet > zwei._dritteOktet)
                    {
                        return true;
                    } 
                    else
                    {
                        if(erst._vierteOktet > zwei._vierteOktet)
                        {
                            return true;
                        } 
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }

        public static bool operator <(ipadresse erst, ipadresse zwei)
        {
            if (erst._erstOktet < zwei._erstOktet)
            {
                return true;
            }
            else
            {
                if (erst._zweiteOktet < zwei._zweiteOktet)
                {
                    return true;
                }
                else
                {
                    if (erst._dritteOktet < zwei._dritteOktet)
                    {
                        return true;
                    }
                    else
                    {
                        if (erst._vierteOktet < zwei._vierteOktet)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }

        public static ipadresse operator ++(ipadresse adresse)
        {
            uint ein = adresse._erstOktet;
            uint zwei = adresse._zweiteOktet;
            uint drei = adresse._dritteOktet;
            uint vier = adresse._vierteOktet;
            bool nachsteOktet = true;
            if(vier >= 255)
            {
                vier = 0;
                drei++;
                nachsteOktet = false;
            } 
            else
            {
                vier++;
                return new ipadresse(ein, zwei, drei, vier);
            }
            if(drei >= 255)
            {
                drei = 0;
                zwei++;
                nachsteOktet = false;
            } 
            else if(nachsteOktet == true)
            {
                drei++;
                return new ipadresse(ein, zwei, drei, vier);
            }
            if (zwei >= 255)
            {
                zwei = 0;
                if(ein < 255)
                {
                    ein++;
                } else
                {
                    Console.WriteLine("NOPE, adresse 256.0.0.0 existiert nicht");
                }
                nachsteOktet = false;
            } 
            else if(nachsteOktet == true)
            {
                zwei++;
                return new ipadresse(ein, zwei, drei, vier);
            }
            if(ein > 255)
            {
                Console.WriteLine("NOPE, adresse 256.0.0.0 existiert nicht");
                ein = 256;
                zwei = 256;
                drei = 256;
                vier = 256;
            } 
            else if(nachsteOktet == true)
            {
                ein++;
            }
            return new ipadresse(ein, zwei, drei, vier);
        }

        public static bool operator ==(ipadresse erst, ipadresse zwei)
        {
            if(erst._erstOktet == zwei._erstOktet && 
                erst._zweiteOktet == zwei._zweiteOktet &&
                erst._dritteOktet == zwei._dritteOktet &&
                erst._vierteOktet == zwei._vierteOktet)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static bool operator !=(ipadresse erst, ipadresse zwei)
        {
            if (erst._erstOktet != zwei._erstOktet ||
                erst._zweiteOktet != zwei._zweiteOktet ||
                erst._dritteOktet != zwei._dritteOktet ||
                erst._vierteOktet != zwei._vierteOktet)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static ipadresse InsertIP(string insert)
        {
            try
            {
                string[] separated = insert.Split('.');
                uint[] ips = new uint[separated.Length];
                for (int i = 0; i < separated.Length; i++)
                {
                    ips[i] = uint.Parse(separated[i]);
                }
                Console.WriteLine($"IP - {ips[0]}.{ips[1]}.{ips[2]}.{ips[3]} - created");
                return new ipadresse(ips[0], ips[1], ips[2], ips[3]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falsche eingabe du ****");
                return null;
            }
        }
    }
}
