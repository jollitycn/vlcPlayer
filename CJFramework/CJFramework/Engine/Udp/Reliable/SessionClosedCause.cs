namespace CJFramework.Engine.Udp.Reliable
{
    using System;

    public enum SessionClosedCause
    {
        FeedbackTimeout,
        ResendTimeout,
        SocketException,
        DestExit,
        HeartBeatTimeout,
        ActiveClose,
        DestClose,
        DestIdentityChanged
    }
}

