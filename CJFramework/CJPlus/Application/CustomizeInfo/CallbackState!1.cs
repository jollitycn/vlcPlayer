namespace CJPlus.Application.CustomizeInfo
{
    using System;

    public class CallbackState<THandler>
    {
        private THandler gparam_0;
        private object object_0;

        public CallbackState(THandler _handler, object _tag)
        {
            this.gparam_0 = _handler;
            this.object_0 = _tag;
        }

        public THandler Handler
        {
            get
            {
                return this.gparam_0;
            }
        }

        public object Tag
        {
            get
            {
                return this.object_0;
            }
        }
    }
}

