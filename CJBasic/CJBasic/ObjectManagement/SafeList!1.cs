namespace CJBasic.ObjectManagement
{
    using System;
    using System.Collections.Generic;

    public class SafeList<T>
    {
        private List<T> list;
        private object locker;

        public SafeList()
        {
            this.locker = new object();
            this.list = new List<T>();
        }

        public void Add(T t)
        {
            lock (this.locker)
            {
                this.list.Add(t);
            }
        }

        public void Clear()
        {
            lock (this.locker)
            {
                this.list.Clear();
            }
        }

        public List<T> GetAll()
        {
            return new List<T>(this.list.ToArray());
        }

        public void Remove(T t)
        {
            lock (this.locker)
            {
                this.list.Remove(t);
            }
        }

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }
    }
}

