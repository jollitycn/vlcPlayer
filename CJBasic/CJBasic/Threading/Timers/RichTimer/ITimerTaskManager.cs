namespace CJBasic.Threading.Timers.RichTimer
{
    using CJBasic.Loggers;
    using System;
    using System.Collections.Generic;

    public interface ITimerTaskManager : IDisposable
    {
        event CbTimerTask TimerTaskExpired;

        void AddTimerTask(TimerTask task);
        TimerTask GetTimerTask(string timerName);
        void Initialize();
        void RemoveTimerTask(string timerName);

        ILogger Logger { set; }

        int TimerSpanSecs { get; set; }

        IList<TimerTask> TimerTaskList { get; }
    }
}

