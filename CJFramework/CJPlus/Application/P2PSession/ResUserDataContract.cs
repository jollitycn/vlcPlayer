namespace CJPlus.Application.P2PSession
{
    using CJFramework.Server.UserManagement;
    using System;

    public class ResUserDataContract : UserAddressInfo
    {
        public ResUserDataContract()
        {
        }

        public ResUserDataContract(string userID, P2PAddress addr)
        {
            base.UserID = userID;
            base.P2PAddress_0 = addr;
        }
    }
}

