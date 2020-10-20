using JGNet.Core.BLInterface;
using JGNet.Core.Dev.BLInterface.MainForm;
using JGNet.Core.Dev.BLInterface.Server;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.Dev.BLInterface
{
    public interface IRemotingHandler
    {
        IRemoting4GuideWeb Remoting4GuideWeb { get; }

        IRemoting4BossWeb Remoting4BossWeb { get; }

        IRemoting4SimpleWeb Remoting4SimpleWeb { get; }

        IRemoting4DataImporter Remoting4DataImporter { get; }

        IRemoting4ShopWeb Remoting4ShopWeb { get; }

        IRemoting4WxPayWeb Remoting4WxPayWeb { get;  }
    }
}
