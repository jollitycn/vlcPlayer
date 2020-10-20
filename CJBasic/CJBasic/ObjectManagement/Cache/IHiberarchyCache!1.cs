namespace CJBasic.ObjectManagement.Cache
{
    using CJBasic.ObjectManagement;
    using CJBasic.ObjectManagement.Trees.Multiple;
    using System;
    using System.Collections.Generic;

    public interface IHiberarchyCache<TVal> where TVal: IHiberarchyVal
    {
        MultiTree<TVal> CreateHiberarchyTree();
        TVal Get(string id);
        IList<string> GetAllKeyListCopy();
        IList<TVal> GetAllValListCopy();
        int GetChildrenCount(string parentID);
        IList<TVal> GetChildrenOf(string parentID);
        IList<TVal> GetNodesOnDepthIndex(int depthIndex);
        IList<TVal> GetNodesOnDepthIndex(string parentID, int depthIndex);
        bool HaveContained(string id);
        void Initialize();

        int Count { get; }

        IObjectRetriever<string, TVal> ObjectRetriever { set; }

        string RootID { set; }

        char SequenceCodeSplitter { get; set; }
    }
}

