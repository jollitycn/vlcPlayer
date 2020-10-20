namespace CJBasic.ObjectManagement.Trees.Binary
{
    using System;

    public interface IBinaryTree<TVal> where TVal: IComparable
    {
        int Count { get; }

        int Depth { get; }

        Node<TVal> Root { get; }
    }
}

