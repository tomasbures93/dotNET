using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer___Simple_List.Models
{
    class Node<T>
    {
        public T Daten;
        public Node<T> Next;

        public Node(T daten)
        {
            Daten = daten;
            Next = null;
        }
    }
}
