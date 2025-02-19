using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Models
{
    internal class Tree<T> where T : IComparable<T>
    {

        public Node<T> Root { get; set; }

        public void Add(T node)
        {
            if (Root == null)                       // Das passiert nur wenn ist es erste Eintrag
            {
                Root = new Node<T>(node);
            } 
            else
            {
                Root.Add(node);
            }
        }

        public void Print()
        {
            if(Root == null)
            {
                Console.WriteLine("Three is empty");
            }
            else
            {
                PrintInOrder(Root);
                Console.WriteLine();
            }
        }


        public void PrintInOrder(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            PrintInOrder(node.Left);
            Console.Write($"{node.Data} ");
            PrintInOrder(node.Right);
        }
    }
}
