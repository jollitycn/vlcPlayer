namespace CJBasic.Helpers
{
    using CJBasic.Loggers;
    using System;

    public class EventSafeTrigger
    {
        private IAgileLogger agileLogger;
        private string publisherFullName;

        public EventSafeTrigger()
        {
            this.agileLogger = new EmptyAgileLogger();
            this.publisherFullName = "";
        }

        public EventSafeTrigger(IAgileLogger logger, string publisherTypeFullName)
        {
            this.agileLogger = new EmptyAgileLogger();
            this.publisherFullName = "";
            this.agileLogger = logger;
            this.publisherFullName = publisherTypeFullName;
        }

        public void Action(string eventName, Delegate theEvent)
        {
            string eventPath = string.Format("{0}.{1}", this.publisherFullName, eventName);
            EventHelper.SpringEventSafely(this.agileLogger, eventPath, theEvent);
        }

        public void Action<T1>(string eventName, Delegate theEvent, T1 t1)
        {
            string eventPath = string.Format("{0}.{1}", this.publisherFullName, eventName);
            EventHelper.SpringEventSafely<T1>(this.agileLogger, eventPath, theEvent, t1);
        }

        public void Action<T1, T2>(string eventName, Delegate theEvent, T1 t1, T2 t2)
        {
            string eventPath = string.Format("{0}.{1}", this.publisherFullName, eventName);
            EventHelper.SpringEventSafely<T1, T2>(this.agileLogger, eventPath, theEvent, t1, t2);
        }

        public void Action<T1, T2, T3>(string eventName, Delegate theEvent, T1 t1, T2 t2, T3 t3)
        {
            string eventPath = string.Format("{0}.{1}", this.publisherFullName, eventName);
            EventHelper.SpringEventSafely<T1, T2, T3>(this.agileLogger, eventPath, theEvent, t1, t2, t3);
        }

        public void Action<T1, T2, T3, T4>(string eventName, Delegate theEvent, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            string eventPath = string.Format("{0}.{1}", this.publisherFullName, eventName);
            EventHelper.SpringEventSafely<T1, T2, T3, T4>(this.agileLogger, eventPath, theEvent, t1, t2, t3, t4);
        }

        public void ActionAsyn(string eventName, Delegate theEvent)
        {
            string eventPath = string.Format("{0}.{1}", this.publisherFullName, eventName);
            EventHelper.SpringEventSafelyAsyn(this.agileLogger, eventPath, theEvent);
        }

        public void ActionAsyn<T1>(string eventName, Delegate theEvent, T1 t1)
        {
            string eventPath = string.Format("{0}.{1}", this.publisherFullName, eventName);
            EventHelper.SpringEventSafelyAsyn<T1>(this.agileLogger, eventPath, theEvent, t1);
        }

        public void ActionAsyn<T1, T2>(string eventName, Delegate theEvent, T1 t1, T2 t2)
        {
            string eventPath = string.Format("{0}.{1}", this.publisherFullName, eventName);
            EventHelper.SpringEventSafelyAsyn<T1, T2>(this.agileLogger, eventPath, theEvent, t1, t2);
        }

        public void ActionAsyn<T1, T2, T3>(string eventName, Delegate theEvent, T1 t1, T2 t2, T3 t3)
        {
            string eventPath = string.Format("{0}.{1}", this.publisherFullName, eventName);
            EventHelper.SpringEventSafelyAsyn<T1, T2, T3>(this.agileLogger, eventPath, theEvent, t1, t2, t3);
        }

        public void ActionAsyn<T1, T2, T3, T4>(string eventName, Delegate theEvent, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            string eventPath = string.Format("{0}.{1}", this.publisherFullName, eventName);
            EventHelper.SpringEventSafelyAsyn<T1, T2, T3, T4>(this.agileLogger, eventPath, theEvent, t1, t2, t3, t4);
        }

        public IAgileLogger AgileLogger
        {
            set
            {
                this.agileLogger = value;
            }
        }

        public string PublisherFullName
        {
            get
            {
                return this.publisherFullName;
            }
            set
            {
                this.publisherFullName = value;
            }
        }
    }
}

