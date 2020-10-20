namespace CJBasic.Threading.Timers
{
    using CJBasic;
    using CJBasic.Collections;
    using CJBasic.Threading.Engines;
    using System;
    using System.Collections.Generic;

    public class CallbackTimer<T> : BaseCycleEngine, ICallbackTimer<T>, ICycleEngine
    {
        private IDictionary<int, CallbackTask<T>> dicTask;
        private int idCount;
        private object locker;

        public CallbackTimer()
        {
            this.dicTask = new Dictionary<int, CallbackTask<T>>();
            this.locker = new object();
            this.idCount = 0;
            this.DetectSpanInSecs = 1;
        }

        public int AddCallback(int spanInSecs, CbGeneric<T> _callback, T _callbackPara)
        {
            lock (this.locker)
            {
                this.idCount++;
                this.dicTask.Add(this.idCount, new CallbackTask<T>(this.idCount, spanInSecs, _callback, _callbackPara));
                return this.idCount;
            }
        }

        public void Clear()
        {
            lock (this.locker)
            {
                this.dicTask.Clear();
            }
        }

        protected override bool DoDetect()
        {
            IList<CallbackTask<T>> list = null;
            lock (this.locker)
            {
                list = CollectionConverter.CopyAllToList<CallbackTask<T>>(this.dicTask.Values);
            }
            foreach (CallbackTask<T> task in list)
            {
                if (task.SecondsPassed(this.DetectSpanInSecs))
                {
                    this.RemoveCallback(task.ID);
                    task.Callback.BeginInvoke(task.CallbackPara, null, null);
                }
            }
            return true;
        }

        public int GetLeftSeconds(int taskID)
        {
            lock (this.locker)
            {
                if (!this.dicTask.ContainsKey(taskID))
                {
                    return 0;
                }
                return this.dicTask[taskID].LeftSeconds;
            }
        }

        public void RemoveCallback(int taskID)
        {
            lock (this.locker)
            {
                if (this.dicTask.ContainsKey(taskID))
                {
                    this.dicTask.Remove(taskID);
                }
            }
        }

        public int RemoveCallbackAndAddNew(int taskIDToRemoved, int spanInSecs, CbGeneric<T> _newCallback, T _newCallbackPara)
        {
            this.RemoveCallback(taskIDToRemoved);
            return this.AddCallback(spanInSecs, _newCallback, _newCallbackPara);
        }

        public override int DetectSpanInSecs
        {
            get
            {
                return base.DetectSpanInSecs;
            }
            set
            {
                if (value < 1)
                {
                    throw new Exception("DetectSpanInSecs must greater than 0");
                }
                base.DetectSpanInSecs = value;
            }
        }

        public int TaskCount
        {
            get
            {
                return this.dicTask.Count;
            }
        }
    }
}

