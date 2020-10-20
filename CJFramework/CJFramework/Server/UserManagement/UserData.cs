namespace CJFramework.Server.UserManagement
{
    using CJBasic;
    using CJFramework;
    using System;
    using System.Net;

    [Serializable]
    public class UserData
    {
        private P2PAddress ajhuhXlNao;
        private CJFramework.ClientType clientType_0;
        private DateTime dateTime_0;
        private string eQnuykyZbg;
        private IPEndPoint ipendPoint_0;
        private object object_0;
        [NonSerialized]
        private object object_1;
        private string string_0;

        [field: NonSerialized]
        internal event CbGeneric<UserData> Event_0;

        public UserData()
        {
            this.eQnuykyZbg = "";
            this.string_0 = "";
            this.ajhuhXlNao = null;
            this.dateTime_0 = DateTime.Now;
            this.clientType_0 = CJFramework.ClientType.DotNET;
            this.object_0 = null;
            this.object_1 = null;
        }

        public UserData(string _userID, IPEndPoint _address, string serverID, CJFramework.ClientType _clientType, DateTime logon)
        {
            this.eQnuykyZbg = "";
            this.string_0 = "";
            this.ajhuhXlNao = null;
            this.dateTime_0 = DateTime.Now;
            this.clientType_0 = CJFramework.ClientType.DotNET;
            this.object_0 = null;
            this.object_1 = null;
            this.string_0 = _userID;
            this.ipendPoint_0 = _address;
            this.eQnuykyZbg = serverID;
            this.clientType_0 = _clientType;
            this.dateTime_0 = logon;
        }

        internal void method_0(object object_2)
        {
            this.object_0 = object_2;
        }

        public void SetP2PAddress(P2PAddress addr)
        {
            this.ajhuhXlNao = addr;
        }

        public override string ToString()
        {
            return this.string_0;
        }

        public IPEndPoint Address
        {
            get
            {
                return this.ipendPoint_0;
            }
            set
            {
                this.ipendPoint_0 = value;
            }
        }

        public string AppServerID
        {
            get
            {
                return this.eQnuykyZbg;
            }
            set
            {
                this.eQnuykyZbg = value;
            }
        }

        public CJFramework.ClientType ClientType
        {
            get
            {
                return this.clientType_0;
            }
            set
            {
                this.clientType_0 = value;
            }
        }

        public object LocalTag
        {
            get
            {
                return this.object_1;
            }
            set
            {
                this.object_1 = value;
            }
        }

        public P2PAddress P2PAddress_0
        {
            get
            {
                return this.ajhuhXlNao;
            }
            internal set
            {
                this.ajhuhXlNao = value;
            }
        }

        public object Tag
        {
            get
            {
                return this.object_0;
            }
            set
            {
                this.object_0 = value;
                if (this.Event_0 != null)
                {
                    this.Event_0(this);
                }
            }
        }

        public DateTime TimeLogon
        {
            get
            {
                return this.dateTime_0;
            }
            set
            {
                this.dateTime_0 = value;
            }
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

