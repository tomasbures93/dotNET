using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics___einfach_verketette_list.Models
{
    class Node<T>
    {
        public T Daten;                     // Inhalt von NODE
        public Node<T> Next;                // Nexte position in der liste

        public Node(T daten)                // Konstruktor
        {
            Daten = daten;                  // Die daten welche sollen in diese node sein
            Next = null;                    // inizialisieren der nexte position aber noch leer! weil wir wissen nicht was da kommt
        }
    }
}
