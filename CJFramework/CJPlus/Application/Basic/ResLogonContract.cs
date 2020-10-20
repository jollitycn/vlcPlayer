namespace CJPlus.Application.Basic
{
    using System;

    public class ResLogonContract : LogonFullResponse
    {
        public ResLogonContract()
        {
        }

        public ResLogonContract(LogonResult result, string failureCause, bool P2P, bool group, bool useAsP2PServer) : base(result, failureCause, P2P, group, useAsP2PServer)
        {
        }
    }
}

