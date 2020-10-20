namespace CJBasic.Threading.Application
{
    using CJBasic;
    using System;
    using System.Threading;

    public class AsynDelayActor
    {
        private object argument;
        private int delayInMSecs = 0;
        private CbGeneric<object> handler;

        public AsynDelayActor(int delayMSecs, CbGeneric<object> action, object arg)
        {
            if (this.delayInMSecs < 0)
            {
                throw new ArgumentException("The value of delayMSecs is invalid. ");
            }
            this.handler = action;
            this.delayInMSecs = delayMSecs;
            this.argument = arg;
            new CbGeneric(this.Action).BeginInvoke(null, null);
        }

        private void Action()
        {
            Thread.Sleep(this.delayInMSecs);
            this.handler(this.argument);
        }
    }
}

