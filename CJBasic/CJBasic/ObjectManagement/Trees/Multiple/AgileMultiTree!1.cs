namespace CJBasic.ObjectManagement.Trees.Multiple
{
    using CJBasic.Collections;
    using CJBasic.Threading.Synchronize;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class AgileMultiTree<TVal> : MultiTree<TVal>, IAgileMultiTree<TVal>, IMultiTree<TVal> where TVal: IMTreeVal
    {
        [NonSerialized]
        protected IAgileNodePicker<TVal> agileNodePicker;
        [NonSerialized]
        private char sequenceCodeSplitter;

        public AgileMultiTree()
        {
            this.sequenceCodeSplitter = ',';
        }

        private MNode<TVal> AppendOffSprings(string nodeSequenceCode, string[] uppers)
        {
            MNode<TVal> nodeByPath = base.GetNodeByPath(nodeSequenceCode, this.sequenceCodeSplitter);
            if (nodeByPath != null)
            {
                return nodeByPath;
            }
            string idPath = uppers[0];
            MNode<TVal> root = base.Root;
            for (int i = 1; i < uppers.Length; i++)
            {
                idPath = idPath + this.sequenceCodeSplitter + uppers[i];
                MNode<TVal> node3 = base.GetNodeByPath(idPath, this.sequenceCodeSplitter);
                if (node3 == null)
                {
                    return this.DOAppendOffSprings(root, uppers, i);
                }
                root = node3;
            }
            return root;
        }

        private MNode<TVal> DOAppendOffSprings(MNode<TVal> current, string[] offSpringIDs, int startIndex)
        {
            MNode<TVal> node = current;
            for (int i = startIndex; i < offSpringIDs.Length; i++)
            {
                TVal child = this.agileNodePicker.Retrieve(offSpringIDs[i]);
                if (child == null)
                {
                    return null;
                }
                node = node.AddChild(child);
            }
            return node;
        }

        public MNode<TVal> EnsureNodeExist(string nodeSequenceCode)
        {
            using (base.SmartRWLocker.Lock(AccessMode.Write))
            {
                MNode<TVal> nodeByPath = base.GetNodeByPath(nodeSequenceCode, this.sequenceCodeSplitter);
                if (nodeByPath != null)
                {
                    return nodeByPath;
                }
                string[] uppers = nodeSequenceCode.Split(new char[] { this.sequenceCodeSplitter });
                if ((uppers[0] != base.Root.TheValue.CurrentID) || (uppers.Length < 2))
                {
                    return null;
                }
                return this.AppendOffSprings(nodeSequenceCode, uppers);
            }
        }

        public virtual void Initialize()
        {
            TVal rootVal = this.agileNodePicker.PickupRoot();
            IList<TVal> members = CollectionConverter.CopyAllToList<TVal>(this.agileNodePicker.RetrieveAll().Values);
            base.Initialize(rootVal, members);
        }

        public IAgileNodePicker<TVal> AgileNodePicker
        {
            set
            {
                this.agileNodePicker = value;
            }
        }

        public char SequenceCodeSplitter
        {
            get
            {
                return this.sequenceCodeSplitter;
            }
            set
            {
                this.sequenceCodeSplitter = value;
            }
        }
    }
}

