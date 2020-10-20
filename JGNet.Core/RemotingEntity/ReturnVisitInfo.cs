using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.RemotingEntity
{
    [Serializable]
    public class ReturnVisitInfo
    {
        public int RetailCount { get; set; }

        public int BirthdayCount { get; set; }

        public int VipCount { get; set; }
    }
}
