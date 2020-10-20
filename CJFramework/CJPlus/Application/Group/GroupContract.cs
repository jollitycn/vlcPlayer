namespace CJPlus.Application.Group
{
    using System;

    public class GroupContract
    {
        private string string_0;

        public GroupContract()
        {
        }

        public GroupContract(string _groupID)
        {
            this.string_0 = _groupID;
        }

        public string GroupID
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

