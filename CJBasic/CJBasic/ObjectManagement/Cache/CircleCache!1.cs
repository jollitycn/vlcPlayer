namespace CJBasic.ObjectManagement.Cache
{
    using CJBasic.ObjectManagement;
    using System;
    using System.Collections.Generic;

    public class CircleCache<T>
    {
        private Circle<T> circle;
        private object locker;

        public CircleCache()
        {
            this.locker = new object();
            this.circle = new Circle<T>();
        }

        public CircleCache(ICollection<T> collection)
        {
            this.locker = new object();
            this.circle = new Circle<T>();
            if ((collection != null) && (collection.Count > 0))
            {
                foreach (T local in collection)
                {
                    this.circle.Append(local);
                }
            }
        }

        public void Add(T t)
        {
            lock (this.locker)
            {
                this.circle.Append(t);
            }
        }

        public T Get()
        {
            lock (this.locker)
            {
                this.circle.MoveNext();
                return this.circle.Current;
            }
        }
    }
}

