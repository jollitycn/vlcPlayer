namespace CJBasic.Threading.Timers
{
    using CJBasic;
    using CJBasic.Threading.Engines;
    using System;

    public interface ICallbackTimer<T> : ICycleEngine
    {
        int AddCallback(int spanInSecs, CbGeneric<T> _callback, T _callbackPara);
        void Clear();
        int GetLeftSeconds(int taskID);
        void RemoveCallback(int taskID);
        int RemoveCallbackAndAddNew(int taskIDToRemoved, int spanInSecs, CbGeneric<T> _newCallback, T _newCallbackPara);

        int TaskCount { get; }
    }
}

