namespace CJPlus.Application.Contacts
{
    using CJFramework;
    using System;

    public class BroadcastContract
    {
        private CJFramework.ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0;
        private byte[] byte_0;
        private int int_0;
        private string string_0;
        private string string_1;

        public BroadcastContract()
        {
            this.string_0 = "";
            this.int_0 = 0;
            this.string_1 = null;
            this.actionTypeOnChannelIsBusy_0 = CJFramework.ActionTypeOnChannelIsBusy.Continue;
        }

        public BroadcastContract(string _groupID, int infoType, byte[] info, string _tag, CJFramework.ActionTypeOnChannelIsBusy action)
        {
            this.string_0 = "";
            this.int_0 = 0;
            this.string_1 = null;
            this.actionTypeOnChannelIsBusy_0 = CJFramework.ActionTypeOnChannelIsBusy.Continue;
            this.string_0 = _groupID;
            this.byte_0 = info;
            this.int_0 = infoType;
            this.string_1 = _tag;
            this.actionTypeOnChannelIsBusy_0 = action;
        }

        public CJFramework.ActionTypeOnChannelIsBusy ActionTypeOnChannelIsBusy
        {
            get
            {
                return this.actionTypeOnChannelIsBusy_0;
            }
            set
            {
                this.actionTypeOnChannelIsBusy_0 = value;
            }
        }

        public byte[] Content
        {
            get
            {
                return this.byte_0;
            }
            set
            {
                this.byte_0 = value;
            }
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

        public int InformationType
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
            }
        }

        public string Tag
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

