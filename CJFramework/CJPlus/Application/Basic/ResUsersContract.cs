namespace CJPlus.Application.Basic
{
    using System;
    using System.Collections.Generic;

    public class ResUsersContract
    {
        private List<string> list_0;

        public ResUsersContract()
        {
            this.list_0 = new List<string>();
        }

        public ResUsersContract(List<string> users)
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

