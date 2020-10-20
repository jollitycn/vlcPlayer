namespace CJBasic.ObjectManagement.Managers
{
    using CJBasic;
    using System;
    using System.Threading;

    public class PriorityManager<T> where T: class, IPriorityObject
    {
        private int priorityLevelCount;
        private ISamePriorityObjectManager<T>[] spObjectManagerAry;

        public event CbGeneric<T> WaiterDiscarded;

        public PriorityManager()
        {
            this.spObjectManagerAry = null;
            this.priorityLevelCount = 1;
            this.WaiterDiscarded += delegate {
            };
        }

        public void AddWaiter(T waiter)
        {
            if ((waiter.PriorityLevel < 0) || (waiter.PriorityLevel >= this.priorityLevelCount))
            {
                throw new Exception("Current PriorityManager instance don't support the PriorityLevel of the target.");
            }
            this.spObjectManagerAry[waiter.PriorityLevel].AddWaiter(waiter);
        }

        public void Clear()
        {
            if (this.spObjectManagerAry != null)
            {
                for (int i = 0; i < this.spObjectManagerAry.Length; i++)
                {
                    this.spObjectManagerAry[i].Clear();
                }
            }
        }

        public void Clear(int priorityLevel)
        {
            if (((this.spObjectManagerAry != null) && (priorityLevel >= 0)) && (priorityLevel < this.priorityLevelCount))
            {
                this.spObjectManagerAry[priorityLevel].Clear();
            }
        }

        public bool Contains(T waiter)
        {
            if ((waiter.PriorityLevel < 0) || (waiter.PriorityLevel >= this.priorityLevelCount))
            {
                return false;
            }
            return this.spObjectManagerAry[waiter.PriorityLevel].Contains(waiter);
        }

        public int GetCount(int priorityLevel)
        {
            if ((priorityLevel < 0) || (priorityLevel >= this.priorityLevelCount))
            {
                return 0;
            }
            return this.spObjectManagerAry[priorityLevel].Count;
        }

        public T GetNextWaiter()
        {
            for (int i = 0; i < this.spObjectManagerAry.Length; i++)
            {
                if (this.spObjectManagerAry[i].Count > 0)
                {
                    return this.spObjectManagerAry[i].GetNextWaiter();
                }
            }
            return default(T);
        }

        public T[] GetWaitersByPriority()
        {
            if (this.Count == 0)
            {
                return null;
            }
            T[] localArray = new T[this.Count];
            int num = 0;
            for (int i = 0; i < this.spObjectManagerAry.Length; i++)
            {
                if (this.spObjectManagerAry[i].Count > 0)
                {
                    T[] waitersByPriority = this.spObjectManagerAry[i].GetWaitersByPriority();
                    for (int j = 0; j < waitersByPriority.Length; j++)
                    {
                        localArray[num++] = waitersByPriority[j];
                    }
                }
            }
            return localArray;
        }

        public void Initialize(int _priorityLevelCount)
        {
            if (_priorityLevelCount < 1)
            {
                throw new Exception("Parameter _priorityLevelCount must > 0 !");
            }
            this.Initialize(_priorityLevelCount, new PriorityManagerPara[_priorityLevelCount]);
        }

        public void Initialize(int _priorityLevelCount, params PriorityManagerPara[] paraAry)
        {
            if (_priorityLevelCount < 1)
            {
                throw new Exception("Parameter _priorityLevelCount must > 0 !");
            }
            if (paraAry.Length != _priorityLevelCount)
            {
                throw new Exception("Parameter _priorityLevelCount must equal the length of paraAry !");
            }
            this.priorityLevelCount = _priorityLevelCount;
            this.spObjectManagerAry = new ISamePriorityObjectManager<T>[this.priorityLevelCount];
            for (int i = 0; i < this.spObjectManagerAry.Length; i++)
            {
                if (paraAry[i] == null)
                {
                    this.spObjectManagerAry[i] = new SamePriorityObjectManager<T>();
                }
                else
                {
                    this.spObjectManagerAry[i] = new SamePriorityObjectManager<T>(paraAry[i]);
                }
                this.spObjectManagerAry[i].WaiterDiscarded += new CbGeneric<T>(this.PriorityManager_WaiterDiscarded);
            }
        }

        public T PopNextWaiter()
        {
            for (int i = 0; i < this.spObjectManagerAry.Length; i++)
            {
                if (this.spObjectManagerAry[i].Count > 0)
                {
                    return this.spObjectManagerAry[i].PopNextWaiter();
                }
            }
            return default(T);
        }

        private void PriorityManager_WaiterDiscarded(T obj)
        {
            this.WaiterDiscarded(obj);
        }

        public void RemoveWaiter(T waiter)
        {
            if ((waiter.PriorityLevel >= 0) && (waiter.PriorityLevel < this.priorityLevelCount))
            {
                this.spObjectManagerAry[waiter.PriorityLevel].RemoveWaiter(waiter);
            }
        }

        public int Count
        {
            get
            {
                int num = 0;
                for (int i = 0; i < this.spObjectManagerAry.Length; i++)
                {
                    num += this.spObjectManagerAry[i].Count;
                }
                return num;
            }
        }

        public int PriorityLevelCount
        {
            get
            {
                return this.priorityLevelCount;
            }
        }
    }
}

