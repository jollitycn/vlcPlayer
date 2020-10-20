namespace CJBasic.Threading.Engines
{
    using CJBasic;
    using System;
    using System.Runtime.InteropServices;

    public interface IEngineTache
    {
        event CbSimpleObj EngineStatusChanged;

        event CbSimpleStr IgnoredMessagePublished;

        event CbSimpleStr MessagePublished;

        event CbProgress ProgressPublished;

        void Continue();
        bool Excute(out string failureCause);
        void Initialize(IEngineTacheUtil util);
        void Pause();
        void Stop();

        int EngineTacheID { get; }

        bool IsActive { get; }

        string Title { get; }
    }
}

