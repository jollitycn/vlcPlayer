namespace CJBasic.Threading.Application
{
    using CJBasic;
    using System;
    using System.Collections.Generic;

    public interface ICircleTaskSwitcher<TTask>
    {
        event CbGeneric<TTask> TaskSwitched;

        void Initialize();

        TTask CurrentTask { get; }

        IDictionary<ShortTime, TTask> TaskDictionary { get; set; }
    }
}

