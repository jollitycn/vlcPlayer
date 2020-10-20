namespace CJBasic.ObjectManagement.Trees.Multiple
{
    using System;

    public interface IAgileMultiTree<TVal> : IMultiTree<TVal> where TVal: IMTreeVal
    {
        MNode<TVal> EnsureNodeExist(string nodeSequenceCode);
        void Initialize();

        IAgileNodePicker<TVal> AgileNodePicker { set; }

        char SequenceCodeSplitter { get; set; }
    }
}

