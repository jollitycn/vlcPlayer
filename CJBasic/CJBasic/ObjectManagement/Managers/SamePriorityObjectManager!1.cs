namespace CJBasic.ObjectManagement.Managers
{
    using CJBasic;
    using CJBasic.Threading.Synchronize;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class SamePriorityObjectManager<T> : ISamePriorityObjectManager<T>
    {
        private CJBasic.ObjectManagement.Managers.ActionTypeOnAddOverflow actionTypeOnAddOverflow;
        private int capacity;
        private int detectSpanInMSecsOnWait;
        private SmartRWLocker smartRWLocker;
        private LinkedList<T> waiterList;

        public event CbGeneric<T> WaiterDiscarded;

        public SamePriorityObjectManager()
        {
            this.waiterList = new LinkedList<T>();
            this.smartRWLocker = new SmartRWLocker();
            this.capacity = 0x7fffffff;
            this.actionTypeOnAddOverflow = CJBasic.ObjectManagement.Managers.ActionTypeOnAddOverflow.Wait;
            this.detectSpanInMSecsOnWait = 10;
            this.WaiterDiscarded += delegate {
            };
        }

        public SamePriorityObjectManager(PriorityManagerPara para) : this(para.Capacity, para.ActionTypeOnAddOverflow, para.DetectSpanInMSecsOnWait)
        {
        }

        public SamePriorityObjectManager(int _capacity, CJBasic.ObjectManagement.Managers.ActionTypeOnAddOverflow actionType) : this(_capacity, actionType, 10)
        {
        }

        public SamePriorityObjectManager(int _capacity, CJBasic.ObjectManagement.Managers.ActionTypeOnAddOverflow actionType, int _detectSpanInMSecsOnWait) : this()
        {
            this.capacity = _capacity;
            this.actionTypeOnAddOverflow = actionType;
            this.detectSpanInMSecsOnWait = _detectSpanInMSecsOnWait;
        }

        public void AddWaiter(T waiter)
        {
            LockingObject obj2;
            if (this.waiterList.Count < this.capacity)
            {
                using (obj2 = this.smartRWLocker.Lock(AccessMode.Write))
                {
                    this.waiterList.AddLast(waiter);
                    return;
                }
            }
            if (this.actionTypeOnAddOverflow == CJBasic.ObjectManagement.Managers.ActionTypeOnAddOverflow.DiscardCurrent)
            {
                this.WaiterDiscarded(waiter);
            }
            else
            {
                T local;
                if (this.actionTypeOnAddOverflow == CJBasic.ObjectManagement.Managers.ActionTypeOnAddOverflow.DiscardLatest)
                {
                    local = default(T);
                    using (obj2 = this.smartRWLocker.Lock(AccessMode.Write))
                    {
                        if (this.waiterList.Count > 0)
                        {
                            local = this.waiterList.Last.Value;
                            this.waiterList.RemoveLast();
                        }
                        this.waiterList.AddLast(waiter);
                    }
                    this.WaiterDiscarded(local);
                }
                else if (this.actionTypeOnAddOverflow == CJBasic.ObjectManagement.Managers.ActionTypeOnAddOverflow.DiscardOldest)
                {
                    local = default(T);
                    using (obj2 = this.smartRWLocker.Lock(AccessMode.Write))
                    {
                        if (this.waiterList.Count > 0)
                        {
                            local = this.waiterList.First.Value;
                            this.waiterList.RemoveFirst();
                        }
                        this.waiterList.AddLast(waiter);
                    }
                    this.WaiterDiscarded(local);
                }
                else
                {
                    while (this.waiterList.Count >= this.capacity)
                    {
                        Thread.Sleep(this.detectSpanInMSecsOnWait);
                    }
                    using (obj2 = this.smartRWLocker.Lock(AccessMode.Write))
                    {
                        this.waiterList.AddLast(waiter);
                    }
                }
            }
        }

        public void Clear()
        {
            using (this.smartRWLocker.Lock(AccessMode.Write))
            {
                this.waiterList.Clear();
            }
        }

        public bool Contains(T waiter)
        {
            using (this.smartRWLocker.Lock(AccessMode.Read))
            {
                return this.waiterList.Contains(waiter);
            }
        }

        public T GetNextWaiter()
        {
            using (this.smartRWLocker.Lock(AccessMode.Read))
            {
                if (this.waiterList.Count == 0)
                {
                    return default(T);
                }
                return this.waiterList.First.Value;
            }
        }

        public T[] GetWaitersByPriority()
        {
            using (this.smartRWLocker.Lock(AccessMode.Read))
            {
                T[] localArray = new T[this.Count];
                if (localArray.Length != 0)
                {
                    LinkedListNode<T> first = this.waiterList.First;
                    localArray[0] = first.Value;
                    LinkedListNode<T> next = first;
                    for (int i = 1; i < localArray.Length; i++)
                    {
                        next = next.Next;
                        localArray[i] = next.Value;
                    }
                }
                return localArray;
            }
        }

        public T PopNextWaiter()
        {
            using (this.smartRWLocker.Lock(AccessMode.Write))
            {
                if (this.waiterList.Count == 0)
                {
                    return default(T);
                }
                T local = this.waiterList.First.Value;
                this.waiterList.RemoveFirst();
                return local;
            }
        }

        public void RemoveWaiter(T waiter)
        {
            using (this.smartRWLocker.Lock(AccessMode.Write))
            {
                if (this.waiterList.Contains(waiter))
                {
                    this.waiterList.Remove(waiter);
                }
            }
        }

        public CJBasic.ObjectManagement.Managers.ActionTypeOnAddOverflow ActionTypeOnAddOverflow
        {
            get
            {
                return this.actionTypeOnAddOverflow;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public int Count
        {
            get
            {
                using (this.smartRWLocker.Lock(AccessMode.Read))
                {
                    return this.waiterList.Count;
                }
            }
        }

        public int DetectSpanInMSecsOnWait
        {
            get
            {
                return this.detectSpanInMSecsOnWait;
            }
            set
            {
                this.detectSpanInMSecsOnWait = (value <= 0) ? 1 : value;
            }
        }

        public bool Full
        {
            get
            {
                return (this.Count >= this.capacity);
            }
        }
    }
}

