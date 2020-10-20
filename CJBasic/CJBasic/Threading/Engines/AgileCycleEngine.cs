namespace CJBasic.Threading.Engines
{
    using System;

    public sealed class AgileCycleEngine : BaseCycleEngine
    {
        private IEngineActor engineActor;

        public AgileCycleEngine(IEngineActor _engineActor)
        {
            this.engineActor = _engineActor;
        }

        protected override bool DoDetect()
        {
            return this.engineActor.EngineAction();
        }
    }
}

