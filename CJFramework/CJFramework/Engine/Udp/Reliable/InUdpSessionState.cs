namespace CJFramework.Engine.Udp.Reliable
{
    using System;
    using System.Net;

    [Serializable]
    public class InUdpSessionState
    {
        private byte byte_0;
        private DateTime dateTime_0;
        private int int_0;
        private IPEndPoint ipendPoint_0;
        private string string_0;
        private uint uint_0;
        private ulong ulong_0;
        private ulong ulong_1;

        public InUdpSessionState()
        {
            this.byte_0 = 0;
            this.string_0 = "";
            this.int_0 = 80;
            this.uint_0 = 0;
        }

        public InUdpSessionState(byte _destIdentity, IPEndPoint dest, string _destSecondID, DateTime _openTime, int _feedbackVacancySpanInMSecs, ulong _minDatagramIDInCache, ulong _maxDatagramIDReceived, uint _countInRecieveCache)
        {
            this.byte_0 = 0;
            this.string_0 = "";
            this.int_0 = 80;
            this.uint_0 = 0;
            this.byte_0 = _destIdentity;
            this.ipendPoint_0 = dest;
            this.string_0 = _destSecondID;
            this.dateTime_0 = _openTime;
            this.ulong_0 = _minDatagramIDInCache;
            this.ulong_1 = _maxDatagramIDReceived;
            this.uint_0 = _countInRecieveCache;
            this.int_0 = _feedbackVacancySpanInMSecs;
        }

        public uint CountInRecieveCache
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

        public byte DestIdentity
        {
            get
            {
                return this.byte_0;
            }
            set
            {
                this.byte_0 = value;
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

        public int FeedbackVacancySpanInMSecs
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

        public ulong MaxDatagramIDReceived
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

        public ulong MinDatagramIDInCache
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
    }
}

