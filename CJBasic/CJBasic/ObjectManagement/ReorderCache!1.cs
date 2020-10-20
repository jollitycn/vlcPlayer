namespace CJBasic.ObjectManagement
{
    using CJBasic.ObjectManagement.Managers;
    using System;

    public class ReorderCache<T> where T: class
    {
        private object locker;
        private ObjectManager<int, T> manager;
        private int? preObjectIndex;

        public ReorderCache()
        {
            this.locker = new object();
            this.preObjectIndex = null;
            this.manager = new ObjectManager<int, T>();
        }

        public T Add(T t, int index)
        {
            lock (this.locker)
            {
                if (!this.preObjectIndex.HasValue)
                {
                    this.preObjectIndex = new int?(index);
                    return t;
                }
                if (index == (this.preObjectIndex + 1))
                {
                    this.preObjectIndex = new int?(index);
                    return t;
                }
                this.manager.Add(index, t);
                return default(T);
            }
        }

        public T GetNext()
        {
            lock (this.locker)
            {
                if (!this.preObjectIndex.HasValue)
                {
                    return default(T);
                }
                int id = this.preObjectIndex.Value + 1;
                T local = this.manager.Get(id);
                if (local != null)
                {
                    this.preObjectIndex = new int?(id);
                    this.manager.Remove(id);
                }
                return local;
            }
        }

        public void Reset()
        {
            lock (this.locker)
            {
                this.manager.Clear();
                this.preObjectIndex = null;
            }
        }

        public int Count
        {
            get
            {
                return this.manager.Count;
            }
        }
    }
}

