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
            if(pRoot == null)
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

        protected Node<T> RekursivLeftmostNode(Node<T> pRoot)
        {
            if (pRoot.LeftChild == null)
            {
                return pRoot;
            }
            return RekursivLeftmostNode(pRoot.LeftChild);
        }
    }

    class Node<T>
    {
        public T Data { get; private set; }
        internal Node<T> leftChild;
        internal Node<T> rightChild;
        public Node<T> LeftChild {
            get { return leftChild; }
            internal set { leftChild = value; }
        }
        public Node<T> RightChild
        {
            get { return rightChild; }
            internal set { rightChild = value; }
        }

        public Node(T pData)
        {
            Data = pData;
            LeftChild = null;
            RightChild = null;
        }
    }

    class BinarySearchTree<T> : BinaryTree<T> where T : IComparable
    {
        public BinarySearchTree() { }
        public BinarySearchTree(T pRoot) : base(pRoot) { }

        /// <summary>
        /// Fügt ein Element in den Binären Suchbaum ein.
        /// </summary>
        /// <param name="pData"> Das einzufügende Element </param>
        public void Insert(T pData)
        {
            // Wenn Root leer ist, soll der neue Knoten als Root eingefügt werden.
            if (Root == null) 
            {
                Root = new Node<T>(pData);
            }
            // Ansonsten soll ein rekursiver Aufruf, zum Finden der passenden Stelle zum Einfügen, gestartet werden.
            else
            {
                RekursivInsert(Root, pData);
            }
        }

        private void RekursivInsert(Node<T> pRoot, T pData)
        {
            // Wenn das neue Element so groß oder kleiner ist wie Root, soll mit dem linken Teilbaum fortgefahren werden.
            if (pData.CompareTo(pRoot.Data) <= 0) 
            {
                // Wenn der linke Teilbaum leer ist, kann der Knoten als linker Nachfolger von Root eingefügt werden.
                if(pRoot.LeftChild == null)
                {
                    pRoot.LeftChild = new Node<T>(pData);
                } 
                // Wenn nicht soll der rekursive Aufruf mit dem linken Teilbaum von Root fortgeführt werden.
                else
                {
                    RekursivInsert(pRoot.LeftChild, pData);
                }
            }
            // Wenn das neue Element größer ist als Root, soll mit dem rechten Teilbaum fortgefahren werden.
            else
            {
                // Wenn der rechte Teilbaum leer ist, kann der Knoten als rechter Nachfolger von Root eingefügt werden.
                if (pRoot.RightChild == null)
                {
                    pRoot.RightChild = new Node<T>(pData);
                }
                // Wenn nicht soll der rekursive Aufruf mit dem rechten Teilbaum von Root fortgeführt werden.
                else
                {
                    RekursivInsert(pRoot.RightChild, pData);
                }
            }
        }

        /// <summary>
        /// Sucht ein Element im Binären Suchbaum.
        /// </summary>
        /// <param name="pData"> Das gesuchte Element </param>
        /// <returns> True, wenn pData im Suchbaum vorhanden ist. False, wenn pData nicht im Suchbaum vorhanden oder der Suchbaum leer ist. </returns>
        public bool Search(T pData)
        {
            // Starte einen rekursiven Aufruf zum Suchen des Elements und gib dessen Ergebnis zurück.
            return RekursivSearch(Root, pData);
        }

        private bool RekursivSearch(Node<T> pRoot, T pData)
        {
            // Wenn pRoot leer ist, ist ausgeschlossen, dass sich das gesuchte Element im Suchbaum befindet und es wird false zurückgegeben.
            if(pRoot == null)
            {
                return false;
            }
            // Wenn das gesuchte Element dem Inhalt von pRoot entspricht, wurde das Element gefunden und es true zurückgegeben.
            else if(pData.CompareTo(pRoot.Data) == 0)
            {
                return true;
            } 
            // Wenn das gesuchte Element kleiner ist als der Inhalt von pRoot, soll im linken Teilbaum von pRoot weitergesucht werden.
            else if(pData.CompareTo(pRoot.Data) < 1)
            {
                return RekursivSearch(pRoot.LeftChild, pData);
            }
            // Wenn das gesuchte Element größer ist als der Inhalt von pRoot, soll im rechten Teilbaum von pRoot weitergesucht werden.
            else
            {
                return RekursivSearch(pRoot.RightChild, pData);
            }
        }

        public bool Remove(T pData)
        {
            Node<T> startReference = null;
            return RekursivRemove(Root, ref startReference, pData);
        }

        private bool RekursivRemove(Node<T> pRoot, ref Node<T> pParentsReference, T pData)
        {
            if(pRoot.Data == null)
            {
                Console.WriteLine("Das zu entfernende Element ist nicht im Baum vorhanden.");
                return false;
            }
            else if (pData.CompareTo(pRoot.Data) == 0)
            {
                if(pRoot.LeftChild == null && pRoot.RightChild == null)
                {
                    pParentsReference = null;
                }
                else if(pRoot.LeftChild == null)
                {
                    pParentsReference = pRoot.RightChild;
                }
                else if (pRoot.RightChild == null)
                {
                    pParentsReference = pRoot.LeftChild;
                }
                else
                {
                    Node<T> leftmostNodeOfRightTree = RekursivLeftmostNode(pRoot.RightChild);
                    leftmostNodeOfRightTree.LeftChild = pRoot.LeftChild;
                    leftmostNodeOfRightTree.RightChild = pRoot.RightChild;
                    pParentsReference = leftmostNodeOfRightTree;
                }
                return true;
            }
            else if (pData.CompareTo(pRoot.Data) < 1)
            {
                return RekursivRemove(pRoot.LeftChild, ref pRoot.leftChild, pData);
            }
            else
            {
                return RekursivRemove(pRoot.RightChild, ref pRoot.rightChild, pData);
            }
        }        
    }
}
