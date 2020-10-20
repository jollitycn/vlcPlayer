namespace CJBasic.Threading.Engines
{
    using CJBasic;
    using System;
    using System.Collections.Generic;

    public interface IWorkerEngine<T>
    {
        event CbGeneric<T, Exception> ExceptionOccured;

        void AddWork(T work);
        List<T> GetWaittingWorks();
        void Initialize();
        void Start();
        void Stop();

        int IdleSpanInMSecs { get; set; }

        int IdleThreadCount { get; }

        int MaxWaitWorkCount { get; }

        int WorkCount { get; }

        int WorkerThreadCount { get; set; }

        IWorkProcesser<T> WorkProcesser { set; }
    }
}

