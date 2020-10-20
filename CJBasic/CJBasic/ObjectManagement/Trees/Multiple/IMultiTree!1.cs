namespace CJBasic.ObjectManagement.Trees.Multiple
{
    using CJBasic;
    using System;
    using System.Collections.Generic;

    public interface IMultiTree<TVal> where TVal: IMTreeVal
    {
        void ActionOnEachNode(CbGeneric<MNode<TVal>> action);
        List<MNode<TVal>> GetFamilyByPath(string idPath, char separator);
        IList<TVal> GetLeaves(string path, char separator);
        MNode<TVal> GetNodeByID(string valID);
        MNode<TVal> GetNodeByPath(string idPath, char separator);
        IList<MNode<TVal>> GetNodesOnDepthIndex(int depthIndex);
        IList<MNode<TVal>> GetNodesOnDepthIndex(string idPath, char separator, int depthIndex);
        IList<MNode<TVal>> GetOffsprings(string valID);
        void Initialize(MNode<TVal> _rootNode);
        void Initialize(TVal rootVal, IList<TVal> members);

        int Count { get; }

        MNode<TVal> Root { get; }
    }
}

