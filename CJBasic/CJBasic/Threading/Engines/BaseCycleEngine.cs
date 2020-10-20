namespace CJBasic.Threading.Engines
{
    using CJBasic;
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public abstract class BaseCycleEngine : ICycleEngine
    {
        private int detectSpan = 0;
        private volatile bool isStop = true;
        private ManualResetEvent manualResetEvent4Stop = new ManualResetEvent(false);
        private const int SleepTime = 10;
        private int totalSleepCount = 0;

        public event CbGeneric<Exception> EngineStopped;

        public BaseCycleEngine()
        {
            this.EngineStopped += delegate {
            };
        }

        protected abstract bool DoDetect();
        public virtual void Start()
        {
            this.totalSleepCount = this.detectSpan / 10;
            if ((this.detectSpan >= 0) && this.isStop)
            {
                this.manualResetEvent4Stop.Reset();
                this.isStop = false;
                new CbSimple(this.Worker).BeginInvoke(null, null);
            }
        }

        public virtual void Stop()
        {
            if (!this.isStop)
            {
                this.isStop = true;
                this.manualResetEvent4Stop.WaitOne();
                this.manualResetEvent4Stop.Reset();
            }
        }

        public void StopAsyn()
        {
            new CbGeneric(this.Stop).BeginInvoke(null, null);
        }

        protected virtual void Worker()
        {
            Exception exception = null;
            try
            {
                while (!this.isStop)
                {
                    for (int i = 0; i < this.totalSleepCount; i++)
                    {
                        if (this.isStop)
                        {
                            break;
                        }
                        Thread.Sleep(10);
                    }
                    if (!this.DoDetect())
                    {
                        return;
                    }
                }
            }
            catch (Exception exception2)
            {
                exception = exception2;
                throw;
            }
            finally
            {
                this.isStop = true;
                this.manualResetEvent4Stop.Set();
                this.EngineStopped(exception);
            }
        }

        public int DetectSpan
        {
            get
            {
                return this.detectSpan;
            }
            set
            {
                this.detectSpan = value;
            }
        }

        public virtual int DetectSpanInSecs
        {
            get
            {
                return (this.detectSpan / 0x3e8);
            }
            set
            {
                this.detectSpan = value * 0x3e8;
            }
        }

        public bool IsRunning
        {
            get
            {
                return !this.isStop;
            }
        }
    }
}

