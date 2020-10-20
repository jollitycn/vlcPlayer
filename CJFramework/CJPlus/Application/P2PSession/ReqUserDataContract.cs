namespace CJPlus.Application.P2PSession
{
    using System;

    public class ReqUserDataContract
    {
        private string string_0;

        public ReqUserDataContract()
        {
        }

        public ReqUserDataContract(string _friendID)
        {
            this.string_0 = _friendID;
        }

        public string FriendID
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

