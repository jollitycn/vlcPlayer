namespace CJBasic.ObjectManagement.Trees.Binary
{
    using CJBasic.Threading.Synchronize;
    using System;

    [Serializable]
    public class MinMaxHeap<TVal> : CompleteBinaryTree<TVal> where TVal: IComparable
    {
        private void AdjustHeapFromDownToUp(Node<TVal> newNode)
        {
            if ((base.GetLayerOfNode(base.count - 1) % 2) == 0)
            {
                if (newNode.TheValue.CompareTo(newNode.Parent.TheValue) < 0)
                {
                    base.SwapValueOfTwoNode(newNode, newNode.Parent);
                    this.VerifyMinLayerRightFromDownToUp(newNode.Parent);
                }
                else
                {
                    this.VerifyMaxLayerRightFromDownToUp(newNode);
                }
            }
            else if (newNode.TheValue.CompareTo(newNode.Parent.TheValue) > 0)
            {
                base.SwapValueOfTwoNode(newNode, newNode.Parent);
                this.VerifyMaxLayerRightFromDownToUp(newNode.Parent);
            }
            else
            {
                this.VerifyMinLayerRightFromDownToUp(newNode);
            }
        }

        public override void Insert(TVal val)
        {
            using (base.SmartRWLocker.Lock(AccessMode.Write))
            {
                base.Insert(val);
                if (base.count > 1)
                {
                    this.AdjustHeapFromDownToUp(base.allNode[base.allNode.Count - 1]);
                }
            }
        }

        public void RemoveMax()
        {
            using (base.SmartRWLocker.Lock(AccessMode.Write))
            {
                if (base.root != null)
                {
                    if (base.allNode.Count == 1)
                    {
                        base.Remove(0);
                    }
                    else if (base.allNode.Count == 2)
                    {
                        base.Remove(1);
                    }
                    else
                    {
                        Node<TVal> leftChild;
                        if (base.root.LeftChild.TheValue.CompareTo(base.root.RightChild.TheValue) >= 0)
                        {
                            base.Remove(1);
                            leftChild = base.root.LeftChild;
                        }
                        else
                        {
                            base.Remove(2);
                            leftChild = base.root.RightChild;
                        }
                        this.VerifyRootBiggerThanChildren(leftChild);
                        this.VerifyMaxLayerRightFromUpToDown(leftChild);
                    }
                }
            }
        }

        public void RemoveMin()
        {
            using (base.SmartRWLocker.Lock(AccessMode.Write))
            {
                if (base.root != null)
                {
                    base.Remove(0);
                    if (base.count > 1)
                    {
                        this.VerifyRootSmallThanChildren(base.root);
                        this.VerifyMinLayerRightFromUpToDown(base.root);
                    }
                }
            }
        }

        private void VerifyMaxLayerRightFromDownToUp(Node<TVal> node)
        {
            while (((node.Parent != null) && (node.Parent.Parent != null)) && (node.Parent.Parent.TheValue.CompareTo(node.TheValue) < 0))
            {
                base.SwapValueOfTwoNode(node, node.Parent.Parent);
                node = node.Parent.Parent;
            }
        }

        private void VerifyMaxLayerRightFromUpToDown(Node<TVal> node)
        {
            while ((node.LeftChild != null) && (node.LeftChild.LeftChild != null))
            {
                Node<TVal> leftChild = node;
                if (leftChild.TheValue.CompareTo(node.LeftChild.LeftChild.TheValue) < 0)
                {
                    leftChild = node.LeftChild.LeftChild;
                }
                if ((node.LeftChild.RightChild != null) && (leftChild.TheValue.CompareTo(node.LeftChild.RightChild.TheValue) < 0))
                {
                    leftChild = node.LeftChild.RightChild;
                }
                if ((node.RightChild != null) && (node.RightChild.LeftChild != null))
                {
                    if (leftChild.TheValue.CompareTo(node.RightChild.LeftChild.TheValue) < 0)
                    {
                        leftChild = node.RightChild.LeftChild;
                    }
                    if ((node.RightChild.RightChild != null) && (leftChild.TheValue.CompareTo(node.RightChild.RightChild.TheValue) < 0))
                    {
                        leftChild = node.RightChild.RightChild;
                    }
                }
                if (leftChild.TheValue.CompareTo(node.TheValue) != 0)
                {
                    base.SwapValueOfTwoNode(node, leftChild);
                    node = leftChild;
                }
                else
                {
                    break;
                }
            }
        }

        private void VerifyMinLayerRightFromDownToUp(Node<TVal> node)
        {
            while (((node.Parent != null) && (node.Parent.Parent != null)) && (node.Parent.Parent.TheValue.CompareTo(node.TheValue) > 0))
            {
                base.SwapValueOfTwoNode(node, node.Parent.Parent);
                node = node.Parent.Parent;
            }
        }

        private void VerifyMinLayerRightFromUpToDown(Node<TVal> node)
        {
            while ((node.LeftChild != null) && (node.LeftChild.LeftChild != null))
            {
                Node<TVal> leftChild = node;
                if (leftChild.TheValue.CompareTo(node.LeftChild.LeftChild.TheValue) > 0)
                {
                    leftChild = node.LeftChild.LeftChild;
                }
                if ((node.LeftChild.RightChild != null) && (leftChild.TheValue.CompareTo(node.LeftChild.RightChild.TheValue) > 0))
                {
                    leftChild = node.LeftChild.RightChild;
                }
                if ((node.RightChild != null) && (node.RightChild.LeftChild != null))
                {
                    if (leftChild.TheValue.CompareTo(node.RightChild.LeftChild.TheValue) > 0)
                    {
                        leftChild = node.RightChild.LeftChild;
                    }
                    if ((node.RightChild.RightChild != null) && (leftChild.TheValue.CompareTo(node.RightChild.RightChild.TheValue) > 0))
                    {
                        leftChild = node.RightChild.RightChild;
                    }
                }
                if (leftChild.TheValue.CompareTo(node.TheValue) != 0)
                {
                    base.SwapValueOfTwoNode(node, leftChild);
                    node = leftChild;
                }
                else
                {
                    break;
                }
            }
        }

        private void VerifyRootBiggerThanChildren(Node<TVal> rootNode)
        {
            Node<TVal> leftChild = rootNode;
            if (rootNode.LeftChild != null)
            {
                if (rootNode.LeftChild.TheValue.CompareTo(leftChild.TheValue) > 0)
                {
                    leftChild = rootNode.LeftChild;
                }
                if ((rootNode.RightChild != null) && (rootNode.RightChild.TheValue.CompareTo(leftChild.TheValue) > 0))
                {
                    leftChild = rootNode.RightChild;
                }
            }
            if (leftChild.TheValue.CompareTo(rootNode.TheValue) != 0)
            {
                base.SwapValueOfTwoNode(rootNode, leftChild);
            }
        }

        private void VerifyRootSmallThanChildren(Node<TVal> rootNode)
        {
            Node<TVal> leftChild = rootNode;
            if (rootNode.LeftChild != null)
            {
                if (rootNode.LeftChild.TheValue.CompareTo(leftChild.TheValue) < 0)
                {
                    leftChild = rootNode.LeftChild;
                }
                if ((rootNode.RightChild != null) && (rootNode.RightChild.TheValue.CompareTo(leftChild.TheValue) < 0))
                {
                    leftChild = rootNode.RightChild;
                }
            }
            if (leftChild.TheValue.CompareTo(rootNode.TheValue) != 0)
            {
                base.SwapValueOfTwoNode(leftChild, rootNode);
            }
        }
    }
}

