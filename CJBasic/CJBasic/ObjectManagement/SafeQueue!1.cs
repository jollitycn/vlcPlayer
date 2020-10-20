namespace CJBasic.ObjectManagement
{
    using System;
    using System.Collections.Generic;

    public class SafeQueue<T>
    {
        private object locker;
        private Queue<T> queue;

        public SafeQueue()
        {
            this.queue = new Queue<T>();
            this.locker = new object();
        }

        public void Clear()
        {
            lock (this.locker)
            {
                this.queue.Clear();
            }
        }

        public T Dequeue()
        {
            lock (this.locker)
            {
                return this.queue.Dequeue();
            }
        }

        public void Enqueue(T obj)
        {
            lock (this.locker)
            {
                this.queue.Enqueue(obj);
            }
        }

        public T[] GetObjectArrayCopy()
        {
            lock (this.locker)
            {
                return this.queue.ToArray();
            }
        }

        public T Peek()
        {
            lock (this.locker)
            {
                return this.queue.Peek();
            }
        }

        public void Remove(T obj)
        {
            lock (this.locker)
            {
                Queue<T> queue = new Queue<T>();
                while (this.queue.Count > 0)
                {
                    T item = this.queue.Dequeue();
                    if (!item.Equals(obj))
                    {
                        queue.Enqueue(item);
                    }
                }
                this.queue = queue;
            }
        }

        public int Count
        {
            get
            {
                return this.queue.Count;
            }
        }
    }
}

