namespace CJBasic.Threading.Engines
{
    using CJBasic;
    using CJBasic.Helpers;
    using CJBasic.ObjectManagement;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class RetryEngine<TTask> : IDisposable
    {
        private Func<TTask, bool> action;
        private bool disposed;
        private EventSafeTrigger eventSafeTrigger;
        private int retryingCount;
        private SafeList<TaskBag<TTask>> retryList;
        private SafeQueue<TaskBag<TTask>> taskQueue;

        public event CbGeneric<TTask, Exception> TaskFailed;

        public event CbGeneric<TTask, DateTime, int> TaskSucceed;

        public RetryEngine()
        {
            this.disposed = false;
            this.taskQueue = new SafeQueue<TaskBag<TTask>>();
            this.retryList = new SafeList<TaskBag<TTask>>();
            this.eventSafeTrigger = new EventSafeTrigger();
            this.retryingCount = 0;
        }

        public void AddTask(TTask task, int spanInSecsIfRetry)
        {
            this.taskQueue.Enqueue(new TaskBag<TTask>(task, spanInSecsIfRetry));
        }

        public void Dispose()
        {
            this.disposed = true;
            this.taskQueue.Clear();
            this.retryList.Clear();
        }

        public void Initialize(Func<TTask, bool> targetAction)
        {
            this.action = targetAction;
            this.disposed = false;
            new CbGeneric(this.TaskWorker).BeginInvoke(null, null);
            new CbGeneric(this.RetryWorker).BeginInvoke(null, null);
        }

        private void RetryCallback(IAsyncResult ar)
        {
            Interlocked.Decrement(ref this.retryingCount);
            TaskBag<TTask> asyncState = (TaskBag<TTask>) ar.AsyncState;
            bool flag = false;
            Exception exception = null;
            try
            {
                flag = this.action.EndInvoke(ar);
            }
            catch (Exception exception2)
            {
                exception = exception2;
            }
            if (flag)
            {
                this.eventSafeTrigger.Action<TTask, DateTime, int>("TaskSucceed", this.TaskSucceed, asyncState.Task, asyncState.AddedTime, 0);
            }
            else
            {
                asyncState.LastActionTime = DateTime.Now;
                this.retryList.Add(asyncState);
                this.eventSafeTrigger.Action<TTask, Exception>("TaskFailed", this.TaskFailed, asyncState.Task, exception);
            }
        }

        protected virtual void RetryWorker()
        {
            while (!this.disposed)
            {
                if (this.retryList.Count == 0)
                {
                    Thread.Sleep(0x3e8);
                }
                else
                {
                    List<TaskBag<TTask>> list = new List<TaskBag<TTask>>();
                    List<TaskBag<TTask>> all = this.retryList.GetAll();
                    for (int i = 0; i < all.Count; i++)
                    {
                        TaskBag<TTask> item = all[i];
                        TimeSpan span = (TimeSpan) (DateTime.Now - item.LastActionTime);
                        if (span.TotalSeconds >= item.SpanInSecsIfRetry)
                        {
                            list.Add(item);
                        }
                    }
                    foreach (TaskBag<TTask> bag in list)
                    {
                        this.retryList.Remove(bag);
                        try
                        {
                            Interlocked.Increment(ref this.retryingCount);
                            bag.RetryCount++;
                            this.action.BeginInvoke(bag.Task, new AsyncCallback(this.RetryCallback), bag);
                        }
                        catch (Exception exception)
                        {
                            Interlocked.Decrement(ref this.retryingCount);
                            bag.LastActionTime = DateTime.Now;
                            this.retryList.Add(bag);
                            this.eventSafeTrigger.Action<TTask, Exception>("TaskFailed", this.TaskFailed, bag.Task, exception);
                        }
                    }
                }
            }
        }

        protected virtual void TaskWorker()
        {
            while (!this.disposed)
            {
                if (this.taskQueue.Count == 0)
                {
                    Thread.Sleep(10);
                }
                else
                {
                    TaskBag<TTask> t = this.taskQueue.Dequeue();
                    bool flag = false;
                    Exception exception = null;
                    try
                    {
                        flag = this.action(t.Task);
                    }
                    catch (Exception exception2)
                    {
                        exception = exception2;
                    }
                    if (flag)
                    {
                        this.eventSafeTrigger.Action<TTask, DateTime, int>("TaskSucceed", this.TaskSucceed, t.Task, t.AddedTime, 0);
                    }
                    else
                    {
                        t.LastActionTime = DateTime.Now;
                        this.retryList.Add(t);
                        this.eventSafeTrigger.Action<TTask, Exception>("TaskFailed", this.TaskFailed, t.Task, exception);
                    }
                }
            }
        }

        public int RetryingCount
        {
            get
            {
                return this.retryingCount;
            }
        }

        public int TaskToActionCount
        {
            get
            {
                return this.taskQueue.Count;
            }
        }

        public int TaskToRetryCount
        {
            get
            {
                return this.retryList.Count;
            }
        }
    }
}

