using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.RemotingEntity
{
    [Serializable]
    public class AutoUpgradeInfo
    {
        public string IP { get; set; }

        public int Port { get; set; }
    }
}
