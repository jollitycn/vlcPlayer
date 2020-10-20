using JGNet.Core.AiDeployer;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.Dev.BLInterface.Web
{
    public interface IBLService4AiDeployer
    {
        RegisterResult RegisterAiDeployer(AiDeployerInfo aiDeployerInfo);

        UnRegisterResult UnRegisterAiDeployer(string ip);

        void KeepHeartbeat(AiDeployerInfo aiDeployerInfo);

        BusinessAccount GetBusinessAccount(string id);
    }
}
