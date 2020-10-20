namespace CJPlus.Application.CustomizeInfo
{
    using System;

    public class ResGetTimeContract
    {
        private DateTime dateTime_0;

        public ResGetTimeContract()
        {
            this.dateTime_0 = DateTime.Now;
        }

        public ResGetTimeContract(DateTime dt)
        {
            this.dateTime_0 = DateTime.Now;
            this.dateTime_0 = dt;
        }

        public DateTime Time
        {
            get
            {
                return this.dateTime_0;
            }
            set
            {
                this.dateTime_0 = value;
            }
        }
    }
}

