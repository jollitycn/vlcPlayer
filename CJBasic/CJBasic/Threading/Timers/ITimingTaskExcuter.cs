namespace CJBasic.Threading.Timers
{
    using System;

    public interface ITimingTaskExcuter
    {
        void ExcuteOnTime(DateTime dt);
    }
}

