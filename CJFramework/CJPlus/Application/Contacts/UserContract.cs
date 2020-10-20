namespace CJPlus.Application.Contacts
{
    using System;

    public class UserContract
    {
        private string string_0;

        public UserContract()
        {
        }

        public UserContract(string _userID)
        {
            this.string_0 = _userID;
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

