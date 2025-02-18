using Generics___einfach_verketette_list.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics___SimpleList_aufgabe_2.Models
{
    internal class Set<T>
    {
        private Node<T> Kopf;                   

        public Set()
        {
            Kopf = null;                       
        }

        public void AddMenge(T item)
        {
            Node<T> newItem = new Node<T>(item); 
            if (Kopf == null)                     
            {
                Kopf = newItem;                   
            }
            else
            {
                Node<T> aktuell = Kopf;          
                while (aktuell != null)      
                {
                    if (aktuell.Daten.Equals(item))
                    {
                        Console.WriteLine($"{newItem.Daten} schon vorhanden");
                        return;
                    }
                    if (aktuell.Next == null)
                    {
                        aktuell.Next = newItem;
                        return;
                    }
                    aktuell = aktuell.Next;       
                }
                   
            }
        }

        public void RemoveMenge(T daten)
        {
            if (Kopf == null) return;                      

            if (Kopf.Daten.Equals(daten))                              
            {
                Kopf = Kopf.Next;                         
                return;
            }

            Node<T> aktueller = Kopf;                     

            while (aktueller.Next != null && !aktueller.Next.Daten.Equals(daten))
            {
                aktueller = aktueller.Next;
            }

            if (aktueller.Next != null)
            {
                aktueller.Next = aktueller.Next.Next;
            }
        }

        public void SearchMenge(T item)
        {
            int position = 0;

            if (Kopf == null)
            {
                Console.WriteLine("Die Liste ist leer.");
                return;
            }

            Node<T> aktueller = Kopf;

            while (aktueller != null)
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

        public void ShowList()
        {
            if (Kopf == null)
            {
                Console.WriteLine("Set ist leer.");
                return;
            }

            Node<T> aktueller = Kopf;
            while (aktueller != null)
            {
                Console.Write(aktueller.Daten + " ");
                aktueller = aktueller.Next;
            }
        }

        // 6. Vereinigung zweier Mengen: Liefert eine neue Menge, die alle Elemente beider Mengen enthält
        public Set<T> Union(Set<T> other)
        {
            Set<T> result = new Set<T>();

            // Alle Elemente der aktuellen Menge hinzufügen
            Node<T> aktuell = Kopf;
            while (aktuell != null)
            {
                result.AddMenge(aktuell.Daten);
                aktuell = aktuell.Next;
            }

            // Alle Elemente der anderen Menge hinzufügen, falls sie noch nicht enthalten sind
            Node<T> otherAktuell = other.Kopf;
            while (otherAktuell != null)
            {
                result.AddMenge(otherAktuell.Daten);  // AddMenge prüft intern, ob das Element bereits existiert
                otherAktuell = otherAktuell.Next;
            }

            return result;
        }

        public bool Contains(T item)
        {
            Node<T> aktuell = Kopf;
            while (aktuell != null)
            {
                if (aktuell.Daten.Equals(item))
                    return true;
                aktuell = aktuell.Next;
            }
            return false;
        }
        // 7. Schnittmenge zweier Mengen: Liefert eine neue Menge, die nur die Elemente enthält, die in beiden Mengen vorhanden sind
        public Set<T> Intersection(Set<T> other)
        {
            Set<T> result = new Set<T>();

            Node<T> aktuell = Kopf;
            while (aktuell != null)
            {
                // Nur hinzufügen, wenn das Element auch in der anderen Menge vorhanden ist
                if (other.Contains(aktuell.Daten))
                {
                    result.AddMenge(aktuell.Daten);
                }
                aktuell = aktuell.Next;
            }

            return result;
        }
    }
}
