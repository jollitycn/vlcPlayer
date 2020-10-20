namespace CJBasic.ObjectManagement.Trees.Multiple
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class MNode<TVal> where TVal: IMTreeVal
    {
        private IList<MNode<TVal>> children;
        private MNode<TVal> parent;
        private TVal theValue;

        public MNode()
        {
            this.theValue = default(TVal);
            this.children = new List<MNode<TVal>>();
        }

        public MNode(TVal val, MNode<TVal> _parent)
        {
            this.theValue = default(TVal);
            this.children = new List<MNode<TVal>>();
            this.theValue = val;
            this.parent = _parent;
        }

        public MNode<TVal> AddChild(TVal child)
        {
            MNode<TVal> item = new MNode<TVal>(child, (MNode<TVal>) this);
            this.children.Add(item);
            return item;
        }

        public override string ToString()
        {
            return this.theValue.ToString();
        }

        public IList<MNode<TVal>> Children
        {
            get
            {
                return this.children;
            }
            set
            {
                this.children = value;
            }
        }

        public MNode<TVal> Parent
        {
            get
            {
                return this.parent;
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

