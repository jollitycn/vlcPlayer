namespace CJBasic.ObjectManagement.Managers
{
    using CJBasic.Collections;
    using System;
    using System.Collections.Generic;

    public class GroupingObjectManager<TGroupKey, TObjectKey, TObject> : IGroupingObjectManager<TGroupKey, TObjectKey, TObject> where TObject: IGroupingObject<TGroupKey, TObjectKey>
    {
        private IDictionary<TGroupKey, IDictionary<TObjectKey, TObject>> groupDictionary;
        private object locker;
        private IDictionary<TObjectKey, TObject> objectDictionary;

        public GroupingObjectManager()
        {
            this.groupDictionary = new Dictionary<TGroupKey, IDictionary<TObjectKey, TObject>>();
            this.objectDictionary = new Dictionary<TObjectKey, TObject>();
            this.locker = new object();
        }

        public void Add(TObject obj)
        {
            lock (this.locker)
            {
                if (!this.groupDictionary.ContainsKey(obj.GroupID))
                {
                    this.groupDictionary.Add(obj.GroupID, new Dictionary<TObjectKey, TObject>());
                }
                if (this.groupDictionary[obj.GroupID].ContainsKey(obj.ID))
                {
                    this.groupDictionary[obj.GroupID].Remove(obj.ID);
                }
                this.groupDictionary[obj.GroupID].Add(obj.ID, obj);
                if (this.objectDictionary.ContainsKey(obj.ID))
                {
                    this.objectDictionary.Remove(obj.ID);
                }
                this.objectDictionary.Add(obj.ID, obj);
            }
        }

        public void Clear()
        {
            lock (this.locker)
            {
                this.groupDictionary.Clear();
                this.objectDictionary.Clear();
            }
        }

        public TObject Get(TObjectKey objectID)
        {
            lock (this.locker)
            {
                if (this.objectDictionary.ContainsKey(objectID))
                {
                    return this.objectDictionary[objectID];
                }
                return default(TObject);
            }
        }

        public IList<TObject> GetAllObjectsCopy()
        {
            lock (this.locker)
            {
                return (IList<TObject>) CollectionConverter.CopyAllToList<TObject>(this.objectDictionary.Values);
            }
        }

        public int GetCountOfGroup(TGroupKey groupID)
        {
            lock (this.locker)
            {
                if (!this.groupDictionary.ContainsKey(groupID))
                {
                    return 0;
                }
                return this.groupDictionary[groupID].Count;
            }
        }

        public IList<TGroupKey> GetGroupsCopy()
        {
            lock (this.locker)
            {
                return CollectionConverter.CopyAllToList<TGroupKey>(this.groupDictionary.Keys);
            }
        }

        public IList<TObject> GetObjectsCopy(TGroupKey groupID)
        {
            lock (this.locker)
            {
                if (!this.groupDictionary.ContainsKey(groupID))
                {
                    return new List<TObject>();
                }
                return (IList<TObject>) CollectionConverter.CopyAllToList<TObject>(this.groupDictionary[groupID].Values);
            }
        }

        public void Remove(TObjectKey objectID)
        {
            lock (this.locker)
            {
                if (this.objectDictionary.ContainsKey(objectID))
                {
                    TObject local = this.objectDictionary[objectID];
                    this.objectDictionary.Remove(objectID);
                    if (this.groupDictionary[local.GroupID].ContainsKey(objectID))
                    {
                        this.groupDictionary[local.GroupID].Remove(objectID);
                        if (this.groupDictionary[local.GroupID].Count == 0)
                        {
                            this.groupDictionary.Remove(local.GroupID);
                        }
                    }
                }
            }
        }

        public int TotalObjectCount
        {
            get
            {
                return this.objectDictionary.Count;
            }
        }
    }
}

