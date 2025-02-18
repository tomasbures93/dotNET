using Generics___SimpleList_aufgabe_2.Models;

namespace Generics___SimpleList_aufgabe_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Set<int> set = new Set<int>();
            set.AddMenge(1);
            set.AddMenge(2);
            set.AddMenge(2);
            set.AddMenge(2);
            set.AddMenge(3);
            set.ShowList();
        }
    }
}
