namespace CJPlus.Advanced
{
    using System;

    public class AdvancedOptions : BaseOptions
    {
        private bool bool_2 = true;
        private bool bool_3 = true;

        public AdvancedOptions()
        {
            base.WriteTimeoutInSecs = 60;
        }

        public bool AsynMessageQueueEnabled
        {
            get
            {
                return this.bool_3;
            }
            set
            {
                this.bool_3 = value;
            }
        }

        public bool Boolean_0
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                this.bool_2 = value;
            }
        }
    }
}

