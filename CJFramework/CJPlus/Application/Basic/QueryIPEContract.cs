namespace CJPlus.Application.Basic
{
    using System;

    public class QueryIPEContract
    {
        private string string_0;

        public QueryIPEContract()
        {
        }

        public QueryIPEContract(string targetUserID)
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

