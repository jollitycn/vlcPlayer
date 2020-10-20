namespace CJPlus.Application.Contacts
{
    using System;
    using System.Collections.Generic;

    public class Groupmates
    {
        private List<string> list_0 = new List<string>();
        private List<string> list_1 = new List<string>();

        public List<string> OfflineGroupmates
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

        public List<string> OnlineGroupmates
        {
            get
            {
                return this.list_1;
            }
            set
            {
                this.list_1 = value;
            }
        }
    }
}

