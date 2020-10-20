namespace CJBasic.ObjectManagement.Managers
{
    using System;
    using System.Collections.Generic;

    public interface IObjectManager<TPKey, TObject>
    {
        void Add(TPKey key, TObject obj);
        void Clear();
        bool Contains(TPKey id);
        TObject Get(TPKey id);
        List<TObject> GetAll();
        List<TObject> GetAllReadonly();
        List<TPKey> GetKeyList();
        List<TPKey> GetKeyListByObj(TObject obj);
        void Remove(TPKey id);
        void RemoveByPredication(Predicate<TObject> predicate);
        void RemoveByValue(TObject val);
        Dictionary<TPKey, TObject> ToDictionary();

        int Count { get; }
    }
}

