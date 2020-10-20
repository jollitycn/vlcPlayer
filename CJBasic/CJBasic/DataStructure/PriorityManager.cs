namespace CJBasic.DataStructure
{
    using CJBasic.Collections;
    using System;
    using System.Collections.Generic;

    public class PriorityManager : IPriorityManager
    {
        private object listLock = new object();
        private LinkedList<int> waiterIDList = new LinkedList<int>();

        public void AddWaiter(int waiterID)
        {
            if (!this.waiterIDList.Contains(waiterID))
            {
                lock (this.listLock)
                {
                    this.waiterIDList.AddLast(waiterID);
                }
            }
        }

        public void Clear()
        {
            lock (this.waiterIDList)
            {
                this.waiterIDList.Clear();
            }
        }

        public bool Contains(int waiterID)
        {
            return this.waiterIDList.Contains(waiterID);
        }

        public int? GetNextWaiter()
        {
            lock (this.listLock)
            {
                if (this.waiterIDList.Count == 0)
                {
                    return null;
                }
                return new int?(this.waiterIDList.First.Value);
            }
        }

        public IList<int> GetWaiterList()
        {
            lock (this.waiterIDList)
            {
                return CollectionConverter.CopyAllToList<int>(this.waiterIDList);
            }
        }

        public int[] GetWaitersByPriority()
        {
            lock (this.listLock)
            {
                int[] numArray = new int[this.Count];
                if (numArray.Length != 0)
                {
                    LinkedListNode<int> first = this.waiterIDList.First;
                    numArray[0] = first.Value;
                    LinkedListNode<int> next = first;
                    for (int i = 1; i < numArray.Length; i++)
                    {
                        next = next.Next;
                        numArray[i] = next.Value;
                    }
                }
                return numArray;
            }
        }

        public void RemoveWaiter(int waiterID)
        {
            if (this.waiterIDList.Contains(waiterID))
            {
                lock (this.listLock)
                {
                    this.waiterIDList.Remove(waiterID);
                }
            }
        }

        public int Count
        {
            get
            {
                return this.waiterIDList.Count;
            }
        }
    }
}

