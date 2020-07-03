using System;
using System.Collections.Generic;
using System.Text;

namespace DUABinaryTree
{
    class Node<T>
    {
        public T Data { get; private set; }
        internal Node<T> leftChild;
        internal Node<T> rightChild;
        public Node<T> LeftChild
        {
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

}
