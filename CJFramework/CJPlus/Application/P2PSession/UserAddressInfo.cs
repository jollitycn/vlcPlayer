namespace CJPlus.Application.P2PSession
{
    using CJFramework.Server.UserManagement;
    using System;

    [Serializable]
    public class UserAddressInfo
    {
        private P2PAddress p2PAddress_0 = null;
        private string string_0;

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

