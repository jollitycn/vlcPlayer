namespace CJPlus.Application.Basic
{
    using System;

    public class ReqLogonContract
    {
        private string string_0;
        private string string_1;
        private string string_2;

        public ReqLogonContract()
        {
            this.string_0 = "";
            this.string_1 = "";
            this.string_2 = "";
        }

        public ReqLogonContract(string _password, string _systemToken, string _authorizedUser)
        {
            this.string_0 = "";
            this.string_1 = "";
            this.string_2 = "";
            this.string_2 = _password;
            this.string_1 = _systemToken;
            this.string_0 = _authorizedUser;
        }

        public string AuthorizedUser
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

        public string Password
        {
            get
            {
                return this.string_2;
            }
            set
            {
                this.string_2 = value;
            }
        }

        public string SystemToken
        {
            get
            {
                return this.string_1;
            }
            set
            {
                this.string_1 = value;
            }
        }
    }
}

