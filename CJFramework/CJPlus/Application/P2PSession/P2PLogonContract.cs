namespace CJPlus.Application.P2PSession
{
    using CJFramework.Server.UserManagement;
    using System;

    public class P2PLogonContract
    {
        private bool bool_0;
        private P2PAddress p2PAddress_0;

        public P2PLogonContract()
        {
            this.bool_0 = false;
        }

        public P2PLogonContract(P2PAddress addr, bool isPublic)
        {
            this.bool_0 = false;
            this.p2PAddress_0 = addr;
            this.bool_0 = isPublic;
        }

        public bool IsPublicIP
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        public P2PAddress P2PAddress_0
        {
            get
            {
                return this.p2PAddress_0;
            }
            set
            {
                this.p2PAddress_0 = value;
            }
        }
    }
}

