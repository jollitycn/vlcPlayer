namespace CJFramework.Engine.Udp.Reliable
{
    using System;
    using System.Net;

    [Serializable]
    public class OutUdpSessionState
    {
        private DateTime dateTime_0;
        private int int_0;
        private int int_1;
        private IPEndPoint ipendPoint_0;
        private string string_0;
        private uint uint_0;
        private ulong ulong_0;
        private ulong ulong_1;
        private ulong ulong_2;
        private ulong ulong_3;
        private ulong ulong_4;
        private ulong ulong_5;
        private ulong ulong_6;
        private ushort ushort_0;

        public OutUdpSessionState()
        {
            this.string_0 = "";
            this.int_0 = 0;
            this.ulong_0 = 0L;
            this.ulong_1 = 0L;
            this.uint_0 = 0;
            this.ushort_0 = 0;
            this.ulong_4 = 0L;
            this.ulong_5 = 0L;
            this.ulong_6 = 0L;
        }

        public OutUdpSessionState(IPEndPoint dest, string _destSecondID, DateTime _openTime, int _slideWindowSize, int _waitAckCount, ulong _minDatagramIDResending, ulong _resendCount, ulong _maxDatagramIDSended, ulong _maxDatagramIDReceivedOtherSide, uint _countInRecieveCacheOtherSide, ushort _PMTU, ulong _pingCount, ulong _pingAckCount, ulong _pingReceivedCount)
        {
            this.string_0 = "";
            this.int_0 = 0;
            this.ulong_0 = 0L;
            this.ulong_1 = 0L;
            this.uint_0 = 0;
            this.ushort_0 = 0;
            this.ulong_4 = 0L;
            this.ulong_5 = 0L;
            this.ulong_6 = 0L;
            this.ipendPoint_0 = dest;
            this.string_0 = _destSecondID;
            this.dateTime_0 = _openTime;
            this.int_0 = _slideWindowSize;
            this.int_1 = _waitAckCount;
            this.ulong_0 = _minDatagramIDResending;
            this.ulong_1 = _resendCount;
            this.ulong_2 = _maxDatagramIDSended;
            this.ulong_3 = _maxDatagramIDReceivedOtherSide;
            this.uint_0 = _countInRecieveCacheOtherSide;
            this.ushort_0 = _PMTU;
            this.ulong_4 = _pingCount;
            this.ulong_6 = _pingAckCount;
            this.ulong_5 = _pingReceivedCount;
        }

        public uint CountInRecieveCacheOtherSide
        {
            get
            {
                return this.uint_0;
            }
            set
            {
                this.uint_0 = value;
            }
        }

        public IPEndPoint DestIPE
        {
            get
            {
                return this.ipendPoint_0;
            }
            set
            {
                this.ipendPoint_0 = value;
            }
        }

        public string DestSecondID
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
            }
        }

        public ulong MaxDatagramIDReceivedOtherSide
        {
            get
            {
                return this.ulong_3;
            }
            set
            {
                this.ulong_3 = value;
            }
        }

        public ulong MaxDatagramIDSended
        {
            get
            {
                return this.ulong_2;
            }
            set
            {
                this.ulong_2 = value;
            }
        }

        public ulong MinDatagramIDResending
        {
            get
            {
                return this.ulong_0;
            }
            set
            {
                this.ulong_0 = value;
            }
        }

        public DateTime OpenTime
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

        public ulong PingAckCount
        {
            get
            {
                return this.ulong_6;
            }
            set
            {
                this.ulong_6 = value;
            }
        }

        public ulong PingCount
        {
            get
            {
                return this.ulong_4;
            }
            set
            {
                this.ulong_4 = value;
            }
        }

        public ulong PingReceivedCount
        {
            get
            {
                return this.ulong_5;
            }
            set
            {
                this.ulong_5 = value;
            }
        }

        public ushort PMTU
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

        public ulong ResendCount
        {
            get
            {
                return this.ulong_1;
            }
            set
            {
                this.ulong_1 = value;
            }
        }

        public int SlideWindowSize
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

        public int WaitAckCount
        {
            get
            {
                return this.int_1;
            }
            set
            {
                this.int_1 = value;
            }
        }
    }
}

