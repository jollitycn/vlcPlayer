namespace CJBasic.ObjectManagement
{
    using CJBasic.Collections;
    using System;
    using System.Collections.Generic;

    public class UniqueObjectList<T>
    {
        private IList<T> innerList;
        private object locker;

        public UniqueObjectList()
        {
            this.innerList = new List<T>();
            this.locker = new object();
        }

        public void Add(T obj)
        {
            lock (this.locker)
            {
                if (!this.innerList.Contains(obj))
                {
                    this.innerList.Add(obj);
                }
            }
        }

        public IList<T> GetListCopy()
        {
            lock (this.locker)
            {
                return CollectionConverter.CopyAllToList<T>(this.innerList);
            }
        }

        public void Remove(T obj)
        {
            lock (this.locker)
            {
                this.innerList.Remove(obj);
            }
        }
    }
}

