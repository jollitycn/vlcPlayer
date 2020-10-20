namespace CJBasic.ObjectManagement.Cache
{
    using CJBasic.ObjectManagement;
    using System;
    using System.Collections.Generic;

    public interface ISmartDictionaryCache<Tkey, TVal>
    {
        void Clear();
        TVal Get(Tkey id);
        IList<Tkey> GetAllKeyListCopy();
        IList<TVal> GetAllValListCopy();
        bool HaveContained(Tkey id);
        void Initialize();

        int Count { get; }

        bool Enabled { get; set; }

        IObjectRetriever<Tkey, TVal> ObjectRetriever { set; }
    }
}

