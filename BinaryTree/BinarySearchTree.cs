using System;
using System.Collections.Generic;
using System.Text;

namespace DUABinaryTree
{
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
            // Wenn Root leer ist, soll der neue Knoten als Root eingefügt werden:
            if (Root == null) 
            {
                Root = new Node<T>(pData);
            }
            // Ansonsten soll ein rekursiver Aufruf, zum Finden der passenden Stelle zum Einfügen, gestartet werden:
            else
            {
                RekursivInsert(Root, pData);
            }
        }

        private void RekursivInsert(Node<T> pRoot, T pData)
        {
            // Wenn das neue Element so groß oder kleiner ist wie Root, soll mit dem linken Teilbaum fortgefahren werden:
            if (pData.CompareTo(pRoot.Data) <= 0) 
            {
                // Wenn der linke Teilbaum leer ist, kann der Knoten als linker Nachfolger von Root eingefügt werden:
                if(pRoot.LeftChild == null)
                {
                    pRoot.LeftChild = new Node<T>(pData);
                } 
                // Wenn nicht soll der rekursive Aufruf mit dem linken Teilbaum von Root fortgeführt werden:
                else
                {
                    RekursivInsert(pRoot.LeftChild, pData);
                }
            }
            // Wenn das neue Element größer ist als Root, soll mit dem rechten Teilbaum fortgefahren werden:
            else
            {
                // Wenn der rechte Teilbaum leer ist, kann der Knoten als rechter Nachfolger von Root eingefügt werden:
                if (pRoot.RightChild == null)
                {
                    pRoot.RightChild = new Node<T>(pData);
                }
                // Wenn nicht soll der rekursive Aufruf mit dem rechten Teilbaum von Root fortgeführt werden:
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
            // Wenn pRoot leer ist, ist ausgeschlossen, dass sich das gesuchte Element im Suchbaum befindet und es wird false zurückgegeben:
            if(pRoot == null)
            {
                return false;
            }
            // Wenn das gesuchte Element dem Inhalt von pRoot entspricht, wurde das Element gefunden und es true zurückgegeben:
            else if(pData.CompareTo(pRoot.Data) == 0)
            {
                return true;
            } 
            // Wenn das gesuchte Element kleiner ist als der Inhalt von pRoot, soll im linken Teilbaum von pRoot weitergesucht werden:
            else if(pData.CompareTo(pRoot.Data) < 1)
            {
                return RekursivSearch(pRoot.LeftChild, pData);
            }
            // Wenn das gesuchte Element größer ist als der Inhalt von pRoot, soll im rechten Teilbaum von pRoot weitergesucht werden:
            else
            {
                return RekursivSearch(pRoot.RightChild, pData);
            }
        }

        /// <summary>
        /// Entfernt ein Element aus dem Binären Suchbaum.
        /// </summary>
        /// <param name="pData"> Das zu entfernende Element </param>
        /// <returns> True, wenn das Element erfolgreich gelöscht wurde. False, wenn pData nicht im Baum gefunden wurde. </returns>
        public bool Remove(T pData)
        {
            Node<T> startReference = null;
            return RekursivRemove(Root, ref startReference, pData);
        }

        private bool RekursivRemove(Node<T> pRoot, ref Node<T> pParentsReference, T pData)
        {
            // Wenn pRoot == null ist, ist der (Teil-)Baum leer und das zu löschende Element ist nicht im Binären Suchbaum vorhanden:
            if(pRoot == null)
            {
                Console.WriteLine("Das zu entfernende Element ist nicht im Baum vorhanden.");
                return false;
            }
            // Wenn das zu löschende Element pRoot entspricht:
            else if (pData.CompareTo(pRoot.Data) == 0)
            {
                // Wenn das zu löschende Element keine Nachfolger hat:
                if(pRoot.LeftChild == null && pRoot.RightChild == null)
                {
                    // Entferne den Verweis auf das zu löschende Element in seinem Vater-Knoten. 
                    pParentsReference = null;
                }
                // Wenn das zu löschende Element nur einen rechten Nachfolger hat:
                else if(pRoot.RightChild != null)
                {
                    // Ändere den Verweis auf das zu löschende Element in seinem Vater-Knoten auf den rechten Nachfolger des zu löschenden Elements.
                    pParentsReference = pRoot.RightChild;
                }
                // Wenn das zu löschende Element nur einen linken Nachfolger hat:
                else if (pRoot.LeftChild != null)
                {
                    // Ändere den Verweis auf das zu löschende Element in seinem Vater-Knoten auf den linken Nachfolger des zu löschenden Elements.
                    pParentsReference = pRoot.LeftChild;
                }
                // Wenn das zu löschende Element sowohl einen linken als auch einen rechten Nachfolger besitzt:
                else
                {
                    // Finde das kleinste Element des rechten Teilbaums vom zu löschenden Element.
                    Node<T> leftmostNodeOfRightTree = RekursivLeftmostNode(pRoot.RightChild);

                    // Ersetze den zu löschenden Knoten mit diesem kleinsten Element.
                    leftmostNodeOfRightTree.LeftChild = pRoot.LeftChild;
                    leftmostNodeOfRightTree.RightChild = pRoot.RightChild;
                    pParentsReference = leftmostNodeOfRightTree;
                }
                return true;
            }
            // Wenn das zu löschende Element kleiner ist als pRoot, soll im linken Teilbaum weiter gesucht werden:
            else if (pData.CompareTo(pRoot.Data) < 1)
            {
                return RekursivRemove(pRoot.LeftChild, ref pRoot.leftChild, pData);
            }
            // Wenn das zu löschende Element größer ist als pRoot, soll im rechten Teilbaum weiter gesucht werden:
            else
            {
                return RekursivRemove(pRoot.RightChild, ref pRoot.rightChild, pData);
            }
        }        
    }
}
