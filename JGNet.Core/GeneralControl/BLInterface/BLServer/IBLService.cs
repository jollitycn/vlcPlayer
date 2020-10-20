using JGNet.Core.Dev.BLInterface;
using JGNet.Core.Dev.BLInterface.BLServer;
using JGNet.Core.Dev.BLInterface.Web;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.BLInterface
{
    public interface IBLService
    {
        IBLService4AppWeb BLService4AppWeb { get; }

        IBLService4Control BLService4Control { get; }

        IBLService4SInfoWeb BLService4SInfoWeb { get; }

        IBLService4AiDeployer BLService4AiDeployer { get; }

        IBLService4Server BLService4Server { get; }

        IBLService4ShopWeb BLService4ShopWeb { get; }

        IBLService4WxPayWeb BLService4WxPayWeb { get; }
    }
}
