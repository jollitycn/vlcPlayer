namespace CJPlus.Application.Basic.Server
{
    using System;
    using System.Runtime.InteropServices;

    public interface IBasicHandler
    {
        bool VerifyUser(string systemToken, string userID, string password, out string failureCause);
    }
}

