namespace CJBasic.ObjectManagement
{
    using CJBasic;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Threading;

    public class CircleQueue<T>
    {
        private T[] array;
        private int count;
        private int headIndex;
        private object locker;
        private int maxCount;
        private int tailIndex;

        public event CbGeneric<T> ObjectBeDiscarded;

        public CircleQueue(int size)
        {
            this.locker = new object();
            this.headIndex = 0;
            this.tailIndex = 0;
            this.maxCount = 0;
            this.count = 0;
            this.array = new T[size];
        }

        public void ChangeSize(int newSize)
        {
            if (newSize != this.Size)
            {
                lock (this.locker)
                {
                    T[] localArray = new T[newSize];
                    int num = this.count - newSize;
                    if (num < 0)
                    {
                        num = 0;
                    }
                    int num2 = this.count - num;
                    for (int i = 0; i < num2; i++)
                    {
                        int index = (this.headIndex + i) % this.array.Length;
                        localArray[i] = this.array[index];
                    }
                    this.array = localArray;
                    this.count = num2;
                    this.headIndex = 0;
                    this.tailIndex = (this.headIndex + num2) - 1;
                }
            }
        }

        public void Clear()
        {
            lock (this.locker)
            {
                this.count = 0;
            }
        }

        public T Dequeue()
        {
            T local;
            this.Dequeue(out local);
            return local;
        }

        public bool Dequeue(out T obj)
        {
            lock (this.locker)
            {
                obj = default(T);
                if (this.count == 0)
                {
                    return false;
                }
                obj = this.array[this.headIndex];
                this.array[this.headIndex] = default(T);
                this.headIndex = (this.headIndex + 1) % this.array.Length;
                this.count--;
                return true;
            }
        }

        public void Enqueue(T obj)
        {
            lock (this.locker)
            {
                if (this.count == 0)
                {
                    this.array[this.headIndex] = obj;
                    this.tailIndex = this.headIndex;
                    this.count++;
                }
                else
                {
                    T local = this.array[this.headIndex];
                    this.tailIndex = (this.tailIndex + 1) % this.array.Length;
                    this.array[this.tailIndex] = obj;
                    this.count++;
                    if (this.tailIndex == this.headIndex)
                    {
                        this.headIndex = (this.headIndex + 1) % this.array.Length;
                        this.count--;
                        if (this.ObjectBeDiscarded != null)
                        {
                            this.ObjectBeDiscarded(local);
                        }
                    }
                    if (this.count > this.maxCount)
                    {
                        this.maxCount = this.count;
                    }
                }
            }
        }

        public List<T> GetAll()
        {
            lock (this.locker)
            {
                List<T> list = new List<T>();
                for (int i = 0; i < this.count; i++)
                {
                    list.Add(this.array[(this.headIndex + i) % this.array.Length]);
                }
                return list;
            }
        }

        public T Peek()
        {
            lock (this.locker)
            {
                T local = default(T);
                if (this.count == 0)
                {
                    return local;
                }
                return this.array[this.headIndex];
            }
        }

        public T PeekAt(int index)
        {
            lock (this.locker)
            {
                T local = default(T);
                if (this.count < (index + 1))
                {
                    return local;
                }
                int num = (this.headIndex + index) % this.array.Length;
                return this.array[num];
            }
        }

        public override string ToString()
        {
            return string.Format("Count:{0},Size:{1}", this.count, this.Size);
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public bool Full
        {
            get
            {
                return (this.count >= this.array.Length);
            }
        }

        public int MaxCount
        {
            get
            {
                return this.maxCount;
            }
        }

        public int Size
        {
            get
            {
                return this.array.Length;
            }
        }
    }
}

