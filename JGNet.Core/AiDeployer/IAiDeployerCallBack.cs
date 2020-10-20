using System;
using System.Collections.Generic;

using System.Text;
using JGNet.Core.InteractEntity;

namespace JGNet.Core.AiDeployer
{
    public interface IAiDeployerCallBack
    {
        InteractResult StartDeploy(BusinessAccount businessAccount);

        InteractResult DeleteBusinessAccount(BusinessAccount businessAccount);
    }
}
