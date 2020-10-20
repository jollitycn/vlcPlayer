namespace CJBasic.Threading.Engines
{
    using CJBasic.Collections;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public sealed class BriefWorkerEngine<T> : IEngineActor, IDisposable
    {
        private AgileCycleEngine[] agileCycleEngines;
        private int currentWorkIndex;
        private object locker;
        private IList<T> workList;
        private IWorkProcesser<T> workProcesser;

        public BriefWorkerEngine(IWorkProcesser<T> processer, int workerCount, IEnumerable<T> works)
        {
            this.currentWorkIndex = -1;
            this.locker = new object();
            if (((processer == null) || (workerCount <= 0)) || (works == null))
            {
                throw new Exception("Parameter not valid !");
            }
            this.workProcesser = processer;
            this.workList = CollectionConverter.CopyAllToList<T>(works);
            this.agileCycleEngines = new AgileCycleEngine[workerCount];
            for (int i = 0; i < this.agileCycleEngines.Length; i++)
            {
                this.agileCycleEngines[i] = new AgileCycleEngine(this);
                this.agileCycleEngines[i].DetectSpanInSecs = 0;
            }
        }

        public void Dispose()
        {
            foreach (AgileCycleEngine engine in this.agileCycleEngines)
            {
                engine.Stop();
            }
        }

        public bool EngineAction()
        {
            T work = default(T);
            if (!this.GetNextWork(out work))
            {
                return false;
            }
            this.workProcesser.Process(work);
            return true;
        }

        private bool GetNextWork(out T work)
        {
            work = default(T);
            lock (this.locker)
            {
                if (this.currentWorkIndex >= (this.workList.Count - 1))
                {
                    return false;
                }
                this.currentWorkIndex++;
                work = this.workList[this.currentWorkIndex];
                return true;
            }
        }

        public bool IsFinished()
        {
            foreach (AgileCycleEngine engine in this.agileCycleEngines)
            {
                if (engine.IsRunning)
                {
                    return false;
                }
            }
            return true;
        }

        public void Start()
        {
            foreach (AgileCycleEngine engine in this.agileCycleEngines)
            {
                engine.Start();
            }
        }
    }
}

