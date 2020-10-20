namespace CJBasic.Threading.Engines
{
    using CJBasic;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public abstract class BaseEngineTache : IEngineTache
    {
        protected IEngineTacheUtil engineTacheUtil;
        protected volatile bool goStop = false;
        protected bool isActive = false;
        protected volatile bool paused = false;

        public abstract event CbSimpleObj EngineStatusChanged;

        public abstract event CbSimpleStr IgnoredMessagePublished;

        public abstract event CbSimpleStr MessagePublished;

        public abstract event CbProgress ProgressPublished;

        protected BaseEngineTache()
        {
        }

        public void Continue()
        {
            this.paused = false;
        }

        public abstract bool Excute(out string failureCause);
        public virtual void Initialize(IEngineTacheUtil util)
        {
            this.engineTacheUtil = util;
            this.InitializeEventHandler();
        }

        private void InitializeEventHandler()
        {
            this.ProgressPublished += delegate {
            };
            this.MessagePublished += delegate {
            };
            this.IgnoredMessagePublished += delegate {
            };
            this.EngineStatusChanged += delegate {
            };
        }

        public void Pause()
        {
            this.paused = true;
        }

        public void Stop()
        {
            this.goStop = true;
        }

        public abstract int EngineTacheID { get; }

        public bool IsActive
        {
            get
            {
                return this.isActive;
            }
        }

        public abstract string Title { get; }
    }
}

