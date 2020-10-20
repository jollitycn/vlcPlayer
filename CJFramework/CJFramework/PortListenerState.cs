namespace CJFramework
{
    using System;

    public class PortListenerState
    {
        private bool bool_0;
        private bool bool_1;
        private bool bool_2;
        private bool bool_3;
        private DateTime dateTime_0;
        private ListenerSubState listenerSubState_0;

        public PortListenerState()
        {
            this.dateTime_0 = DateTime.Now;
            this.bool_0 = true;
            this.bool_1 = true;
            this.bool_2 = false;
            this.bool_3 = true;
            this.listenerSubState_0 = ListenerSubState.IdleSleep;
        }

        public PortListenerState(DateTime last, bool listen, bool authorized, bool connFull, bool running, ListenerSubState sub)
        {
            this.dateTime_0 = DateTime.Now;
            this.bool_0 = true;
            this.bool_1 = true;
            this.bool_2 = false;
            this.bool_3 = true;
            this.listenerSubState_0 = ListenerSubState.IdleSleep;
            this.dateTime_0 = last;
            this.bool_0 = listen;
            this.bool_1 = authorized;
            this.bool_2 = connFull;
            this.bool_3 = running;
            this.listenerSubState_0 = sub;
        }

        public override string ToString()
        {
            return string.Format("IsAuthorized : {0} , IsListening : {1} , IsMaxConnection : {2} , LastDetectTime : {3} , ListenThreadRunning : {4} , SubState : {5} ", new object[] { this.bool_1, this.bool_0, this.bool_2, this.dateTime_0, this.bool_3, this.listenerSubState_0 });
        }

        public bool IsAuthorized
        {
            get
            {
                return this.bool_1;
            }
        }

        public bool IsListening
        {
            get
            {
                return this.bool_0;
            }
        }

        public bool IsMaxConnection
        {
            get
            {
                return this.bool_2;
            }
        }

        public DateTime LastDetectTime
        {
            get
            {
                return this.dateTime_0;
            }
        }

        public bool ListenThreadRunning
        {
            get
            {
                return this.bool_3;
            }
        }

        public ListenerSubState SubState
        {
            get
            {
                return this.listenerSubState_0;
            }
        }
    }
}

