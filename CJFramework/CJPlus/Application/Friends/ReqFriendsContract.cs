namespace CJPlus.Application.Friends
{
    using System;

    public class ReqFriendsContract
    {
        private bool bool_0;
        private string string_0;

        public ReqFriendsContract()
        {
            this.bool_0 = true;
            this.string_0 = null;
        }

        public ReqFriendsContract(bool _justOnline, string _tag)
        {
            this.bool_0 = true;
            this.string_0 = null;
            this.bool_0 = _justOnline;
            this.string_0 = _tag;
        }

        public bool JustOnline
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

        public string Tag
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

