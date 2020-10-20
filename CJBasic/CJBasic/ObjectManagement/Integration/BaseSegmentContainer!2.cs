namespace CJBasic.ObjectManagement.Integration
{
    using System;
    using System.Collections.Generic;

    public abstract class BaseSegmentContainer<TSegmentID, TVal> : ISegmentContainer<TSegmentID, TVal>
    {
        private bool pickFromSmallToBig;

        protected BaseSegmentContainer()
        {
            this.pickFromSmallToBig = true;
        }

        private List<TVal> DoPick(int startIndex, int pickCount)
        {
            List<TVal> list = new List<TVal>();
            int num = 0;
            bool flag = false;
            int num2 = 0;
            ISegment<TSegmentID, TVal> smallestSegment = null;
            if (this.pickFromSmallToBig)
            {
                smallestSegment = this.GetSmallestSegment();
            }
            else
            {
                smallestSegment = this.GetBiggestSegment();
            }
            while (smallestSegment != null)
            {
                bool flag2 = false;
                IList<TVal> content = smallestSegment.GetContent();
                int count = content.Count;
                if ((content != null) && (count > 0))
                {
                    if (!flag)
                    {
                        if ((num + count) >= startIndex)
                        {
                            flag = true;
                            flag2 = true;
                        }
                        else
                        {
                            num += count;
                        }
                    }
                    if (flag)
                    {
                        int num4;
                        int num5;
                        if (this.pickFromSmallToBig)
                        {
                            num4 = flag2 ? (startIndex - num) : 0;
                            num5 = num4;
                            while (num5 < count)
                            {
                                list.Add(content[num5]);
                                num2++;
                                if (num2 >= pickCount)
                                {
                                    return list;
                                }
                                num5++;
                            }
                        }
                        else
                        {
                            num4 = flag2 ? ((count - 1) - (startIndex - num)) : (count - 1);
                            for (num5 = num4; num5 >= 0; num5--)
                            {
                                list.Add(content[num5]);
                                num2++;
                                if (num2 >= pickCount)
                                {
                                    return list;
                                }
                            }
                        }
                    }
                }
                smallestSegment = this.GetNextSegment(smallestSegment.ID, this.pickFromSmallToBig);
            }
            return list;
        }

        public virtual List<ISegment<TSegmentID, TVal>> GetAllSegments()
        {
            List<ISegment<TSegmentID, TVal>> list = new List<ISegment<TSegmentID, TVal>>();
            ISegment<TSegmentID, TVal> smallestSegment = this.GetSmallestSegment();
            if (smallestSegment == null)
            {
                return list;
            }
            list.Add(smallestSegment);
            ISegment<TSegmentID, TVal> segment2 = smallestSegment;
            while (true)
            {
                ISegment<TSegmentID, TVal> nextSegment = this.GetNextSegment(segment2.ID, true);
                if (nextSegment == null)
                {
                    return list;
                }
                list.Add(nextSegment);
                segment2 = nextSegment;
            }
        }

        protected abstract ISegment<TSegmentID, TVal> GetBiggestSegment();
        protected abstract ISegment<TSegmentID, TVal> GetNextSegment(TSegmentID curSegmentID, bool fromSmallToBig);
        protected abstract ISegment<TSegmentID, TVal> GetSmallestSegment();
        public List<TVal> Pick(int startIndex, int pickCount)
        {
            if (startIndex < 0)
            {
                throw new Exception("startIndex must greater than 0 !");
            }
            if (pickCount <= 0)
            {
                return new List<TVal>();
            }
            return this.DoPick(startIndex, pickCount);
        }

        public bool PickFromSmallToBig
        {
            get
            {
                return this.pickFromSmallToBig;
            }
            set
            {
                this.pickFromSmallToBig = value;
            }
        }
    }
}

