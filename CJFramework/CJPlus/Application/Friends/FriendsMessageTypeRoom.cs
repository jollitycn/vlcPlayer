namespace CJPlus.Application.Friends
{
    using CJPlus.Core;
    using System;
    using System.Collections.Generic;

    public class FriendsMessageTypeRoom : BaseMessageTypeRoom
    {
        private int int_2;
        private int int_3;

        public FriendsMessageTypeRoom()
        {
            this.int_2 = 1;
            this.int_3 = 2;
            base.StartKey = 500;
        }

        public FriendsMessageTypeRoom(int _startKey)
        {
            this.int_2 = 1;
            this.int_3 = 2;
            base.StartKey = _startKey;
        }

        public int FriendNotify
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

        public int GetFriends
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
                return new List<int> { this.int_3 };
            }
        }
    }
}

