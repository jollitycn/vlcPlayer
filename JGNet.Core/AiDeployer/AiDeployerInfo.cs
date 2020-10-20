using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.AiDeployer
{
    [Serializable]
    public class AiDeployerInfo
    {
        public string IP { get; set; }

        private DateTime registerTime = DateTime.Now;
        public DateTime RegisterTime { get => this.registerTime; }
        
        private DateTime heartbeatTime = DateTime.Now;
        public DateTime HeartbeatTime { get => this.heartbeatTime; set => this.heartbeatTime = value; }

        public List<ServiceInfo> ServiceInfos { get; set; }

        private bool isTimeout = false;
        public bool IsTimeout { get => this.isTimeout; set => this.isTimeout = value; }

        public IAiDeployerCallBack AiDeployerCallBack { get; set; }
    }

    [Serializable]
    public class ServiceInfo
    {
        public string ServiceName { get; set; }

        private DateTime registerTime = DateTime.Now;
        public DateTime RegisterTime { get => this.registerTime; set => this.registerTime = value; }

        private DateTime heartbeatTime = DateTime.Now;
        public DateTime HeartbeatTime { get => this.heartbeatTime; set => this.heartbeatTime = value; }

        private bool isTimeout = false;
        public bool IsTimeout { get => this.isTimeout; set => this.isTimeout = value; }
    }
}
