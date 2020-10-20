namespace CJBasic.DataStructure
{
    using System;
    using System.Collections.Generic;

    public interface IPriorityManager
    {
        void AddWaiter(int waiterID);
        void Clear();
        bool Contains(int waiterID);
        int? GetNextWaiter();
        IList<int> GetWaiterList();
        int[] GetWaitersByPriority();
        void RemoveWaiter(int waiterID);

        int Count { get; }
    }
}

