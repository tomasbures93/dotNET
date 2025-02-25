using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Indexer___Simple_List.Models
{
    internal class SimpleList<T> where T : IComparable<T>
    {
        public Node<T> Kopf;

        public SimpleList()
        {
            Kopf = null;
        }

        public void AddItem(T item)
        {
            Node<T> newItem = new Node<T>(item);
            if (Kopf == null)
            {
                Kopf = newItem;
            }
            else
            {
                Node<T> aktuell = Kopf;
                while (aktuell.Next != null)
                {
                    aktuell = aktuell.Next;
                }
                aktuell.Next = newItem;
            }
        }

        public void RemoveItem(T item)
        {
            if(Kopf == null)
            {
                return;
            }

            if (Kopf.Daten.Equals(item))
            {
                Kopf = Kopf.Next;
                return;
            }

            Node<T> aktuell = Kopf;
            while (aktuell.Next != null && !aktuell.Next.Daten.Equals(item))
            {
                aktuell = aktuell.Next;
            }

            if (aktuell.Next != null)
            {
                aktuell.Next = aktuell.Next.Next;
            }
        }

        public void SearchItem(T item)
        {
            int position = 0;

            if (Kopf == null)
            {
                Console.WriteLine("Die Liste ist leer.");
                return;
            }

            Node<T> aktueller = Kopf;

            while (aktueller.Next != null)
            {
                if (aktueller.Daten.Equals(item))
                {
                    Console.WriteLine($"Item {aktueller.Daten} Befindet sich auf position {position}");
                    return;
                }
                aktueller = aktueller.Next;
                position++;
            }
            Console.WriteLine("Item befindet sich in der liste nicht.");
        }

        public int HowMuchItems()
        {
            int count = 0;
            if (Kopf == null)
            {
                return count;
            }
            else
            {
                Node<T> aktuell = Kopf;
                count++;
                while (aktuell.Next != null)
                {
                    count++;
                    aktuell = aktuell.Next;
                }
                return count;
            }
        }

        public T[] MakeArray()
        {
            T[] array = new T[HowMuchItems()];
            int counter = 0;
            Node<T> aktueller = Kopf;
            while (aktueller != null)
            {
                array[counter] = aktueller.Daten;
                counter++;
                if (aktueller.Next == null)
                {
                    break;
                }
                aktueller = aktueller.Next;
            }
            return array;
        }

        public T this[int index]
        {
            get
            {
                if(index < 0 || index >= HowMuchItems())
                {
                    throw new IndexOutOfRangeException("Fehler, falsche index");
                }

                Node<T> aktuell = Kopf;
                int counter = 0;
                while(aktuell != null)
                {
                    if(counter == index)
                    {
                        return aktuell.Daten;
                    }
                    aktuell = aktuell.Next;
                    counter++;
                }
                throw new IndexOutOfRangeException("KEKW");
            }
        }
    }
}
