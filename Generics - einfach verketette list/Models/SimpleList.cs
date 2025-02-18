using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Generics___einfach_verketette_list.Models
{
    internal class SimpleList<T> where T : IComparable<T>
    {
        private Node<T> Kopf;                   // Da speichern wir die daten so kvasi die daten auf verschiedene positionen in List

        public SimpleList() 
        {
            Kopf = null;                        // wenn list wurde initializiert wurde das list leer
        }

        public void AddItem(T item)
        {
            Node<T> newItem = new Node<T>(item);  // neue Node initialisieren und den Parameter speichern
            if (Kopf == null)                     // Wenn die Liste leer ist (Kopf ist null)
            {
                Kopf = newItem;                   // neues Element als Kopf setzen
            }
            else
            {
                Node<T> aktuell = Kopf;           // Start bei Kopf
                while (aktuell.Next != null)      // solange das nächste Element existiert, weiterschalten
                {
                    aktuell = aktuell.Next;       // zum nächsten Knoten wechseln
                }
                aktuell.Next = newItem;           // neues Element ans Ende der Liste anhängen
            }
        }

        public void RemoveItem(T daten)
        {
            if (Kopf == null) return;                       // ob Kopf ist leer mach nichts!

            if (Kopf.Daten.Equals(daten))                   // Ob kopf ist das was wir suchen             
            {
                Kopf = Kopf.Next;                           // setzen wir Kopf auf das nexte element
                return;
            }

            Node<T> aktueller = Kopf;                       // nur zwischen speicherun variable

            // while schleife lauft so lange bis eine Node gefunden wurde mit die daten
            // aktueller.Next ist nicht null (ende der liste)
            // AND
            // Wir vergleichen den Wert des nächsten Knotens (aktueller.Next.Daten) mit dem gesuchten Wert daten.
            while (aktueller.Next != null && !aktueller.Next.Daten.Equals(daten))       
            {
                aktueller = aktueller.Next;
            }

            if (aktueller.Next != null)
            {
                // Damit wird der Zeiger vom aktuellen Knoten so geändert, dass er nicht mehr auf seinen unmittelbaren
                // Nachfolger zeigt, sondern auf den Knoten, der dem unmittelbaren Nachfolger folgt.
                aktueller.Next = aktueller.Next.Next;
            }
        }

        public void ShowList()
        {
            if (Kopf == null)
            {
                Console.WriteLine("Die Liste ist leer.");
                return;
            }

            Node<T> aktueller = Kopf;
            while (aktueller != null)
            {
                Console.Write(aktueller.Daten + " -> ");
                aktueller = aktueller.Next;
            }
            Console.WriteLine("null");
        }

        public void SearchItem(T item)
        {
            int position = 0;

            if (Kopf == null) {
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
            if (Kopf == null) {
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
                if(aktueller.Next == null)
                {
                    break;
                }
                aktueller = aktueller.Next;
            }
            return array;
        }
    }
}
