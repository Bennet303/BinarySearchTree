using System;

namespace DUABinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> binärerSuchbaum = new BinarySearchTree<int>();
            int[] inhalt = new int[] { 12, 15, 11, 4, 7, 1, 8, 8, 20, 26 };
            foreach(var i in inhalt)
            {
                binärerSuchbaum.Insert(i);
            }

            binärerSuchbaum.TraversePreorder();
            binärerSuchbaum.TraverseInorder();
            binärerSuchbaum.TraversePostorder();

            Console.WriteLine($"Suche nach 7:{binärerSuchbaum.Search(7)}");
            Console.WriteLine($"Suche nach 9:{binärerSuchbaum.Search(9)}");

            binärerSuchbaum.Remove(7);

            binärerSuchbaum.TraverseInorder();
        }
    }
}


