namespace CJBasic.ObjectManagement.Trees.KDimension
{
    using CJBasic.Arithmetic;
    using System;
    using System.Collections.Generic;

    public class KDTree<T> where T: IKDTreeVal, IEquatable<T>
    {
        private int dimension;
        private KDNode<T> root;

        public KDTree(int _dimension)
        {
            this.root = null;
            this.dimension = 2;
            this.dimension = _dimension;
        }

        public KDNode<T> Get(T val)
        {
            return this.search(val, this.root);
        }

        public List<T> GetBetween(KDSearchScope[] searchAry)
        {
            List<T> result = new List<T>();
            if (searchAry.Length == this.dimension)
            {
                this.SearchBetween(searchAry, this.root, ref result);
            }
            return result;
        }

        public List<T> GetBetween(T min, bool[] minClosedAry, T max, bool[] maxClosedAry)
        {
            List<T> result = new List<T>();
            this.SearchBetween(min, max, minClosedAry, maxClosedAry, this.root, ref result);
            return result;
        }

        public KDNode<T> Insert(T val)
        {
            if (this.root == null)
            {
                this.root = new KDNode<T>(val, 0);
                return this.root;
            }
            if (this.root.TheValue.Equals(val))
            {
                return this.root;
            }
            if (this.root.TheValue[0].CompareTo(val[0]) >= 0)
            {
                return this.Insert(val, this.root.Left, this.root, true);
            }
            return this.Insert(val, this.root.Right, this.root, false);
        }

        private KDNode<T> Insert(T val, KDNode<T> insertNode, KDNode<T> parentNode, bool isLeft)
        {
            if (insertNode == null)
            {
                if (isLeft)
                {
                    parentNode.Left = new KDNode<T>(val, parentNode.Depth + 1);
                    return parentNode.Left;
                }
                parentNode.Right = new KDNode<T>(val, parentNode.Depth + 1);
                return parentNode.Right;
            }
            if (insertNode.TheValue.Equals(val))
            {
                return insertNode;
            }
            int num = insertNode.Depth % this.dimension;
            if (insertNode.TheValue[num].CompareTo(val[num]) >= 0)
            {
                return this.Insert(val, insertNode.Left, insertNode, true);
            }
            return this.Insert(val, insertNode.Right, insertNode, false);
        }

        private bool IsInRange(T val, KDSearchScope[] searchAry)
        {
            for (int i = 0; i < this.dimension; i++)
            {
                if (searchAry[i].KDSearchType == KDSearchType.Like)
                {
                    return FuzzyMatchHelper.IsLike(searchAry[i].MatchString, val[i].ToString());
                }
                if (searchAry[i].KDSearchType == KDSearchType.Like)
                {
                    return !FuzzyMatchHelper.IsLike(searchAry[i].MatchString, val[i].ToString());
                }
                if ((((searchAry[i].MinClosed && (val[i].CompareTo(searchAry[i].MinValue) < 0)) || (!searchAry[i].MinClosed && (val[i].CompareTo(searchAry[i].MinValue) <= 0))) || (searchAry[i].MaxClosed && (val[i].CompareTo(searchAry[i].MaxValue) > 0))) || (!searchAry[i].MaxClosed && (val[i].CompareTo(searchAry[i].MaxValue) >= 0)))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsInRange(T val, T min, T max, bool[] minAry, bool[] maxAry)
        {
            for (int i = 0; i < this.dimension; i++)
            {
                if ((((minAry[i] && (val[i].CompareTo(min[i]) < 0)) || (!minAry[i] && (val[i].CompareTo(min[i]) <= 0))) || (maxAry[i] && (val[i].CompareTo(max[i]) > 0))) || (!maxAry[i] && (val[i].CompareTo(max[i]) >= 0)))
                {
                    return false;
                }
            }
            return true;
        }

        private KDNode<T> search(T val, KDNode<T> node)
        {
            if (node == null)
            {
                return null;
            }
            if (node.TheValue.Equals(val))
            {
                return node;
            }
            int num = node.Depth % this.dimension;
            if (node.TheValue[num].CompareTo(val[num]) <= 0)
            {
                return this.search(val, node.Right);
            }
            return this.search(val, node.Left);
        }

        private void SearchBetween(KDSearchScope[] searchAry, KDNode<T> node, ref List<T> result)
        {
            if (node != null)
            {
                if (this.IsInRange(node.TheValue, searchAry))
                {
                    result.Add(node.TheValue);
                }
                int index = node.Depth % this.dimension;
                if (searchAry[index].KDSearchType == KDSearchType.Default)
                {
                    if (node.TheValue[index].CompareTo(searchAry[index].MinValue) < 0)
                    {
                        this.SearchBetween(searchAry, node.Right, ref result);
                    }
                    else if ((node.TheValue[index].CompareTo(searchAry[index].MinValue) >= 0) && (node.TheValue[index].CompareTo(searchAry[index].MaxValue) < 0))
                    {
                        this.SearchBetween(searchAry, node.Left, ref result);
                        this.SearchBetween(searchAry, node.Right, ref result);
                    }
                    else
                    {
                        this.SearchBetween(searchAry, node.Left, ref result);
                    }
                }
                else
                {
                    this.SearchBetween(searchAry, node.Left, ref result);
                    this.SearchBetween(searchAry, node.Right, ref result);
                }
            }
        }

        private void SearchBetween(T min, T max, bool[] minClosedAry, bool[] maxClosedAry, KDNode<T> node, ref List<T> result)
        {
            if (node != null)
            {
                if (this.IsInRange(node.TheValue, min, max, minClosedAry, maxClosedAry))
                {
                    result.Add(node.TheValue);
                }
                int num = node.Depth % this.dimension;
                if (node.TheValue[num].CompareTo(min[num]) < 0)
                {
                    this.SearchBetween(min, max, minClosedAry, maxClosedAry, node.Right, ref result);
                }
                else if ((node.TheValue[num].CompareTo(min[num]) >= 0) && (node.TheValue[num].CompareTo(max[num]) < 0))
                {
                    this.SearchBetween(min, max, minClosedAry, maxClosedAry, node.Left, ref result);
                    this.SearchBetween(min, max, minClosedAry, maxClosedAry, node.Right, ref result);
                }
                else
                {
                    this.SearchBetween(min, max, minClosedAry, maxClosedAry, node.Left, ref result);
                }
            }
        }
    }
}

