namespace CJBasic.ObjectManagement
{
    using System;
    using System.Collections.Generic;

    public class LatestObjectCache<T>
    {
        private T[] array;
        private int capacity;
        private bool initialized;
        private bool isFull;
        private DateTime lastObjectAddedTime;
        private int latestObjectIndex;
        private object locker;

        public LatestObjectCache()
        {
            this.array = null;
            this.latestObjectIndex = -1;
            this.locker = new object();
            this.initialized = false;
            this.capacity = 10;
            this.isFull = false;
            this.lastObjectAddedTime = DateTime.Now;
        }

        public LatestObjectCache(int _capacity)
        {
            this.array = null;
            this.latestObjectIndex = -1;
            this.locker = new object();
            this.initialized = false;
            this.capacity = 10;
            this.isFull = false;
            this.lastObjectAddedTime = DateTime.Now;
            this.capacity = _capacity;
        }

        public void Add(T t)
        {
            lock (this.locker)
            {
                this.lastObjectAddedTime = DateTime.Now;
                this.latestObjectIndex = (this.latestObjectIndex + 1) % this.array.Length;
                this.array[this.latestObjectIndex] = t;
                if (!(this.isFull || (this.latestObjectIndex != (this.array.Length - 1))))
                {
                    this.isFull = true;
                }
            }
        }

        public List<T> GetLatestObjects()
        {
            lock (this.locker)
            {
                int num;
                List<T> list = new List<T>();
                if (!this.isFull)
                {
                    for (num = 0; num <= this.latestObjectIndex; num++)
                    {
                        list.Add(this.array[num]);
                    }
                    return list;
                }
                int num2 = (this.latestObjectIndex + 1) % this.array.Length;
                for (num = 0; num < this.array.Length; num++)
                {
                    int index = (num2 + num) % this.array.Length;
                    list.Add(this.array[index]);
                }
                return list;
            }
        }

        public void Initialize()
        {
            if (this.capacity <= 0)
            {
                throw new Exception("Capacity must be greater than 0.");
            }
            this.array = new T[this.capacity];
            this.latestObjectIndex = -1;
            this.initialized = true;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                if (this.initialized && (value != this.capacity))
                {
                    throw new Exception("Can't change the value of Capacity property after initialized.");
                }
                this.capacity = value;
            }
        }

        public bool IsFull
        {
            get
            {
                return this.isFull;
            }
        }

        public DateTime LastObjectAddedTime
        {
            get
            {
                return this.lastObjectAddedTime;
            }
        }

        private int ValidObjectCount
        {
            get
            {
                if (this.array == null)
                {
                    return 0;
                }
                if (this.isFull)
                {
                    return this.array.Length;
                }
                return (this.latestObjectIndex + 1);
            }
        }
    }
}

