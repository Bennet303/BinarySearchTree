using System;
using System.Collections.Generic;
using System.Text;

namespace BalancedBinaryTree
{
    class BalancedBinaryTree<T>
    {
        List<Node<T>> NodesWithoutChilds;
        Node<T> Root;
        public delegate void delAddChild(Node<T> pParentNode, Node<T> pNewNode);

        public BalancedBinaryTree(T pRootContent)
        {
            NodesWithoutChilds = new List<Node<T>>();           
            Root = new Node<T>(pRootContent, HandleNewChild);
            NodesWithoutChilds.Add(Root);
        }

        public void AddNodeBalanced(T pContent)
        {
            Node<T> parentNode = NodesWithoutChilds[0];
            //Node<T> newNode = new Node<T>(pContent, HandleNewChild);
            parentNode.AddChild(pContent);
            //if (parentNode.LeftChild == null)
            //{
            //    parentNode.LeftChild = newNode;
            //}
            //else
            //{
            //    parentNode.RightChild = newNode;
            //    NodesWithoutChilds.RemoveAt(0);
            //}
            //NodesWithoutChilds.Add(newNode);
        }

        public void HandleNewChild(Node<T> pParentNode, Node<T> pNewNode)
        {            
            NodesWithoutChilds.Add(pNewNode);
            if (pParentNode.RightChild != null)
            {
                NodesWithoutChilds.Remove(pParentNode);
            }
        }
        
    }

    class Node<T>
    {
        public T Content;
        public Node<T> LeftChild;
        public Node<T> RightChild;
        internal bool IsLeaf;
        
        private BalancedBinaryTree<T>.delAddChild DelegateAddChild;

        internal Node(T pContent, BalancedBinaryTree<T>.delAddChild pAddChild)
        {
            Content = pContent;
            DelegateAddChild = pAddChild;
            IsLeaf = true;
        }

        public void AddChild(T pContent)
        {
            Node<T> newNode = new Node<T>(pContent, DelegateAddChild);
            if (this.LeftChild == null)
            {
                this.LeftChild = newNode;
            }
            else
            {
               this.RightChild = newNode;
            }
            DelegateAddChild(this, newNode);
            IsLeaf = false;
        }
    }



}
