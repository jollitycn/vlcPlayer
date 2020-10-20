namespace CJPlus.Application.CustomizeInfo
{
    using CJPlus.Core;
    using System;
    using System.Collections.Generic;

    public class CustomizeMessageTypeRoom : BaseMessageTypeRoom
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

        public CustomizeMessageTypeRoom()
        {
            this.int_2 = 1;
            this.int_3 = 2;
            this.int_4 = 3;
            this.int_5 = 4;
            this.int_6 = 5;
            this.int_7 = 6;
            this.int_8 = 7;
            this.int_9 = 8;
            this.int_10 = 9;
            this.int_11 = 10;
            base.StartKey = 200;
        }

        public CustomizeMessageTypeRoom(int _startKey)
        {
            this.int_2 = 1;
            this.int_3 = 2;
            this.int_4 = 3;
            this.int_5 = 4;
            this.int_6 = 5;
            this.int_7 = 6;
            this.int_8 = 7;
            this.int_9 = 8;
            this.int_10 = 9;
            this.int_11 = 10;
            base.StartKey = _startKey;
        }

        public int Ack
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

        public int BlobByRapidEngine
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

        public int BlobInformation
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

        public int GetClientTimeRequest
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

        public int GetClientTimeResponse
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

        public int InformationByPost
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

        public int InformationBySend
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

        public int InformationNeedAck
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

        public override IList<int> PushKeyList
        {
            get
            {
                return new List<int> { 
                    this.int_5,
                    this.int_7,
                    this.int_11
                };
            }
        }

        public int Request
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

        public int Response
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
    }
}

