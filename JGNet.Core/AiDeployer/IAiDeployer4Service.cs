using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.AiDeployer
{
    public interface IAiDeployer4Service
    {
        BusinessAccount GetBusinessAccount(string id);

        RegisterResult RegisterService(string id);

        RegisterResult UnRegisterService(string id);

        void KeepHeartbeat(string id);

        string GetBLServiceUrl();
    }
}
