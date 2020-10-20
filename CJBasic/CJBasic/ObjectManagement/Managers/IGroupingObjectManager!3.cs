namespace CJBasic.ObjectManagement.Managers
{
    using System;
    using System.Collections.Generic;

    public interface IGroupingObjectManager<TGroupKey, TObjectKey, TObject> where TObject: IGroupingObject<TGroupKey, TObjectKey>
    {
        void Add(TObject obj);
        void Clear();
        TObject Get(TObjectKey objectID);
        IList<TObject> GetAllObjectsCopy();
        int GetCountOfGroup(TGroupKey groupID);
        IList<TGroupKey> GetGroupsCopy();
        IList<TObject> GetObjectsCopy(TGroupKey groupID);
        void Remove(TObjectKey objectID);

        int TotalObjectCount { get; }
    }
}

