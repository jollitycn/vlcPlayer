namespace CJBasic.ObjectManagement
{
    using CJBasic;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class FixedQueue<T>
    {
        private int capacity;
        private object locker;
        private Queue<T> queue;

        public event CbGeneric<T> ObjectDiscarded;

        public FixedQueue() : this(0x7fffffff)
        {
        }

        public FixedQueue(int _capacity)
        {
            this.queue = new Queue<T>();
            this.locker = new object();
            this.capacity = 0x7fffffff;
            this.capacity = this.capacity;
            this.ObjectDiscarded += delegate {
            };
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
            if (this.capacity > 0)
            {
                lock (this.locker)
                {
                    if (this.queue.Count >= this.capacity)
                    {
                        this.ObjectDiscarded(this.queue.Dequeue());
                    }
                    this.queue.Enqueue(obj);
                }
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

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("The capacity of FixedQueue can't be less than 0 !");
                }
                lock (this.locker)
                {
                    if (value == 0)
                    {
                        this.queue.Clear();
                        this.capacity = value;
                    }
                    else if (value > 0)
                    {
                        this.capacity = value;
                        while (this.queue.Count > this.capacity)
                        {
                            this.ObjectDiscarded(this.queue.Dequeue());
                        }
                    }
                }
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

