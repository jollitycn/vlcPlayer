namespace CJPlus.Application.P2PSession
{
    using CJPlus.Core;
    using System;
    using System.Collections.Generic;

    public class P2PSessionMessageTypeRoom : BaseMessageTypeRoom
    {
        private int int_10;
        private int int_11;
        private int int_2;
        private int int_3;
        private int int_4;
        private int int_5;
        private int int_6;
        private int int_7;
        private int int_8;
        private int int_9;

        public P2PSessionMessageTypeRoom()
        {
            this.int_2 = 1;
            this.int_3 = 2;
            this.int_4 = 3;
            this.int_5 = 4;
            this.int_6 = 5;
            this.int_7 = 8;
            this.int_8 = 10;
            this.int_9 = 11;
            this.int_10 = 12;
            this.int_11 = 13;
            base.StartKey = 400;
        }

        public P2PSessionMessageTypeRoom(int _startKey)
        {
            this.int_2 = 1;
            this.int_3 = 2;
            this.int_4 = 3;
            this.int_5 = 4;
            this.int_6 = 5;
            this.int_7 = 8;
            this.int_8 = 10;
            this.int_9 = 11;
            this.int_10 = 12;
            this.int_11 = 13;
            base.StartKey = _startKey;
        }

        public int GetMyPublicIPE
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

        public int Help4UDP_Exit
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

        public int Help4UDP_FeedbackVacancy
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

        public int Help4UDP_PMTUTestAck
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

        public int Help4UDP_SynAck
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

        public int InviteTcpP2P
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

        public int InviteUdpP2P
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

        public int P2PLogon
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

        public override IList<int> PushKeyList
        {
            get
            {
                return new List<int> { 
                    this.int_3,
                    this.int_6
                };
            }
        }

        public int ReqUserData
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

        public int TcpP2PChannelTest
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
    }
}

