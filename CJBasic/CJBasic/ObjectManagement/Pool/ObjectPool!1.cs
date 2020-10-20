namespace CJBasic.ObjectManagement.Pool
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class ObjectPool<TObject> : IObjectPool<TObject> where TObject: class
    {
        private IDictionary<TObject, TObject> busyDictionary;
        private int detectSpanInMSecs;
        private IList<TObject> idleList;
        private object locker;
        private int maxObjectCount;
        private int minObjectCount;
        private IPooledObjectCreator<TObject> pooledObjectCreator;

        public ObjectPool()
        {
            this.idleList = new List<TObject>();
            this.busyDictionary = new Dictionary<TObject, TObject>();
            this.locker = new object();
            this.minObjectCount = 0;
            this.maxObjectCount = 0x7fffffff;
            this.detectSpanInMSecs = 10;
            this.pooledObjectCreator = new DefaultPooledObjectCreator<TObject>();
        }

        public void GiveBack(TObject obj)
        {
            lock (this.locker)
            {
                if (this.busyDictionary.ContainsKey(obj))
                {
                    this.pooledObjectCreator.Reset(obj);
                    this.busyDictionary.Remove(obj);
                    this.idleList.Add(obj);
                }
            }
        }

        public void Initialize()
        {
            if (this.minObjectCount < 0)
            {
                throw new Exception("The MinObjectCount must be greater than 0 !");
            }
            if (this.minObjectCount > this.maxObjectCount)
            {
                throw new Exception("The MinObjectCount can't be greater than MaxObjectCount !");
            }
            if (this.detectSpanInMSecs < 0)
            {
                throw new Exception("The DetectSpanInMSecs must be greater than 0 !");
            }
            for (int i = 0; i < this.minObjectCount; i++)
            {
                TObject item = this.pooledObjectCreator.Create();
                this.idleList.Add(item);
            }
        }

        public TObject Rent()
        {
            lock (this.locker)
            {
                if ((this.idleList.Count == 0) && (this.busyDictionary.Count < this.maxObjectCount))
                {
                    TObject local = this.pooledObjectCreator.Create();
                    this.busyDictionary.Add(local, local);
                    return local;
                }
                while (this.idleList.Count == 0)
                {
                    Thread.Sleep(this.detectSpanInMSecs);
                }
                TObject key = this.idleList[0];
                this.idleList.RemoveAt(0);
                this.busyDictionary.Add(key, key);
                return key;
            }
        }

        public int DetectSpanInMSecs
        {
            get
            {
                return this.detectSpanInMSecs;
            }
            set
            {
                this.detectSpanInMSecs = value;
            }
        }

        public int MaxObjectCount
        {
            get
            {
                return this.maxObjectCount;
            }
            set
            {
                this.maxObjectCount = value;
            }
        }

        public int MinObjectCount
        {
            get
            {
                return this.minObjectCount;
            }
            set
            {
                this.minObjectCount = value;
            }
        }

        public IPooledObjectCreator<TObject> PooledObjectCreator
        {
            set
            {
                this.pooledObjectCreator = value ?? new DefaultPooledObjectCreator<TObject>();
            }
        }
    }
}

