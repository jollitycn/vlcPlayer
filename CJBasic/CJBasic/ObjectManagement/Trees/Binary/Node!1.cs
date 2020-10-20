namespace CJBasic.ObjectManagement.Trees.Binary
{
    using System;

    [Serializable]
    public class Node<TVal> where TVal: IComparable
    {
        private int balanceFactor;
        private Node<TVal> leftChild;
        private Node<TVal> parent;
        private Node<TVal> rightChild;
        private TVal theValue;

        public Node()
        {
            this.balanceFactor = 0;
        }

        public Node(TVal _theValue, Node<TVal> _parent)
        {
            this.balanceFactor = 0;
            this.theValue = _theValue;
            this.parent = _parent;
        }

        public override string ToString()
        {
            return this.theValue.ToString();
        }

        public int BalanceFactor
        {
            get
            {
                return this.balanceFactor;
            }
            set
            {
                this.balanceFactor = value;
            }
        }

        public bool IsLeaf
        {
            get
            {
                return ((this.leftChild == null) && (this.rightChild == null));
            }
        }

        public Node<TVal> LeftChild
        {
            get
            {
                return this.leftChild;
            }
            set
            {
                this.leftChild = value;
            }
        }

        public Node<TVal> Parent
        {
            get
            {
                return this.parent;
            }
            set
            {
                this.parent = value;
            }
        }

        public Node<TVal> RightChild
        {
            get
            {
                return this.rightChild;
            }
            set
            {
                this.rightChild = value;
            }
        }

        public TVal TheValue
        {
            get
            {
                return this.theValue;
            }
            set
            {
                this.theValue = value;
            }
        }
    }
}

