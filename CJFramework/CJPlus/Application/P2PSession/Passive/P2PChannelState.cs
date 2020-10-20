namespace CJPlus.Application.P2PSession.Passive
{
    using CJFramework;
    using CJFramework.Core;
    using System;

    public class P2PChannelState
    {
        private AgileIPE agileIPE_0;
        private bool bool_0;
        private bool bool_1;
        private bool bool_2;
        private DateTime dateTime_0;
        private DateTime dateTime_1;
        private CJFramework.Core.ProtocolType protocolType_0;
        private string string_0;
        private uint uint_0;

        public P2PChannelState()
        {
            this.bool_0 = true;
            this.bool_1 = true;
            this.uint_0 = 0;
            this.dateTime_0 = DateTime.Now;
            this.bool_2 = false;
        }

        public P2PChannelState(string _destUserID, CJFramework.Core.ProtocolType _protocolType, AgileIPE _destIPE, DateTime _openTime, bool _reliable, bool sameLAN)
        {
            this.bool_0 = true;
            this.bool_1 = true;
            this.uint_0 = 0;
            this.dateTime_0 = DateTime.Now;
            this.bool_2 = false;
            this.string_0 = _destUserID;
            this.protocolType_0 = _protocolType;
            this.agileIPE_0 = _destIPE;
            this.dateTime_1 = _openTime;
            this.bool_1 = _reliable;
            this.bool_2 = sameLAN;
        }

        public void MessageSent()
        {
            this.dateTime_0 = DateTime.Now;
            this.uint_0++;
        }

        public override string ToString()
        {
            return string.Format("DestUserID:{0},ProtocolType:{1},DestIPE:{2}", this.string_0, this.protocolType_0, this.agileIPE_0);
        }

        public bool Boolean_0
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                this.bool_2 = value;
            }
        }

        public AgileIPE DestIPE
        {
            get
            {
                return this.agileIPE_0;
            }
            set
            {
                this.agileIPE_0 = value;
            }
        }

        public string DestUserID
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

        public bool Enabled
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        public DateTime LastMessageSentTime
        {
            get
            {
                return this.dateTime_0;
            }
        }

        public uint MessageSentCount
        {
            get
            {
                return this.uint_0;
            }
        }

        public DateTime OpenTime
        {
            get
            {
                return this.dateTime_1;
            }
            set
            {
                this.dateTime_1 = value;
            }
        }

        public CJFramework.Core.ProtocolType ProtocolType
        {
            get
            {
                return this.protocolType_0;
            }
            set
            {
                this.protocolType_0 = value;
            }
        }

        public bool Reliable
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                this.bool_1 = value;
            }
        }
    }
}

