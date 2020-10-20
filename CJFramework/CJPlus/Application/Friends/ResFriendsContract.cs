namespace CJPlus.Application.Friends
{
    using System;
    using System.Collections.Generic;

    public class ResFriendsContract
    {
        private List<string> list_0;

        public ResFriendsContract()
        {
            this.list_0 = new List<string>();
        }

        public ResFriendsContract(List<string> users)
        {
            this.list_0 = new List<string>();
            this.list_0 = users;
        }

        public List<string> UserList
        {
            get
            {
                return this.list_0;
            }
            set
            {
                this.list_0 = value;
            }
        }
    }
}

