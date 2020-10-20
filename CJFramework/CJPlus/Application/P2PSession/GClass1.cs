namespace CJPlus.Application.P2PSession
{
    using System;

    public class GClass1
    {
        private ushort ushort_0;

        public GClass1()
        {
            this.ushort_0 = 0;
        }

        public GClass1(ushort _pmtu)
        {
            this.ushort_0 = 0;
            this.ushort_0 = _pmtu;
        }

        public ushort Pmtu
        {
            get
            {
                return this.ushort_0;
            }
            set
            {
                this.ushort_0 = value;
            }
        }
    }
}

