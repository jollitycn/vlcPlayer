namespace CJPlus.Application.Basic
{
    using System;

    public class LogonFullResponse : LogonResponse
    {
        private bool aroLejaQpM;
        private bool bool_0;
        private bool bool_1;

        public LogonFullResponse()
        {
            this.bool_0 = true;
            this.aroLejaQpM = true;
            this.bool_1 = true;
        }

        public LogonFullResponse(LogonResult result, string _failureCause, bool _P2P, bool _groupRelationEnabled, bool _useAsP2PServer)
        {
            this.bool_0 = true;
            this.aroLejaQpM = true;
            this.bool_1 = true;
            base.logonResult = result;
            base.failureCause = _failureCause;
            this.bool_0 = _P2P;
            this.bool_1 = _groupRelationEnabled;
            this.aroLejaQpM = _useAsP2PServer;
        }

        public bool Boolean_0
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        public bool GroupRelationEnabled
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                this.bool_1 = value;
            }
        }

        public bool UseAsP2PServer
        {
            get
            {
                return this.aroLejaQpM;
            }
            set
            {
                this.aroLejaQpM = value;
            }
        }
    }
}

