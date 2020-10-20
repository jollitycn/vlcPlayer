namespace CJBasic.ObjectManagement
{
    using CJBasic.Threading.Engines;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public abstract class BeforehandCreator<T> : IEngineActor, ICreator<T>, IDisposable
    {
        private int beforehandCount;
        private int detectSpanInSecs;
        private AgileCycleEngine engine;
        private object locker4Create;
        private Queue<T> queue;

        protected BeforehandCreator()
        {
            this.queue = new Queue<T>();
            this.beforehandCount = 10;
            this.detectSpanInSecs = 1;
            this.locker4Create = new object();
        }

        public T Create()
        {
            T local;
            lock (this.locker4Create)
            {
                while (this.queue.Count == 0)
                {
                    Thread.Sleep(10);
                }
                lock (this.queue)
                {
                    local = this.queue.Dequeue();
                }
            }
            return local;
        }

        public void Dispose()
        {
            if (this.engine != null)
            {
                this.engine.Stop();
            }
        }

        protected abstract T DoCreate();
        public bool EngineAction()
        {
            while (this.queue.Count < this.beforehandCount)
            {
                try
                {
                    T item = this.DoCreate();
                    lock (this.queue)
                    {
                        this.queue.Enqueue(item);
                    }
                }
                catch (Exception)
                {
                    Thread.Sleep(10);
                }
            }
            return true;
        }

        public void Initialize()
        {
            this.engine = new AgileCycleEngine(this);
            this.engine.DetectSpanInSecs = this.detectSpanInSecs;
            this.engine.Start();
        }

        public int BeforehandCount
        {
            get
            {
                return this.beforehandCount;
            }
            set
            {
                this.beforehandCount = value;
            }
        }

        public int DetectSpanInSecs
        {
            get
            {
                return this.detectSpanInSecs;
            }
            set
            {
                this.detectSpanInSecs = value;
            }
        }
    }
}

