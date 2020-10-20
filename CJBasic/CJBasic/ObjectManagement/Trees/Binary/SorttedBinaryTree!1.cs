namespace CJBasic.ObjectManagement.Trees.Binary
{
    using System;
    using System.Collections.Generic;

    public class SorttedBinaryTree<TVal> : ISorttedBinaryTree<TVal>, IBinaryTree<TVal> where TVal: IComparable
    {
        protected CJBasic.ObjectManagement.Trees.Binary.Node<TVal> root;

        public SorttedBinaryTree()
        {
            this.root = null;
        }

        private int ComputeDepth(CJBasic.ObjectManagement.Trees.Binary.Node<TVal> leaf)
        {
            int num = 1;
            for (CJBasic.ObjectManagement.Trees.Binary.Node<TVal> node = leaf; node.Parent != null; node = node.Parent)
            {
                num++;
            }
            return num;
        }

        public bool Contains(TVal var)
        {
            return (this.Get(var) != null);
        }

        private void CountAllNodes(CJBasic.ObjectManagement.Trees.Binary.Node<TVal> childTreeRoot, ref int count)
        {
            if (childTreeRoot != null)
            {
                count++;
                this.CountAllNodes(childTreeRoot.LeftChild, ref count);
                this.CountAllNodes(childTreeRoot.RightChild, ref count);
            }
        }

        private void DoGetAllNodes(CJBasic.ObjectManagement.Trees.Binary.Node<TVal> childTreeRoot, bool ascend, ref IList<CJBasic.ObjectManagement.Trees.Binary.Node<TVal>> list, TraverseMode mode)
        {
            if (childTreeRoot != null)
            {
                if (mode == TraverseMode.MidOrder)
                {
                    if (ascend)
                    {
                        this.DoGetAllNodes(childTreeRoot.LeftChild, ascend, ref list, mode);
                        list.Add(childTreeRoot);
                        this.DoGetAllNodes(childTreeRoot.RightChild, ascend, ref list, mode);
                    }
                    else
                    {
                        this.DoGetAllNodes(childTreeRoot.RightChild, ascend, ref list, mode);
                        list.Add(childTreeRoot);
                        this.DoGetAllNodes(childTreeRoot.LeftChild, ascend, ref list, mode);
                    }
                }
                else if (mode == TraverseMode.PreOrder)
                {
                    list.Add(childTreeRoot);
                    this.DoGetAllNodes(childTreeRoot.LeftChild, ascend, ref list, mode);
                    this.DoGetAllNodes(childTreeRoot.RightChild, ascend, ref list, mode);
                }
                else
                {
                    this.DoGetAllNodes(childTreeRoot.LeftChild, ascend, ref list, mode);
                    this.DoGetAllNodes(childTreeRoot.RightChild, ascend, ref list, mode);
                    list.Add(childTreeRoot);
                }
            }
        }

        public CJBasic.ObjectManagement.Trees.Binary.Node<TVal> Get(TVal theValue)
        {
            if (this.root != null)
            {
                if (theValue.CompareTo(this.root.TheValue) == 0)
                {
                    return this.root;
                }
                CJBasic.ObjectManagement.Trees.Binary.Node<TVal> root = this.root;
                while (root != null)
                {
                    int num = theValue.CompareTo(root.TheValue);
                    if (num == 0)
                    {
                        return root;
                    }
                    if (num > 0)
                    {
                        root = root.RightChild;
                    }
                    else
                    {
                        root = root.LeftChild;
                    }
                }
            }
            return null;
        }

        public IList<CJBasic.ObjectManagement.Trees.Binary.Node<TVal>> GetAllNodesAscend(bool ascend)
        {
            IList<CJBasic.ObjectManagement.Trees.Binary.Node<TVal>> list = new List<CJBasic.ObjectManagement.Trees.Binary.Node<TVal>>();
            this.DoGetAllNodes(this.root, ascend, ref list, TraverseMode.MidOrder);
            return list;
        }

        private int GetDepth()
        {
            IList<CJBasic.ObjectManagement.Trees.Binary.Node<TVal>> allNodesAscend = this.GetAllNodesAscend(true);
            if (allNodesAscend == null)
            {
                return 0;
            }
            IList<int> list2 = new List<int>();
            foreach (CJBasic.ObjectManagement.Trees.Binary.Node<TVal> node in allNodesAscend)
            {
                if (node.IsLeaf)
                {
                    list2.Add(this.ComputeDepth(node));
                }
            }
            int num = list2[0];
            foreach (int num2 in list2)
            {
                if (num2 > num)
                {
                    num = num2;
                }
            }
            return num;
        }

        public CJBasic.ObjectManagement.Trees.Binary.Node<TVal> GetMaxNode(CJBasic.ObjectManagement.Trees.Binary.Node<TVal> childTree)
        {
            CJBasic.ObjectManagement.Trees.Binary.Node<TVal> rightChild = childTree;
            if (childTree.RightChild != null)
            {
                rightChild = childTree.RightChild;
            }
            return rightChild;
        }

        public CJBasic.ObjectManagement.Trees.Binary.Node<TVal> GetMinNode(CJBasic.ObjectManagement.Trees.Binary.Node<TVal> childTree)
        {
            CJBasic.ObjectManagement.Trees.Binary.Node<TVal> leftChild = childTree;
            if (childTree.LeftChild != null)
            {
                leftChild = childTree.LeftChild;
            }
            return leftChild;
        }

        public virtual void Insert(TVal theValue)
        {
            if (this.root == null)
            {
                this.root = new CJBasic.ObjectManagement.Trees.Binary.Node<TVal>(theValue, null);
            }
            else
            {
                CJBasic.ObjectManagement.Trees.Binary.Node<TVal> root = this.root;
                while (true)
                {
                    int num = theValue.CompareTo(root.TheValue);
                    if (num == 0)
                    {
                        return;
                    }
                    if (num > 0)
                    {
                        if (root.RightChild == null)
                        {
                            root.RightChild = new CJBasic.ObjectManagement.Trees.Binary.Node<TVal>(theValue, root);
                            return;
                        }
                        root = root.RightChild;
                    }
                    else
                    {
                        if (root.LeftChild == null)
                        {
                            root.LeftChild = new CJBasic.ObjectManagement.Trees.Binary.Node<TVal>(theValue, root);
                            return;
                        }
                        root = root.LeftChild;
                    }
                }
            }
        }

        public virtual void Remove(TVal theValue)
        {
            this.Remove(theValue, ref this.root);
        }

        private void Remove(TVal theValue, ref CJBasic.ObjectManagement.Trees.Binary.Node<TVal> node)
        {
            if (node != null)
            {
                if (node.TheValue.CompareTo(theValue) == 0)
                {
                    CJBasic.ObjectManagement.Trees.Binary.Node<TVal> parent;
                    if ((node.LeftChild != null) && (node.RightChild != null))
                    {
                        CJBasic.ObjectManagement.Trees.Binary.Node<TVal> minNode = this.GetMinNode(node.RightChild);
                        if (minNode.Parent.TheValue.CompareTo(theValue) == 0)
                        {
                            parent = node.Parent;
                            minNode.LeftChild = node.LeftChild;
                            node = minNode;
                            node.Parent = parent;
                        }
                        else
                        {
                            minNode.Parent.LeftChild = minNode.RightChild;
                            if (minNode.RightChild != null)
                            {
                                minNode.RightChild.Parent = minNode.Parent;
                            }
                            node.TheValue = minNode.TheValue;
                        }
                    }
                    else if (node.LeftChild != null)
                    {
                        parent = node.Parent;
                        node = node.LeftChild;
                        node.Parent = parent;
                    }
                    else if (node.RightChild != null)
                    {
                        parent = node.Parent;
                        node = node.RightChild;
                        node.Parent = parent;
                    }
                    else
                    {
                        node = null;
                    }
                }
                else if (theValue.CompareTo(node.TheValue) < 0)
                {
                    CJBasic.ObjectManagement.Trees.Binary.Node<TVal> leftChild = node.LeftChild;
                    this.Remove(theValue, ref leftChild);
                    node.LeftChild = leftChild;
                }
                else
                {
                    CJBasic.ObjectManagement.Trees.Binary.Node<TVal> rightChild = node.RightChild;
                    this.Remove(theValue, ref rightChild);
                    node.RightChild = rightChild;
                }
            }
        }

        public IList<CJBasic.ObjectManagement.Trees.Binary.Node<TVal>> Traverse(TraverseMode mode)
        {
            IList<CJBasic.ObjectManagement.Trees.Binary.Node<TVal>> list = new List<CJBasic.ObjectManagement.Trees.Binary.Node<TVal>>();
            switch (mode)
            {
                case TraverseMode.PreOrder:
                    this.DoGetAllNodes(this.root, true, ref list, TraverseMode.PreOrder);
                    return list;

                case TraverseMode.MidOrder:
                    this.DoGetAllNodes(this.root, true, ref list, TraverseMode.MidOrder);
                    return list;

                case TraverseMode.PostOrder:
                    this.DoGetAllNodes(this.root, true, ref list, TraverseMode.PostOrder);
                    return list;
            }
            throw new Exception("Error TraverseMode !");
        }

        public int Count
        {
            get
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

        public int Depth
        {
            get
            {
                return this.GetDepth();
            }
        }

        public CJBasic.ObjectManagement.Trees.Binary.Node<TVal> Root
        {
            get
            {
                return this.root;
            }
        }
    }
}

