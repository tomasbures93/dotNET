using Generics___einfach_verketette_list.Models;

namespace Generics___einfach_verketette_list
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleList<string> list1 = new SimpleList<string>();
            list1.ShowList();
            list1.SearchItem("pica");
            list1.AddItem("Tomas");
            list1.AddItem("Pepa");
            list1.AddItem("Pepaa");
            list1.AddItem("Jebat");
            list1.AddItem("Kok");
            list1.ShowList();
            list1.SearchItem("Tomas");
            list1.SearchItem("Pepa");
            list1.SearchItem("Jebat");
            list1.SearchItem("Kok");
            list1.SearchItem("Kekw");
            Console.WriteLine($"Wir haben {list1.HowMuchItems()} items in list.");

            string[] array = list1.MakeArray();
            foreach (string item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
