namespace CJBasic.ObjectManagement.Trees.Binary
{
    using CJBasic.Threading.Synchronize;
    using System;

    [Serializable]
    public class DoulbeEndedHeap<TVal> : CompleteBinaryTree<TVal> where TVal: IComparable
    {
        public override void Insert(TVal val)
        {
            using (base.SmartRWLocker.Lock(AccessMode.Write))
            {
                if (base.root == null)
                {
                    base.Insert(default(TVal));
                    base.Insert(val);
                }
                else
                {
                    base.Insert(val);
                    this.VerifyDoubleEndedHeap(base.allNode.Count - 1);
                }
            }
        }

        public void RemoveMax()
        {
            using (base.SmartRWLocker.Lock(AccessMode.Write))
            {
                if (base.allNode.Count > 2)
                {
                    base.Remove(2);
                    if (base.allNode.Count > 2)
                    {
                        int nodeIndx = this.SwapFromRootToLeaf(base.allNode[2], false);
                        this.VerifyDoubleEndedHeap(nodeIndx);
                    }
                }
                else if (base.allNode.Count == 2)
                {
                    this.RemoveMin();
                }
            }
        }

        public void RemoveMin()
        {
            using (base.SmartRWLocker.Lock(AccessMode.Write))
            {
                base.Remove(1);
                if (base.count > 1)
                {
                    int nodeIndx = this.SwapFromRootToLeaf(base.allNode[1], true);
                    this.VerifyDoubleEndedHeap(nodeIndx);
                }
                else
                {
                    base.Remove(0);
                }
            }
        }

        private void SwapFromLeafToRoot(Node<TVal> node, bool isMinHeap)
        {
            Node<TVal> parent = node;
            if (isMinHeap)
            {
                while ((parent.Parent != base.root) && (parent.Parent.TheValue.CompareTo(parent.TheValue) > 0))
                {
                    base.SwapValueOfTwoNode(parent, parent.Parent);
                    parent = parent.Parent;
                }
            }
            else
            {
                while ((parent.Parent != base.root) && (parent.Parent.TheValue.CompareTo(parent.TheValue) < 0))
                {
                    base.SwapValueOfTwoNode(parent, parent.Parent);
                    parent = parent.Parent;
                }
            }
        }

        private int SwapFromRootToLeaf(Node<TVal> rootNode, bool isMinHeap)
        {
            TVal theValue = rootNode.TheValue;
            Node<TVal> node = rootNode;
            if (!isMinHeap)
            {
                while ((node.LeftChild != null) || (node.RightChild != null))
                {
                    Node<TVal> leftChild = node.LeftChild;
                    if ((node.RightChild != null) && (node.RightChild.TheValue.CompareTo(node.LeftChild.TheValue) > 0))
                    {
                        leftChild = node.RightChild;
                    }
                    if (theValue.CompareTo(leftChild.TheValue) > 0)
                    {
                        break;
                    }
                    node.TheValue = leftChild.TheValue;
                    node = leftChild;
                }
            }
            else
            {
                while ((node.LeftChild != null) || (node.RightChild != null))
                {
                    Node<TVal> rightChild = node.LeftChild;
                    if ((node.RightChild != null) && (node.RightChild.TheValue.CompareTo(node.LeftChild.TheValue) < 0))
                    {
                        rightChild = node.RightChild;
                    }
                    if (theValue.CompareTo(rightChild.TheValue) < 0)
                    {
                        break;
                    }
                    node.TheValue = rightChild.TheValue;
                    node = rightChild;
                }
            }
            node.TheValue = theValue;
            return base.GetIndxOfNode(node.TheValue);
        }

        private void VerifyDoubleEndedHeap(int nodeIndx)
        {
            bool isInRightTree = base.IsInRightTree(nodeIndx);
            int oppositeNodeIndx = base.GetOppositeNodeIndx(nodeIndx, isInRightTree);
            if (oppositeNodeIndx > 0)
            {
                if (isInRightTree)
                {
                    if (base.allNode[nodeIndx].TheValue.CompareTo(base.allNode[oppositeNodeIndx].TheValue) < 0)
                    {
                        base.SwapValueOfTwoNode(base.allNode[nodeIndx], base.allNode[oppositeNodeIndx]);
                        this.SwapFromLeafToRoot(base.allNode[oppositeNodeIndx], true);
                    }
                    else if ((base.allNode[nodeIndx].LeftChild == null) && (base.allNode[oppositeNodeIndx].LeftChild != null))
                    {
                        oppositeNodeIndx = (oppositeNodeIndx * 2) + 1;
                        if (((oppositeNodeIndx + 1) < base.allNode.Count) && (base.allNode[oppositeNodeIndx].TheValue.CompareTo(base.allNode[oppositeNodeIndx + 1].TheValue) < 0))
                        {
                            oppositeNodeIndx++;
                        }
                        if (base.allNode[oppositeNodeIndx].TheValue.CompareTo(base.allNode[nodeIndx].TheValue) > 0)
                        {
                            base.SwapValueOfTwoNode(base.allNode[nodeIndx], base.allNode[oppositeNodeIndx]);
                            this.SwapFromLeafToRoot(base.allNode[oppositeNodeIndx], true);
                        }
                    }
                    this.SwapFromLeafToRoot(base.allNode[nodeIndx], false);
                }
                else
                {
                    if (base.allNode[nodeIndx].TheValue.CompareTo(base.allNode[oppositeNodeIndx].TheValue) > 0)
                    {
                        base.SwapValueOfTwoNode(base.allNode[nodeIndx], base.allNode[oppositeNodeIndx]);
                        this.SwapFromLeafToRoot(base.allNode[oppositeNodeIndx], false);
                    }
                    this.SwapFromLeafToRoot(base.allNode[nodeIndx], true);
                }
            }
        }
    }
}

