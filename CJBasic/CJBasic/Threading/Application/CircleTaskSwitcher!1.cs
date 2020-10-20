namespace CJBasic.Threading.Application
{
    using CJBasic;
    using CJBasic.ObjectManagement;
    using CJBasic.Threading.Engines;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class CircleTaskSwitcher<TaskType> : ICircleTaskSwitcher<TaskType>, IEngineActor
    {
        private AgileCycleEngine agileCycleEngine;
        private IDictionary<ShortTime, TaskType> taskDictionary;
        private Circle<ShortTime> taskTimeCircle;

        public event CbGeneric<TaskType> TaskSwitched;

        public CircleTaskSwitcher()
        {
            this.taskTimeCircle = new Circle<ShortTime>();
            this.taskDictionary = new Dictionary<ShortTime, TaskType>();
            this.TaskSwitched += delegate {
            };
        }

        public bool EngineAction()
        {
            if (this.taskTimeCircle.PeekNext().IsOnTime(DateTime.Now, this.agileCycleEngine.DetectSpanInSecs))
            {
                this.taskTimeCircle.MoveNext();
                this.TaskSwitched(this.CurrentTask);
            }
            return true;
        }

        public void Initialize()
        {
            if (this.taskDictionary.Count < 2)
            {
                throw new Exception("Count of StartHour must >= 2 !");
            }
            List<ShortTime> list = new List<ShortTime>();
            foreach (ShortTime time in this.taskDictionary.Keys)
            {
                list.Add(time);
            }
            list.Sort();
            this.taskTimeCircle = new Circle<ShortTime>(list);
            ShortTime time2 = new ShortTime(DateTime.Now);
            if ((time2.CompareTo(this.taskTimeCircle.Tail) >= 0) || (time2.CompareTo(this.taskTimeCircle.Header) < 0))
            {
                this.taskTimeCircle.SetCurrent(this.taskTimeCircle.Tail);
            }
            else
            {
                this.taskTimeCircle.SetCurrent(this.taskTimeCircle.Header);
                while (time2.CompareTo(this.taskTimeCircle.PeekNext()) >= 0)
                {
                    this.taskTimeCircle.MoveNext();
                }
            }
            this.agileCycleEngine = new AgileCycleEngine(this);
            this.agileCycleEngine.DetectSpanInSecs = 1;
            this.agileCycleEngine.Start();
        }

        public TaskType CurrentTask
        {
            get
            {
                return this.taskDictionary[this.taskTimeCircle.Current];
            }
        }

        public IDictionary<ShortTime, TaskType> TaskDictionary
        {
            get
            {
                return this.taskDictionary;
            }
            set
            {
                this.taskDictionary = value;
            }
        }
    }
}

