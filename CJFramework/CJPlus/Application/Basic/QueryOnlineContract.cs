namespace CJPlus.Application.Basic
{
    using System;

    public class QueryOnlineContract
    {
        private string string_0;

        public QueryOnlineContract()
        {
        }

        public QueryOnlineContract(string targetUserID)
        {
            this.string_0 = targetUserID;
        }

        public string UserID
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

