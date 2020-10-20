namespace CJBasic.ObjectManagement.Trees.Binary
{
    using System;

    public interface IHeap<TVal> : IBinaryTree<TVal> where TVal: IComparable
    {
        void Insert(TVal val);
        TVal Pop();

        CJBasic.ObjectManagement.Trees.Binary.HeapType HeapType { get; }
    }
}

