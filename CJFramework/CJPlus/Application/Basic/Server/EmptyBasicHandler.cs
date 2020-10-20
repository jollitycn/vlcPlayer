namespace CJPlus.Application.Basic.Server
{
    using System;
    using System.Runtime.InteropServices;

    public class EmptyBasicHandler : IBasicHandler
    {
        public bool VerifyUser(string systemToken, string userID, string password, out string failureCause)
        {
            failureCause = null;
            return true;
        }
    }
}

