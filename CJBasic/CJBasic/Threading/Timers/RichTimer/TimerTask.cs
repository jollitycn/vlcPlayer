namespace CJBasic.Threading.Timers.RichTimer
{
    using System;

    public class TimerTask
    {
        private CbRichTimer callBackHandler = null;
        private bool enabled = true;
        private string name;
        private object tag;
        private TimerConfiguration timerConfiguration;

        public TimerTask(string timerName, CbRichTimer handler, TimerConfiguration config, object theTag)
        {
            this.callBackHandler = handler;
            this.timerConfiguration = config;
            this.name = timerName;
            this.tag = theTag;
        }

        public void HaveATry(int spanSecs, DateTime now)
        {
            if ((this.enabled && (this.callBackHandler != null)) && this.timerConfiguration.IsOnTime(spanSecs, now))
            {
                this.callBackHandler.BeginInvoke(this.name, now, this.tag, null, null);
            }
        }

        public bool IsExpired(DateTime now)
        {
            return this.timerConfiguration.IsExpired(now);
        }

        public bool Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public object Tag
        {
            get
            {
                return this.tag;
            }
            set
            {
                this.tag = value;
            }
        }
    }
}

