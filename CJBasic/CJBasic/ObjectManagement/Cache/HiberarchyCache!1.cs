namespace CJBasic.ObjectManagement.Cache
{
    using CJBasic.Collections;
    using CJBasic.ObjectManagement;
    using CJBasic.ObjectManagement.Trees.Multiple;
    using System;
    using System.Collections.Generic;

    public class HiberarchyCache<TVal> : IHiberarchyCache<TVal> where TVal: IHiberarchyVal
    {
        private IAgileMultiTree<TVal> agileMultiTree;
        private IObjectRetriever<string, TVal> objectRetriever;
        private string rootID;
        private char sequenceCodeSplitter;
        private ISmartDictionaryCache<string, TVal> smartDictionaryCache;

        public HiberarchyCache()
        {
            this.smartDictionaryCache = new SmartDictionaryCache<string, TVal>();
            this.agileMultiTree = new AgileMultiTree<TVal>();
            this.sequenceCodeSplitter = ',';
        }

        public MultiTree<TVal> CreateHiberarchyTree()
        {
            MultiTree<TVal> tree = new MultiTree<TVal>();
            tree.Initialize(this.agileMultiTree.Root);
            return tree;
        }

        public TVal Get(string id)
        {
            if (id == null)
            {
                return default(TVal);
            }
            if (this.smartDictionaryCache.HaveContained(id))
            {
                return this.smartDictionaryCache.Get(id);
            }
            TVal local = this.smartDictionaryCache.Get(id);
            if (local != null)
            {
                this.agileMultiTree.EnsureNodeExist(local.SequenceCode);
            }
            return local;
        }

        public IList<string> GetAllKeyListCopy()
        {
            return this.smartDictionaryCache.GetAllKeyListCopy();
        }

        public IList<TVal> GetAllValListCopy()
        {
            return this.smartDictionaryCache.GetAllValListCopy();
        }

        public int GetChildrenCount(string parentID)
        {
            TVal local = this.Get(parentID);
            if (local == null)
            {
                return 0;
            }
            return this.agileMultiTree.GetNodeByPath(local.SequenceCode, this.sequenceCodeSplitter).Children.Count;
        }

        public IList<TVal> GetChildrenOf(string parentID)
        {
            TVal local = this.Get(parentID);
            if (local == null)
            {
                return null;
            }
            return CollectionConverter.ConvertAll<MNode<TVal>, TVal>(this.agileMultiTree.GetNodeByPath(local.SequenceCode, this.sequenceCodeSplitter).Children, delegate (MNode<TVal> child) {
                return child.TheValue;
            });
        }

        public IList<TVal> GetNodesOnDepthIndex(int depthIndex)
        {
            return CollectionConverter.ConvertAll<MNode<TVal>, TVal>(this.agileMultiTree.GetNodesOnDepthIndex(depthIndex), delegate (MNode<TVal> node) {
                return node.TheValue;
            });
        }

        public IList<TVal> GetNodesOnDepthIndex(string parentID, int depthIndex)
        {
            TVal local = this.Get(parentID);
            if (local == null)
            {
                return null;
            }
            return CollectionConverter.ConvertAll<MNode<TVal>, TVal>(this.agileMultiTree.GetNodesOnDepthIndex(local.SequenceCode, this.sequenceCodeSplitter, depthIndex), delegate (MNode<TVal> node) {
                return node.TheValue;
            });
        }

        public bool HaveContained(string id)
        {
            return this.smartDictionaryCache.HaveContained(id);
        }

        public void Initialize()
        {
            this.smartDictionaryCache.ObjectRetriever = this.objectRetriever;
            this.smartDictionaryCache.Initialize();
            this.agileMultiTree.AgileNodePicker = new HiberarchyAgileNodePicker<TVal>(this.smartDictionaryCache, this.rootID);
            this.agileMultiTree.SequenceCodeSplitter = this.sequenceCodeSplitter;
            this.agileMultiTree.Initialize();
        }

        public int Count
        {
            get
            {
                return this.smartDictionaryCache.Count;
            }
        }

        public IObjectRetriever<string, TVal> ObjectRetriever
        {
            set
            {
                this.objectRetriever = value;
            }
        }

        public string RootID
        {
            set
            {
                this.rootID = value;
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

