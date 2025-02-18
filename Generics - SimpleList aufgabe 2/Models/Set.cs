using Generics___einfach_verketette_list.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                Node<T> aktuell = Kopf;           // Start bei Kopf
                while (aktuell != null)      
                {
                    Console.WriteLine("Durch");
                    if (Kopf.Daten.Equals(item))
                    {
                        Console.WriteLine("Item vorhanden");
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
                Console.Write(aktueller.Daten + " -> ");
                aktueller = aktueller.Next;
            }
            Console.WriteLine("null");
        }
    }
}
