namespace CJBasic.Threading.Application
{
    using CJBasic;
    using System;

    public interface IHeartBeatChecker
    {
        event CbSimpleStr SomeOneTimeOuted;

        void Clear();
        void Initialize();
        void RegisterOrActivate(string id);
        void Unregister(string id);

        int DetectSpanInSecs { get; set; }

        int SurviveSpanInSecs { get; set; }
    }
}

