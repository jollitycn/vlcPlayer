using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.AiDeployer
{
    [Serializable]
    public class AiDeployerRegisterInfo
    {
        public int AiDeployerHeartbeatTimeoutCount { get; set; }

        public List<AiDeployerInfo> AiDeployerInfos { get; set; }

        public int ServiceHeartbeatTimeoutCount { get; set; }

        public List<ServiceDetailInfo> ServiceDetailInfos { get; set; }
    }

    [Serializable]
    public class ServiceDetailInfo : ServiceInfo
    {
        public ServiceDetailInfo(ServiceInfo serviceInfo)
        {
            this.HeartbeatTime = serviceInfo.HeartbeatTime;
            this.IsTimeout = serviceInfo.IsTimeout;
            this.RegisterTime = serviceInfo.RegisterTime;
            this.ServiceName = serviceInfo.ServiceName;
        }

        public string AiDeployerIP { get; set; }
    }
}
