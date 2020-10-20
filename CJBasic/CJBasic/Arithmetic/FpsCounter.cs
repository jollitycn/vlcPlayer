namespace CJBasic.Arithmetic
{
    using CJBasic;
    using CJBasic.Threading.Engines;
    using System;
    using System.Threading;

    public class FpsCounter : BaseCycleEngine, IDisposable
    {
        private int count = 0;
        private double fps = 0.0;
        private object locker = new object();
        private ulong totalCount = 0L;

        public event CbGeneric<double> FpsDetected;

        public FpsCounter(int detectSpanInSecs)
        {
            base.DetectSpanInSecs = detectSpanInSecs;
            base.Start();
        }

        public void AddFrame()
        {
            lock (this.locker)
            {
                this.count++;
                this.totalCount += (ulong) 1L;
            }
        }

        public void Dispose()
        {
            base.Stop();
        }

        protected override bool DoDetect()
        {
            lock (this.locker)
            {
                this.fps = ((double) this.count) / ((double) base.DetectSpanInSecs);
                this.count = 0;
                if (this.FpsDetected != null)
                {
                    this.FpsDetected(this.fps);
                }
            }
            return true;
        }

        public double Fps
        {
            get
            {
                return this.fps;
            }
        }

        public ulong TotalCount
        {
            get
            {
                return this.totalCount;
            }
        }
    }
}

