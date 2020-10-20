namespace CJBasic.ObjectManagement
{
    using CJBasic.Threading.Synchronize;
    using System;
    using System.Collections.Generic;

    public class TopNOrderedContainer<TObj> where TObj: IOrdered<TObj>
    {
        private TObj[] orderedArray;
        private SmartRWLocker smartRWLocker;
        private int topNumber;
        private int validObjCount;

        public TopNOrderedContainer()
        {
            this.orderedArray = null;
            this.validObjCount = 0;
            this.smartRWLocker = new SmartRWLocker();
            this.topNumber = 10;
        }

        public TopNOrderedContainer(int _topNumber)
        {
            this.orderedArray = null;
            this.validObjCount = 0;
            this.smartRWLocker = new SmartRWLocker();
            this.topNumber = 10;
            this.topNumber = _topNumber;
        }

        public void Add(IEnumerable<TObj> list)
        {
            if (list != null)
            {
                using (this.smartRWLocker.Lock(AccessMode.Write))
                {
                    foreach (TObj local in list)
                    {
                        this.DoAdd(local);
                    }
                }
            }
        }

        public void Add(TObj obj)
        {
            using (this.smartRWLocker.Lock(AccessMode.Write))
            {
                this.DoAdd(obj);
            }
        }

        private void Adjust(int posIndex)
        {
            TObj local = this.orderedArray[posIndex];
            int index = -1;
            if (local.IsTopThan(this.orderedArray[0]))
            {
                index = 0;
            }
            else
            {
                int num2 = 0;
                int num3 = posIndex;
                while ((num3 - num2) > 1)
                {
                    int num4 = (num2 + num3) / 2;
                    if (local.IsTopThan(this.orderedArray[num4]))
                    {
                        num3 = num4;
                    }
                    else
                    {
                        num2 = num4;
                    }
                }
                index = num2;
                if ((num3 != num2) && !local.IsTopThan(this.orderedArray[num2]))
                {
                    index = num3;
                }
            }
            for (int i = posIndex; i > index; i--)
            {
                this.orderedArray[i] = this.orderedArray[i - 1];
            }
            this.orderedArray[index] = local;
        }

        private void DoAdd(TObj obj)
        {
            if (obj != null)
            {
                if (this.validObjCount < this.topNumber)
                {
                    this.orderedArray[this.validObjCount] = obj;
                    this.Adjust(this.validObjCount);
                    this.validObjCount++;
                }
                else if (!this.orderedArray[this.topNumber - 1].IsTopThan(obj))
                {
                    this.orderedArray[this.topNumber - 1] = obj;
                    this.Adjust(this.topNumber - 1);
                }
            }
        }

        public TObj[] GetTopN()
        {
            using (this.smartRWLocker.Lock(AccessMode.Read))
            {
                return (TObj[]) this.orderedArray.Clone();
            }
        }

        public void Initialize()
        {
            if (this.topNumber < 1)
            {
                throw new Exception("The value of TopNumber must greater than 0 ");
            }
            this.orderedArray = new TObj[this.topNumber];
        }

        public int TopNumber
        {
            get
            {
                return this.topNumber;
            }
            set
            {
                this.topNumber = value;
            }
        }
    }
}

