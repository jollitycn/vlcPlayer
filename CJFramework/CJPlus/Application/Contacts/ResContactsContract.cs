namespace CJPlus.Application.Contacts
{
    using System;
    using System.Collections.Generic;

    public class ResContactsContract
    {
        private List<string> list_0;

        public ResContactsContract()
        {
            this.list_0 = new List<string>();
        }

        public ResContactsContract(List<string> users)
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

