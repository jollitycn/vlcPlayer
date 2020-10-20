using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.Dev.InteractEntity
{
    [Serializable]
    public class LoadServerInfo
    {
        public string BusinessAccountId { get; set; }

        public string ServerIP { get; set; }

        public int ServerRemotingPort { get; set; }
    }
}
