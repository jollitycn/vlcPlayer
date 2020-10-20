namespace CJBasic.ObjectManagement.Trees.KDimension
{
    using System;

    public class KDNode<T> where T: IKDTreeVal, IEquatable<T>
    {
        private int depth;
        private KDNode<T> left;
        private KDNode<T> right;
        private T theValue;

        public KDNode(T val, int _depth)
        {
            this.left = null;
            this.right = null;
            this.theValue = val;
            this.depth = _depth;
        }

        public override string ToString()
        {
            return this.theValue.ToString();
        }

        public int Depth
        {
            get
            {
                return this.depth;
            }
            set
            {
                this.depth = value;
            }
        }

        internal KDNode<T> Left
        {
            get
            {
                return this.left;
            }
            set
            {
                this.left = value;
            }
        }

        internal KDNode<T> Right
        {
            get
            {
                return this.right;
            }
            set
            {
                this.right = value;
            }
        }

        public T TheValue
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

