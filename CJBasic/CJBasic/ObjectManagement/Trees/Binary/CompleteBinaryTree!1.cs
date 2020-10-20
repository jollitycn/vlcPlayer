namespace CJBasic.ObjectManagement.Trees.Binary
{
    using CJBasic.Threading.Synchronize;
    using System;
    using System.Collections.Generic;

    public class CompleteBinaryTree<TVal> : IBinaryTree<TVal> where TVal: IComparable
    {
        [NonSerialized]
        protected CJBasic.Threading.Synchronize.SmartRWLocker _smartRWLocker;
        protected List<CJBasic.ObjectManagement.Trees.Binary.Node<TVal>> allNode;
        protected int count;
        protected CJBasic.ObjectManagement.Trees.Binary.Node<TVal> root;

        public CompleteBinaryTree()
        {
            this.allNode = new List<CJBasic.ObjectManagement.Trees.Binary.Node<TVal>>();
            this._smartRWLocker = null;
            this.count = 0;
        }

        public CJBasic.ObjectManagement.Trees.Binary.Node<TVal> Get(TVal val)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                foreach (CJBasic.ObjectManagement.Trees.Binary.Node<TVal> node in this.allNode)
                {
                    if (node.TheValue.CompareTo(val) == 0)
                    {
                        return node;
                    }
                }
                return null;
            }
        }

        public int GetFatherIndx(int nodeIndx)
        {
            if (nodeIndx == 0)
            {
                return -1;
            }
            if ((nodeIndx % 2) == 1)
            {
                return ((nodeIndx - 1) / 2);
            }
            return ((nodeIndx - 2) / 2);
        }

        public int GetIndxOfNode(TVal val)
        {
            for (int i = 0; i < this.allNode.Count; i++)
            {
                if (this.allNode[i].TheValue.CompareTo(val) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public int GetLayerOfNode(int nodeIndex)
        {
            return (((int) Math.Log((double) (nodeIndex + 1), 2.0)) + 1);
        }

        public int GetOppositeNodeIndx(int nodeIndx, bool isInRightTree)
        {
            int num = ((int) Math.Log((double) (nodeIndx + 1), 2.0)) + 1;
            if (isInRightTree)
            {
                return (nodeIndx - ((int) Math.Pow(2.0, (double) (num - 2))));
            }
            int num2 = nodeIndx + ((int) Math.Pow(2.0, (double) (num - 2)));
            if (num2 > (this.allNode.Count - 1))
            {
                return this.GetFatherIndx(num2);
            }
            return num2;
        }

        public virtual void Insert(TVal val)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Write))
            {
                CJBasic.ObjectManagement.Trees.Binary.Node<TVal> item = new CJBasic.ObjectManagement.Trees.Binary.Node<TVal>(val, null);
                if (this.root == null)
                {
                    this.root = item;
                }
                else
                {
                    int fatherIndx = this.GetFatherIndx(this.allNode.Count);
                    if ((this.allNode.Count % 2) == 1)
                    {
                        this.allNode[fatherIndx].LeftChild = item;
                        item.Parent = this.allNode[fatherIndx];
                    }
                    else
                    {
                        this.allNode[fatherIndx].RightChild = item;
                        item.Parent = this.allNode[fatherIndx];
                    }
                }
                this.count++;
                this.allNode.Add(item);
            }
        }

        public bool IsInRightTree(int nodeIndex)
        {
            int num = ((int) Math.Log((double) (nodeIndex + 1), 2.0)) + 1;
            return (nodeIndex >= ((Math.Pow(2.0, (double) (num - 1)) - 1.0) + Math.Pow(2.0, (double) (num - 2))));
        }

        public virtual void Remove(TVal val)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Write))
            {
                int indxOfNode = this.GetIndxOfNode(val);
                this.Remove(indxOfNode);
            }
        }

        public virtual void Remove(int nodeIndex)
        {
            if (nodeIndex >= 0)
            {
                using (this.SmartRWLocker.Lock(AccessMode.Write))
                {
                    this.SwapValueOfTwoNode(this.allNode[nodeIndex], this.allNode[this.allNode.Count - 1]);
                    this.RemoveLastNode();
                }
            }
        }

        private void RemoveLastNode()
        {
            using (this.SmartRWLocker.Lock(AccessMode.Write))
            {
                if (this.count != 0)
                {
                    if (this.count == 1)
                    {
                        this.root = null;
                    }
                    else
                    {
                        int fatherIndx = this.GetFatherIndx(this.allNode.Count - 1);
                        if ((this.allNode.Count % 2) == 1)
                        {
                            this.allNode[fatherIndx].RightChild = null;
                        }
                        else
                        {
                            this.allNode[fatherIndx].LeftChild = null;
                        }
                    }
                    this.count--;
                    this.allNode.RemoveAt(this.allNode.Count - 1);
                }
            }
        }

        public void SwapValueOfTwoNode(CJBasic.ObjectManagement.Trees.Binary.Node<TVal> node1, CJBasic.ObjectManagement.Trees.Binary.Node<TVal> node2)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Write))
            {
                TVal theValue = node1.TheValue;
                node1.TheValue = node2.TheValue;
                node2.TheValue = theValue;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int Depth
        {
            get
            {
                return (((int) Math.Log((double) this.count, 2.0)) + 1);
            }
        }

        public CJBasic.ObjectManagement.Trees.Binary.Node<TVal> Root
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

