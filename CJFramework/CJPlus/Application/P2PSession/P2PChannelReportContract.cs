namespace CJPlus.Application.P2PSession
{
    using System;

    public class P2PChannelReportContract
    {
        private string string_0;

        public P2PChannelReportContract()
        {
        }

        public P2PChannelReportContract(string dest)
        {
            this.string_0 = dest;
        }

        public string DestUserID
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
            }
        }
    }
}

