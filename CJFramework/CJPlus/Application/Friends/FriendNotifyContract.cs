namespace CJPlus.Application.Friends
{
    using System;

    public class FriendNotifyContract
    {
        private bool bool_0;
        private string string_0;

        public FriendNotifyContract()
        {
            this.bool_0 = true;
        }

        public FriendNotifyContract(string friendID, bool _connected)
        {
            this.bool_0 = true;
            this.string_0 = friendID;
            this.bool_0 = _connected;
        }

        public bool Connected
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

        public string FriendUserID
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
    }
}

