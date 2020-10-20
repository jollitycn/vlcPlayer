namespace CJPlus.Application.Basic
{
    using System;

    public class ResOnlineContract
    {
        private bool bool_0;

        public ResOnlineContract()
        {
            this.bool_0 = false;
        }

        public ResOnlineContract(bool _online)
        {
            this.bool_0 = false;
            this.bool_0 = _online;
        }

        public bool Online
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
    }
}

