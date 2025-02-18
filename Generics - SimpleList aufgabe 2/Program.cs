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
            set.AddMenge(3);
            set.AddMenge(4);
            set.ShowList();
            set.RemoveMenge(3);
            Console.WriteLine();
            set.ShowList();
            set.RemoveMenge(3);
            Console.WriteLine();
            set.ShowList();
            Console.WriteLine();
            set.SearchMenge(3);
            Console.WriteLine();
            set.SearchMenge(4);
            set.SearchMenge(5);
            set.SearchMenge(1);
            Console.WriteLine(set.HowMuchItems());
            set.AddMenge(3);
            Console.WriteLine(set.HowMuchItems());
        }
    }
}
