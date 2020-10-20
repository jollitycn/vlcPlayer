namespace CJPlus.Advanced
{
    using CJBasic.ObjectManagement;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class InfoHandleRecordStatistics
    {
        private CircleQueue<InfoHandleRecord> circleQueue_0 = new CircleQueue<InfoHandleRecord>(10);
        private CJPlus.Advanced.InformationStyle informationStyle_0 = CJPlus.Advanced.InformationStyle.Common;
        private int int_0 = 0;
        private long long_0 = 0L;
        private long long_1 = 0L;

        internal InfoHandleRecordStatistics(int infoType, CJPlus.Advanced.InformationStyle style)
        {
            this.int_0 = infoType;
            this.informationStyle_0 = style;
        }

        internal void method_0(InfoHandleRecord infoHandleRecord_0, bool bool_0)
        {
            Interlocked.Increment(ref this.long_0);
            if (bool_0)
            {
                Interlocked.Increment(ref this.long_1);
            }
            else
            {
                this.circleQueue_0.Enqueue(infoHandleRecord_0);
            }
        }

        public override string ToString()
        {
            return string.Format("InfoType : {0}, CallCount : {1}, ExceptionCount : {2}", this.int_0, this.long_0, this.long_1);
        }

        public long CallCount
        {
            get
            {
                return this.long_0;
            }
        }

        public long ExceptionCount
        {
            get
            {
                return this.long_1;
            }
        }

        public CJPlus.Advanced.InformationStyle InformationStyle
        {
            get
            {
                return this.informationStyle_0;
            }
        }

        public int InformationType
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
            }
        }

        public List<InfoHandleRecord> LastRecords
        {
            get
            {
                return this.circleQueue_0.GetAll();
            }
        }
    }
}

