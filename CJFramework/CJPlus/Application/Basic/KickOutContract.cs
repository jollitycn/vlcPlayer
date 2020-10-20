namespace CJPlus.Application.Basic
{
    using System;

    public class KickOutContract
    {
        private string string_0;

        public KickOutContract()
        {
        }

        public KickOutContract(string targetUserID)
        {
            this.string_0 = targetUserID;
        }

        public string UserBeKickedOut
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

