namespace CJBasic.ObjectManagement.Managers
{
    using CJBasic;
    using System;

    public interface ISamePriorityObjectManager<T>
    {
        event CbGeneric<T> WaiterDiscarded;

        void AddWaiter(T waiter);
        void Clear();
        bool Contains(T waiter);
        T GetNextWaiter();
        T[] GetWaitersByPriority();
        T PopNextWaiter();
        void RemoveWaiter(T waiter);

        CJBasic.ObjectManagement.Managers.ActionTypeOnAddOverflow ActionTypeOnAddOverflow { get; }

        int Capacity { get; }

        int Count { get; }

        int DetectSpanInMSecsOnWait { get; set; }

        bool Full { get; }
    }
}

