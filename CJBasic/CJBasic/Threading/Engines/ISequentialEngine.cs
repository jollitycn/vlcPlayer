namespace CJBasic.Threading.Engines
{
    using CJBasic;
    using System;
    using System.Collections.Generic;

    public interface ISequentialEngine
    {
        event CbSimple EngineCompleted;

        event CbSimpleStr EngineDisruptted;

        event CbSimpleObj EngineStatusChanged;

        event CbSimpleStr IgnoredMessagePublished;

        event CbSimpleStr MessagePublished;

        event CbProgress PartProgressPublished;

        event CbSimpleStr TitleChanged;

        void Continue();
        void Excute();
        IEngineTache GetEngineTache(int tacheID);
        void Initialize(IList<IEngineTache> tacheList, bool has_NecceryEnder);
        void Pause();
        void Stop();

        bool Running { get; }
    }
}

