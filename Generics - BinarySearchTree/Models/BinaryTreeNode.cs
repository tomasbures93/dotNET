using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics___BinarySearchTree.Models
{
    public class BinaryTreeNode<T> where T : IComparable<T>
    {
        public BinaryTreeNode(T value)
        {
            Data = value;                                   // wert welche wurde gespeichert
        }
        public T Data { get; set; }
        public BinaryTreeNode<T> Left { get; set; }         // Nummer links
        public BinaryTreeNode<T> Right { get; set; }        // Nummer rechts
    }

}
