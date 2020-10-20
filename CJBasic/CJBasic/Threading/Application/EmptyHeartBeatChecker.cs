namespace CJBasic.Threading.Application
{
    using CJBasic;
    using System;
    using System.Threading;

    public class EmptyHeartBeatChecker : IHeartBeatChecker
    {
        public event CbSimpleStr SomeOneTimeOuted;

        public void Clear()
        {
        }

        public void Initialize()
        {
        }

        public void RegisterOrActivate(string id)
        {
        }

        public void Unregister(string id)
        {
        }

        public int DetectSpanInSecs
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public int SurviveSpanInSecs
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }
    }
}

