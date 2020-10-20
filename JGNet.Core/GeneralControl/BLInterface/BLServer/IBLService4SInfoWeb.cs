using System;
using System.Collections.Generic;

using System.Text;
using JGNet.Core.RemotingEntity;

namespace JGNet.Core.Dev.BLInterface.Web
{
    public interface IBLService4SInfoWeb
    {
        BusinessAccount GetBusinessAccount(string id);

        AutoUpgradeInfo GetAutoUpgradeInfo(int isManager);
    }
}
