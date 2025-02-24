using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatoruberladung.Models
{
    internal class ipadresse
    {
        private ulong _erstOktet;
        private ulong _zweiteOktet;
        private ulong _dritteOktet;
        private ulong _vierteOktet;

        public ipadresse(ulong erst, ulong zweitt, ulong dritte, ulong vierte)
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

        public static ipadresse operator ++(ipadresse adresse)
        {
            ulong ein = adresse._erstOktet;
            ulong zwei = adresse._zweiteOktet;
            ulong drei = adresse._dritteOktet;
            ulong vier = adresse._vierteOktet;
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
                }
                nachsteOktet = false;
            } 
            else if(nachsteOktet == true)
            {
                zwei++;
                return new ipadresse(ein, zwei, drei, vier);
            }
            if(ein >= 255)
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
    }
}
