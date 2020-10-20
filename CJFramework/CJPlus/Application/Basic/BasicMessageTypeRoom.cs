namespace CJPlus.Application.Basic
{
    using CJPlus.Core;
    using System;
    using System.Collections.Generic;

    public class BasicMessageTypeRoom : BaseMessageTypeRoom
    {
        private int int_10;
        private int int_11;
        private int int_12;
        private int int_13;
        private int int_14;
        private int int_15;
        private int int_2;
        private int int_3;
        private int int_4;
        private int int_5;
        private int int_6;
        private int int_7;
        private int int_8;
        private int int_9;

        public BasicMessageTypeRoom()
        {
            this.int_2 = 1;
            this.int_3 = 2;
            this.int_4 = 3;
            this.int_5 = 4;
            this.int_6 = 5;
            this.int_7 = 8;
            this.int_8 = 9;
            this.int_9 = 10;
            this.int_10 = 11;
            this.int_11 = 12;
            this.int_12 = 13;
            this.int_13 = 14;
            this.int_14 = 15;
            this.int_15 = 0x63;
            base.StartKey = 100;
        }

        public BasicMessageTypeRoom(int _startKey)
        {
            this.int_2 = 1;
            this.int_3 = 2;
            this.int_4 = 3;
            this.int_5 = 4;
            this.int_6 = 5;
            this.int_7 = 8;
            this.int_8 = 9;
            this.int_9 = 10;
            this.int_10 = 11;
            this.int_11 = 12;
            this.int_12 = 13;
            this.int_13 = 14;
            this.int_14 = 15;
            this.int_15 = 0x63;
            base.StartKey = _startKey;
        }

        public int BeingKickedOutNotify
        {
            get
            {
                return this.int_8;
            }
            set
            {
                this.int_8 = value;
            }
        }

        public int BeingPushedOutNotify
        {
            get
            {
                return this.int_6;
            }
            set
            {
                this.int_6 = value;
            }
        }

        public int CallClient
        {
            get
            {
                return this.int_14;
            }
            set
            {
                this.int_14 = value;
            }
        }

        public int GetAllOnlineUsers
        {
            get
            {
                return this.int_9;
            }
            set
            {
                this.int_9 = value;
            }
        }

        public int GetMyIPE
        {
            get
            {
                return this.int_2;
            }
            set
            {
                this.int_2 = value;
            }
        }

        public int HeartBeat
        {
            get
            {
                return this.int_5;
            }
            set
            {
                this.int_5 = value;
            }
        }

        public int Int32_0
        {
            get
            {
                return this.int_12;
            }
            set
            {
                this.int_12 = value;
            }
        }

        public int KickOut
        {
            get
            {
                return this.int_7;
            }
            set
            {
                this.int_7 = value;
            }
        }

        public int Logon
        {
            get
            {
                return this.int_11;
            }
            set
            {
                this.int_11 = value;
            }
        }

        public int PingAck
        {
            get
            {
                return this.int_4;
            }
            set
            {
                this.int_4 = value;
            }
        }

        public int PingByP2PChannel
        {
            get
            {
                return this.int_15;
            }
            set
            {
                this.int_15 = value;
            }
        }

        public int PingByServer
        {
            get
            {
                return this.int_3;
            }
            set
            {
                this.int_3 = value;
            }
        }

        public override IList<int> PushKeyList
        {
            get
            {
                return new List<int> { 
                    this.int_2,
                    this.int_9,
                    this.int_10,
                    this.int_13,
                    this.int_11,
                    this.int_4,
                    this.int_12
                };
            }
        }

        public int QueryOnline
        {
            get
            {
                return this.int_10;
            }
            set
            {
                this.int_10 = value;
            }
        }

        public int QueryOnlines
        {
            get
            {
                return this.int_13;
            }
            set
            {
                this.int_13 = value;
            }
        }
    }
}

