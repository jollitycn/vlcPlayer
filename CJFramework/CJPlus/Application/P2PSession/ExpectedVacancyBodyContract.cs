namespace CJPlus.Application.P2PSession
{
    using System;

    public class ExpectedVacancyBodyContract
    {
        private byte[] byte_0;

        public ExpectedVacancyBodyContract()
        {
        }

        public ExpectedVacancyBodyContract(byte[] _buff)
        {
            this.byte_0 = _buff;
        }

        public byte[] Buff
        {
            get
            {
                return this.byte_0;
            }
            set
            {
                this.byte_0 = value;
            }
        }
    }
}

