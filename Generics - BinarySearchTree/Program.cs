using Generics___BinarySearchTree.Models;

namespace Generics___BinarySearchTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> bst = new BinaryTree<int>();

            int[] values = { 50, 100, 25, 1, 10, 75, 65, 85, 61, 45, 35, 15, 10 };
            foreach (int value in values)
                bst.Insert(value);

            Console.WriteLine("Inorder Traversierung:");
            bst.PrintInorder();
        }
    }
}
