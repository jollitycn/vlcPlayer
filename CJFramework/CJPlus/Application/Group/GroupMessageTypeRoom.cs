namespace CJPlus.Application.Group
{
    using CJPlus.Core;
    using System;
    using System.Collections.Generic;

    public class GroupMessageTypeRoom : BaseMessageTypeRoom
    {
        private int int_2;
        private int int_3;
        private int int_4;
        private int int_5;
        private int int_6;

        public GroupMessageTypeRoom()
        {
            this.int_2 = 1;
            this.int_3 = 2;
            this.int_4 = 3;
            this.int_5 = 4;
            this.int_6 = 5;
            base.StartKey = 600;
        }

        public GroupMessageTypeRoom(int _startKey)
        {
            this.int_2 = 1;
            this.int_3 = 2;
            this.int_4 = 3;
            this.int_5 = 4;
            this.int_6 = 5;
            base.StartKey = _startKey;
        }

        public int BroadcastBlob
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

        public int BroadcastByServer
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

        public int GetGroupMembers
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

        public int GroupmateConnectedNotify
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

        public int GroupmateOfflineNotify
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
                return new List<int> { this.int_4 };
            }
        }
    }
}

