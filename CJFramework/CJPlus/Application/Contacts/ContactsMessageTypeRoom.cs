namespace CJPlus.Application.Contacts
{
    using CJPlus.Core;
    using System;
    using System.Collections.Generic;

    public class ContactsMessageTypeRoom : BaseMessageTypeRoom
    {
        private int int_2;
        private int int_3;
        private int int_4;
        private int int_5;
        private int int_6;
        private int int_7;

        public ContactsMessageTypeRoom()
        {
            this.int_2 = 1;
            this.int_3 = 2;
            this.int_4 = 3;
            this.int_5 = 4;
            this.int_6 = 5;
            this.int_7 = 6;
            base.StartKey = 700;
        }

        public ContactsMessageTypeRoom(int _startKey)
        {
            this.int_2 = 1;
            this.int_3 = 2;
            this.int_4 = 3;
            this.int_5 = 4;
            this.int_6 = 5;
            this.int_7 = 6;
            base.StartKey = _startKey;
        }

        public int BroadcastBlob
        {
            get
            {
                return this.int_6;
            }
            set
            {
                this.int_6 = value;
            }
        }

        public int BroadcastByServer
        {
            get
            {
                return this.int_5;
            }
            set
            {
                this.int_5 = value;
            }
        }

        public int ContactsConnectedNotify
        {
            get
            {
                return this.int_3;
            }
            set
            {
                this.int_3 = value;
            }
        }

        public int ContactsOfflineNotify
        {
            get
            {
                return this.int_2;
            }
            set
            {
                this.int_2 = value;
            }
        }

        public int GetContracts
        {
            get
            {
                return this.int_7;
            }
            set
            {
                this.int_7 = value;
            }
        }

        public int GetGroupMembers
        {
            get
            {
                return this.int_4;
            }
            set
            {
                this.int_4 = value;
            }
        }

        public override IList<int> PushKeyList
        {
            get
            {
                return new List<int> { 
                    this.int_4,
                    this.int_7
                };
            }
        }
    }
}

