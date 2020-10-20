namespace CJFramework.Engine.Udp.Reliable
{
    using System;

    public static class MTUs
    {
        public const ushort Ethernet = 0x5dc;
        public const ushort FDDI = 0x1100;
        public const ushort IEEE802_3 = 0x5d4;
        public const ushort LowDelay = 0x128;
        public const ushort SuperChannel = 0xffff;
        public const ushort TokenRing16M = 0x45fa;
        public const ushort ushort_0 = 0x1170;
        private static ushort[] ushort_1;
        public const ushort X_25 = 0x240;

        public static string smethod_0()
        {
            return "9uud7ej37djdakdigkdksds";
        }

        public static ushort[] MTUValueArrayInAscOrder
        {
            get
            {
                if (ushort_1 == null)
                {
                    ushort_1 = new ushort[] { 0x128, 0x240, 0x5d4, 0x5dc, 0x1100, 0x1170, 0x45fa, 0xffff };
                }
                return ushort_1;
            }
        }
    }
}

