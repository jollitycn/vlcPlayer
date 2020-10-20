namespace CJBasic.ObjectManagement.Trees.Multiple
{
    using CJBasic;
    using CJBasic.Threading.Synchronize;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class MultiTree<TVal> : IMultiTree<TVal> where TVal: IMTreeVal
    {
        [NonSerialized]
        private CJBasic.Threading.Synchronize.SmartRWLocker _smartRWLocker;
        private MNode<TVal> root;

        public MultiTree()
        {
            this._smartRWLocker = null;
        }

        public void ActionOnEachNode(CbGeneric<MNode<TVal>> action)
        {
            if (this.root != null)
            {
                this.DoActionOnEach(action, this.root);
            }
        }

        private void CountAllNodes(MNode<TVal> childTreeRoot, ref int count)
        {
            if (childTreeRoot != null)
            {
                count++;
                foreach (MNode<TVal> node in childTreeRoot.Children)
                {
                    this.CountAllNodes(node, ref count);
                }
            }
        }

        private void DoActionOnEach(CbGeneric<MNode<TVal>> action, MNode<TVal> node)
        {
            action(node);
            foreach (MNode<TVal> node2 in node.Children)
            {
                this.DoActionOnEach(action, node2);
            }
        }

        private void DoGetLeaves(MNode<TVal> node, ref IList<TVal> leafList)
        {
            if ((node.Children == null) || (node.Children.Count == 0))
            {
                leafList.Add(node.TheValue);
            }
            else
            {
                foreach (MNode<TVal> node2 in node.Children)
                {
                    this.DoGetLeaves(node2, ref leafList);
                }
            }
        }

        private MNode<TVal> DoGetNode(MNode<TVal> curNode, string ValID)
        {
            foreach (MNode<TVal> node in curNode.Children)
            {
                if (node.TheValue.CurrentID == ValID)
                {
                    return node;
                }
            }
            foreach (MNode<TVal> node in curNode.Children)
            {
                MNode<TVal> node2 = this.DoGetNode(node, ValID);
                if (node2 != null)
                {
                    return node2;
                }
            }
            return null;
        }

        private void DoGetNodesOnDepthIndex(ref IList<MNode<TVal>> list, MNode<TVal> curNode, int curDepthIndex, int targetDepthIndex)
        {
            if (curDepthIndex == (targetDepthIndex - 1))
            {
                foreach (MNode<TVal> node in curNode.Children)
                {
                    list.Add(node);
                }
            }
            else
            {
                foreach (MNode<TVal> node in curNode.Children)
                {
                    this.DoGetNodesOnDepthIndex(ref list, node, curDepthIndex + 1, targetDepthIndex);
                }
            }
        }

        private void DoGetOffsprings(MNode<TVal> curNode, ref IList<MNode<TVal>> list)
        {
            foreach (MNode<TVal> node in curNode.Children)
            {
                list.Add(node);
                this.DoGetOffsprings(node, ref list);
            }
        }

        private void FillChildren(MNode<TVal> father, IList<TVal> members)
        {
            foreach (TVal local in members)
            {
                if ((local.FatherID == father.TheValue.CurrentID) && (local.CurrentID != father.TheValue.CurrentID))
                {
                    father.AddChild(local);
                }
            }
            foreach (MNode<TVal> node in father.Children)
            {
                this.FillChildren(node, members);
            }
        }

        public List<MNode<TVal>> GetFamilyByPath(string idPath, char separator)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                string[] strArray = idPath.Split(new char[] { separator });
                if (strArray[0] != this.root.TheValue.CurrentID)
                {
                    return null;
                }
                List<MNode<TVal>> list = new List<MNode<TVal>>();
                list.Add(this.root);
                MNode<TVal> root = this.root;
                for (int i = 1; i < strArray.Length; i++)
                {
                    bool flag = false;
                    foreach (MNode<TVal> node2 in root.Children)
                    {
                        if (node2.TheValue.CurrentID == strArray[i])
                        {
                            list.Add(node2);
                            root = node2;
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        return null;
                    }
                }
                return list;
            }
        }

        public IList<TVal> GetLeaves(string idPath, char separator)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                IList<TVal> leafList = new List<TVal>();
                MNode<TVal> nodeByPath = this.GetNodeByPath(idPath, separator);
                if (nodeByPath != null)
                {
                    this.DoGetLeaves(nodeByPath, ref leafList);
                }
                return leafList;
            }
        }

        public MNode<TVal> GetNodeByID(string valID)
        {
            if (valID == this.root.TheValue.CurrentID)
            {
                return this.root;
            }
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                return this.DoGetNode(this.root, valID);
            }
        }

        public MNode<TVal> GetNodeByPath(string idPath, char separator)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                string[] strArray = idPath.Split(new char[] { separator });
                if (strArray[0] != this.root.TheValue.CurrentID)
                {
                    return null;
                }
                MNode<TVal> root = this.root;
                for (int i = 1; i < strArray.Length; i++)
                {
                    bool flag = false;
                    foreach (MNode<TVal> node2 in root.Children)
                    {
                        if (node2.TheValue.CurrentID == strArray[i])
                        {
                            root = node2;
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        return null;
                    }
                }
                return root;
            }
        }

        public IList<MNode<TVal>> GetNodesOnDepthIndex(int depthIndex)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                IList<MNode<TVal>> list = new List<MNode<TVal>>();
                if (depthIndex == 0)
                {
                    list.Add(this.root);
                    return list;
                }
                this.DoGetNodesOnDepthIndex(ref list, this.root, 0, depthIndex);
                return list;
            }
        }

        public IList<MNode<TVal>> GetNodesOnDepthIndex(string idPath, char separator, int depthIndex)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                int num = idPath.Split(new char[] { separator }).Length - 1;
                if (num > depthIndex)
                {
                    return null;
                }
                MNode<TVal> nodeByPath = this.GetNodeByPath(idPath, separator);
                if (nodeByPath == null)
                {
                    return null;
                }
                MultiTree<TVal> tree = new MultiTree<TVal>();
                tree.Initialize(nodeByPath);
                return tree.GetNodesOnDepthIndex(depthIndex - num);
            }
        }

        public IList<MNode<TVal>> GetOffsprings(string valID)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                MNode<TVal> nodeByID = this.GetNodeByID(valID);
                if (nodeByID == null)
                {
                    return null;
                }
                IList<MNode<TVal>> list = new List<MNode<TVal>>();
                this.DoGetOffsprings(nodeByID, ref list);
                return list;
            }
        }

        public virtual void Initialize(MNode<TVal> _rootNode)
        {
            this.root = _rootNode;
        }

        public virtual void Initialize(TVal rootVal, IList<TVal> members)
        {
            if ((rootVal == null) || (members == null))
            {
                throw new Exception("Root must not be null!");
            }
            this.root = new MNode<TVal>(rootVal, null);
            if (this.root.TheValue.DepthIndex != 0)
            {
                this.FillChildren(this.root, members);
            }
            else
            {
                IDictionary<int, IList<TVal>> dictionary = new Dictionary<int, IList<TVal>>();
                foreach (TVal local in members)
                {
                    if (local.DepthIndex < 0)
                    {
                        throw new Exception("Not all DepthIndex is Valid !");
                    }
                    if (!dictionary.ContainsKey(local.DepthIndex))
                    {
                        dictionary.Add(local.DepthIndex, new List<TVal>());
                    }
                    dictionary[local.DepthIndex].Add(local);
                }
                IList<TVal>[] memberLayerAry = new IList<TVal>[dictionary.Count];
                if (!dictionary.ContainsKey(0))
                {
                    dictionary.Add(0, new List<TVal>());
                    dictionary[0].Add(this.root.TheValue);
                }
                for (int i = 0; i < dictionary.Count; i++)
                {
                    if (!dictionary.ContainsKey(i))
                    {
                        throw new Exception("DepthIndex are not continuous !");
                    }
                    memberLayerAry[i] = dictionary[i];
                }
                this.InitializeFromLayer(memberLayerAry);
            }
        }

        private void InitializeFromLayer(IList<TVal>[] memberLayerAry)
        {
            if ((memberLayerAry == null) || (memberLayerAry[0].Count != 1))
            {
                throw new Exception("Root must not be null and root must be unique!");
            }
            this.root = new MNode<TVal>(memberLayerAry[0][0], null);
            IDictionary<string, MNode<TVal>> dictionary = new Dictionary<string, MNode<TVal>>();
            dictionary.Add(this.root.TheValue.CurrentID, this.root);
            for (int i = 1; i < memberLayerAry.Length; i++)
            {
                IDictionary<string, MNode<TVal>> dictionary2 = new Dictionary<string, MNode<TVal>>();
                IList<TVal> list = memberLayerAry[i];
                foreach (TVal local in list)
                {
                    if (!dictionary.ContainsKey(local.FatherID))
                    {
                        throw new Exception(string.Format("The parent of [{0}] named [{1}] not found !", local.CurrentID, local.FatherID));
                    }
                    MNode<TVal> node = dictionary[local.FatherID].AddChild(local);
                    dictionary2.Add(node.TheValue.CurrentID, node);
                }
                dictionary = dictionary2;
            }
        }

        public int Count
        {
            get
            {
                using (this.SmartRWLocker.Lock(AccessMode.Read))
                {
                    if (this.root == null)
                    {
                        return 0;
                    }
                    int count = 1;
                    this.CountAllNodes(this.root, ref count);
                    return count;
                }
            }
        }

        public MNode<TVal> Root
        {
            get
            {
                return this.root;
            }
        }

        protected CJBasic.Threading.Synchronize.SmartRWLocker SmartRWLocker
        {
            get
            {
                if (this._smartRWLocker == null)
                {
                    this._smartRWLocker = new CJBasic.Threading.Synchronize.SmartRWLocker();
                }
                return this._smartRWLocker;
            }
        }
    }
}

