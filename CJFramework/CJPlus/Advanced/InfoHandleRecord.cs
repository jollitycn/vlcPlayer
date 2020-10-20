namespace CJPlus.Advanced
{
    using System;
    using System.Diagnostics;

    public class InfoHandleRecord
    {
        private DateTime dateTime_0 = DateTime.Now;
        private CJPlus.Advanced.InformationStyle informationStyle_0 = CJPlus.Advanced.InformationStyle.Common;
        private int int_0 = 0;
        private int int_1 = 0;
        private int int_2 = 0;
        private Stopwatch stopwatch_0;

        internal InfoHandleRecord(int id, int infoType, CJPlus.Advanced.InformationStyle style)
        {
            this.int_0 = id;
            this.informationStyle_0 = style;
            this.int_1 = infoType;
            this.stopwatch_0 = Stopwatch.StartNew();
        }

        internal void method_0()
        {
            this.stopwatch_0.Stop();
            this.int_2 = (int) this.stopwatch_0.ElapsedMilliseconds;
        }

        public override string ToString()
        {
            return string.Format("InfoType : {0}, StartTime : {1}, TimeSpent : {2}, Style : {3}", new object[] { this.int_1, this.dateTime_0, this.int_2, this.informationStyle_0 });
        }

        public int ID
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
                return this.int_1;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return this.dateTime_0;
            }
        }

        public int TimeSpent
        {
            get
            {
                return this.int_2;
            }
        }
    }
}

