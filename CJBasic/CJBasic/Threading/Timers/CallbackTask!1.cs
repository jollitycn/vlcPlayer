namespace CJBasic.Threading.Timers
{
    using CJBasic;
    using System;

    public class CallbackTask<T>
    {
        private CbGeneric<T> callback;
        private T callbackPara;
        private int iD;
        private int leftSeconds;

        public CallbackTask()
        {
            this.iD = 0;
            this.leftSeconds = 10;
        }

        public CallbackTask(int _id, int iniSecs, CbGeneric<T> _callback, T _callbackPara)
        {
            this.iD = 0;
            this.leftSeconds = 10;
            this.iD = _id;
            this.leftSeconds = iniSecs;
            this.callbackPara = _callbackPara;
            this.callback = _callback;
            if (this.leftSeconds <= 0)
            {
                throw new ArgumentException("The Left Seconds must greater than 0!");
            }
        }

        public bool SecondsPassed(int seconds)
        {
            this.leftSeconds -= seconds;
            return (this.leftSeconds <= 0);
        }

        public CbGeneric<T> Callback
        {
            get
            {
                return this.callback;
            }
            set
            {
                this.callback = value;
            }
        }

        public T CallbackPara
        {
            get
            {
                return this.callbackPara;
            }
            set
            {
                this.callbackPara = value;
            }
        }

        public int ID
        {
            get
            {
                return this.iD;
            }
            set
            {
                this.iD = value;
            }
        }

        public int LeftSeconds
        {
            get
            {
                return this.leftSeconds;
            }
            set
            {
                this.leftSeconds = value;
            }
        }
    }
}

