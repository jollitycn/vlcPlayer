namespace CJPlus.Application.P2PSession
{
    using CJFramework;
    using System;

    public class ReceiveP2PProbeNotifyContract
    {
        private AgileIPE agileIPE_0;
        private AgileIPE agileIPE_1;

        public ReceiveP2PProbeNotifyContract()
        {
        }

        public ReceiveP2PProbeNotifyContract(AgileIPE source, AgileIPE end)
        {
            this.agileIPE_0 = source;
            this.agileIPE_1 = end;
        }

        public AgileIPE EndingIPEndPoint
        {
            get
            {
                return this.agileIPE_1;
            }
            set
            {
                this.agileIPE_1 = value;
            }
        }

        public AgileIPE SourceIPEndPoint
        {
            get
            {
                return this.agileIPE_0;
            }
            set
            {
                this.agileIPE_0 = value;
            }
        }
    }
}

