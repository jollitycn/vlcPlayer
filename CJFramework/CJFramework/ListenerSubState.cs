namespace CJFramework
{
    using System;

    public enum ListenerSubState
    {
        IdleSleep,
        ExcutePending,
        ExcuteAcceptSocket,
        ExcutePendingV6,
        ExcuteAcceptSocketV6,
        SetSocketOption,
        NewNetworkStream,
        SpringEstablishedEvent,
        ExitWithException
    }
}

