using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Models
{
    internal class Node<T> where T : IComparable<T>
    {
        public Node<T> Left { get; set; } = null;
        public Node<T> Right { get; set; } = null;

        public T Data { get; set; }

        public Node(T value)
        {
            Data = value;
        }

        public void Add(T value)
        {
            if (value.CompareTo(Data) < 0)       // Left                weil CompareTo gibst uns negative wert zurück wenn das übergeordnete objekt ist kleiner als vergleichs objekt
            {
                if (Left == null)
                {
                    Left = new Node<T>(value);
                }
                else
                {
                    Left.Add(value);
                }
            }
            else                                // Right
            {
                if (Right == null)
                {
                    Right = new Node<T>(value);
                }
                else
                {
                    Right.Add(value);
                }
            }
        }
    }
}
