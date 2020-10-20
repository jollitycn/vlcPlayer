namespace CJPlus.Application.Basic
{
    using System;

    public class LogonResponse
    {
        protected string failureCause;
        protected CJPlus.Application.Basic.LogonResult logonResult;

        public LogonResponse()
        {
            this.logonResult = CJPlus.Application.Basic.LogonResult.Succeed;
            this.failureCause = null;
        }

        public LogonResponse(CJPlus.Application.Basic.LogonResult result, string _failureCause)
        {
            this.logonResult = CJPlus.Application.Basic.LogonResult.Succeed;
            this.failureCause = null;
            this.logonResult = result;
            this.failureCause = _failureCause;
        }

        public string FailureCause
        {
            get
            {
                return this.failureCause;
            }
            set
            {
                this.failureCause = value;
            }
        }

        public CJPlus.Application.Basic.LogonResult LogonResult
        {
            get
            {
                return this.logonResult;
            }
            set
            {
                this.logonResult = value;
            }
        }
    }
}

