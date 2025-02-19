using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Generics___BinarySearchTree.Models
{
    internal class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> Root { get; set; }

        public BinaryTree()
        {
            Root = null;
        }

        public void Clear()
        {
            Root = null;
        }

        // Neue wert einfügen (Rekursive)
        public void Insert(T node)
        {
            Root = InsertRec(Root, node);
        }

        // Rekursive den richtige platzt suchen
        private BinaryTreeNode<T> InsertRec(BinaryTreeNode<T> node, T value)
        {
            // wenn stelle leer (noch kein Knot existiert) - neue Element erzeugen und da speichern 
            if (node == null)
            {
                return new BinaryTreeNode<T>(value);
            }

            // Wo soll ich gehe --- LINKS oder RECHTS
            if (value.CompareTo(node.Data) < 0)
            {
                node.Left = InsertRec(node.Left, value);
            }
            else if (value.CompareTo(node.Data) > 0)
            {
                node.Right = InsertRec(node.Right, value);
            }
            return node;
        }

        // Loschen (Rekursive)
        public void Delete(T value)
        {
            Root = DeleteRec(Root, value);
        }

        private BinaryTreeNode<T> DeleteRec(BinaryTreeNode<T> node, T value)
        {
            // Ob Node ist null passiert nichts
            if (node == null)
            {
                return null;
            }

            // Suchen der Knoten ( LINKS oder RECHTS )
            if (value.CompareTo(node.Data) < 0)
                node.Left = DeleteRec(node.Left, value);
            else if (value.CompareTo(node.Data) > 0)
                node.Right = DeleteRec(node.Right, value);
            else
            {
                // KNOTEN GEFUNDEN
                // FALLS Knoten hat keine Kinder ( ich kann nicht mehr tiefer gehen )
                if (node.Left == null)
                    return node.Right;
                else if (node.Right == null)
                    return node.Left;

                // Der kleinste Wert aus dem rechten Teilbaum (MinValue(node.Right)) wird als neuer Wert für den aktuellen Knoten übernommen.
                node.Data = MinValue(node.Right);
                // Der kleinste Wert wird aus dem rechten Teilbaum entfernt (DeleteRec(node.Right, node.Data)).
                node.Right = DeleteRec(node.Right, node.Data);
            }
            return node;
        }
        private T MinValue(BinaryTreeNode<T> node)
        {
            T minv = node.Data;
            while (node.Left != null)
            {
                minv = node.Left.Data;
                node = node.Left;
            }
            return minv;
        }

        public bool Contains(T value)
        {
            return Search(value) != null;
        }

        public BinaryTreeNode<T> Search(T value)
        {
            return SearchRec(Root, value);
        }

        private BinaryTreeNode<T> SearchRec(BinaryTreeNode<T> node, T value)
        {
            if (node == null || node.Data.CompareTo(value) == 0)
                return node;

            return value.CompareTo(node.Data) < 0 ? SearchRec(node.Left, value) : SearchRec(node.Right, value);
        }
        public void PrintInorder()
        {
            PrintInorderRec(Root);
            Console.WriteLine();
        }

        private void PrintInorderRec(BinaryTreeNode<T> node)
        {
            if (node == null)
                return;

            PrintInorderRec(node.Left);
            Console.Write(node.Data + " ");
            PrintInorderRec(node.Right);
        }
    }
}
