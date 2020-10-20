namespace CJBasic.ObjectManagement.Trees.Binary
{
    using System;
    using System.Collections.Generic;

    public interface ISorttedBinaryTree<TVal> : IBinaryTree<TVal> where TVal: IComparable
    {
        bool Contains(TVal var);
        CJBasic.ObjectManagement.Trees.Binary.Node<TVal> Get(TVal var);
        IList<CJBasic.ObjectManagement.Trees.Binary.Node<TVal>> GetAllNodesAscend(bool ascend);
        CJBasic.ObjectManagement.Trees.Binary.Node<TVal> GetMaxNode(CJBasic.ObjectManagement.Trees.Binary.Node<TVal> childTree);
        CJBasic.ObjectManagement.Trees.Binary.Node<TVal> GetMinNode(CJBasic.ObjectManagement.Trees.Binary.Node<TVal> childTree);
        void Insert(TVal val);
        void Remove(TVal val);
        IList<CJBasic.ObjectManagement.Trees.Binary.Node<TVal>> Traverse(TraverseMode mode);
    }
}

