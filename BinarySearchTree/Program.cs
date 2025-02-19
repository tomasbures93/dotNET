using BinarySearchTree.Models;
namespace BinarySearchTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();

            tree.Print();

            tree.Add(100);
            tree.Add(20);
            tree.Add(120);
            tree.Add(8);
            tree.Add(55);
            tree.Add(9);
            tree.Add(110);
            tree.Add(150);


            tree.Print();
            Console.WriteLine();
        }
    }
}
