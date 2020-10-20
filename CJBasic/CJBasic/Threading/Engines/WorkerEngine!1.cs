namespace CJBasic.Threading.Engines
{
    using CJBasic;
    using CJBasic.ObjectManagement;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class WorkerEngine<T> : IEngineActor, IWorkerEngine<T>
    {
        private AgileCycleEngine[] agileCycleEngines;
        private int busyThreadCount;
        private int idleSpanInMSecs;
        private CircleQueue<T> queueOfWork;
        private int workerThreadCount;
        protected IWorkProcesser<T> workProcesser;

        public event CbGeneric<T, Exception> ExceptionOccured;

        public WorkerEngine()
        {
            this.workerThreadCount = 1;
            this.idleSpanInMSecs = 10;
            this.busyThreadCount = 0;
        }

        public void AddWork(T work)
        {
            this.queueOfWork.Enqueue(work);
        }

        private void DoWork()
        {
            T local = default(T);
            if (this.queueOfWork.Dequeue(out local))
            {
                Interlocked.Increment(ref this.busyThreadCount);
                try
                {
                    this.workProcesser.Process(local);
                }
                catch (Exception exception)
                {
                    if (this.ExceptionOccured != null)
                    {
                        this.ExceptionOccured.BeginInvoke(local, exception, null, null);
                    }
                }
                Interlocked.Decrement(ref this.busyThreadCount);
            }
            else
            {
                Thread.Sleep(this.idleSpanInMSecs);
            }
        }

        public bool EngineAction()
        {
            this.DoWork();
            return true;
        }

        public List<T> GetWaittingWorks()
        {
            return this.queueOfWork.GetAll();
        }

        public void Initialize()
        {
            this.Initialize(0x2710);
        }

        public void Initialize(int capacity)
        {
            this.queueOfWork = new CircleQueue<T>(capacity);
            this.agileCycleEngines = new AgileCycleEngine[this.workerThreadCount];
            for (int i = 0; i < this.agileCycleEngines.Length; i++)
            {
                this.agileCycleEngines[i] = new AgileCycleEngine(this);
                this.agileCycleEngines[i].DetectSpanInSecs = 0;
            }
        }

        public void Start()
        {
            foreach (AgileCycleEngine engine in this.agileCycleEngines)
            {
                engine.Start();
            }
        }

        public void Stop()
        {
            foreach (AgileCycleEngine engine in this.agileCycleEngines)
            {
                engine.Stop();
            }
        }

        public int IdleSpanInMSecs
        {
            get
            {
                return this.idleSpanInMSecs;
            }
            set
            {
                this.idleSpanInMSecs = value;
            }
        }

        public int IdleThreadCount
        {
            get
            {
                return (this.workerThreadCount - this.busyThreadCount);
            }
        }

        public int MaxWaitWorkCount
        {
            get
            {
                if (this.queueOfWork == null)
                {
                    return 0;
                }
                return this.queueOfWork.MaxCount;
            }
        }

        public int WorkCount
        {
            get
            {
                return this.queueOfWork.Count;
            }
        }

        public int WorkerThreadCount
        {
            get
            {
                return this.workerThreadCount;
            }
            set
            {
                if (this.workerThreadCount < 1)
                {
                    throw new Exception("The number of worker must be > 0 !");
                }
                this.workerThreadCount = value;
            }
        }

        public IWorkProcesser<T> WorkProcesser
        {
            set
            {
                this.workProcesser = value;
            }
        }
    }
}

