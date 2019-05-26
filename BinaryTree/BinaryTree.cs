using System;
using System.Collections.Generic;
using System.Text;

namespace DUABinaryTree
{
    class BinaryTree<T>
    {
        public Node<T> Root { get; protected set; }

        public BinaryTree() { }

        public BinaryTree(T pRoot)
        {
            Root = new Node<T>(pRoot);
        }

        /// <summary>
        /// Gibt den Gesamten Binären Baum in der Preorder-Reihenfolge aus.
        /// </summary>
        public void TraversePreorder()
        {
            Console.WriteLine("Preorder:");
            RekursivTraversePreorder(Root);
        }

        private void RekursivTraversePreorder(Node<T> pRoot)
        {
            if (pRoot == null)
            {
                return;
            }
            Console.WriteLine(pRoot.Data);
            RekursivTraversePreorder(pRoot.LeftChild);
            RekursivTraversePreorder(pRoot.RightChild);
        }

        /// <summary>
        /// Gibt den Gesamten Binären Baum in der Inorder-Reihenfolge aus.
        /// </summary>
        public void TraverseInorder()
        {
            Console.WriteLine("Inorder:");
            RekursivTraverseInorder(Root);
        }

        private void RekursivTraverseInorder(Node<T> pRoot)
        {
            if (pRoot == null)
            {
                return;
            }
            RekursivTraverseInorder(pRoot.LeftChild);
            Console.WriteLine(pRoot.Data);
            RekursivTraverseInorder(pRoot.RightChild);
        }

        /// <summary>
        /// Gibt den Gesamten Binären Baum in der Postorder-Reihenfolge aus.
        /// </summary>
        public void TraversePostorder()
        {
            Console.WriteLine("Postorder:");
            RekursivTraversePostorder(Root);
        }

        private void RekursivTraversePostorder(Node<T> pRoot)
        {
            if (pRoot == null)
            {
                return;
            }
            RekursivTraversePostorder(pRoot.LeftChild);
            RekursivTraversePostorder(pRoot.RightChild);
            Console.WriteLine(pRoot.Data);
        }

        protected Node<T> RekursivLeftmostNode(Node<T> pRoot, ref Node<T> pParentNode)
        {
            if (pRoot.LeftChild == null)
            {
                return pRoot;
            }
            pParentNode = pRoot;
            return RekursivLeftmostNode(pRoot.LeftChild, ref pParentNode);
        }
    }
}
