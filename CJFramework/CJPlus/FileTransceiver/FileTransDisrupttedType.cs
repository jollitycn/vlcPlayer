namespace CJPlus.FileTransceiver
{
    using System;

    public enum FileTransDisrupttedType
    {
        RejectAccepting,
        ActiveCancel,
        DestCancel,
        DestOffline,
        ReliableP2PChannelClosed,
        SelfOffline,
        InnerError,
        DestInnerError,
        NetworkSpeedSlow,
        ReadFileBlocked,
        SendThreadNotStarted,
        Timeout4FirstPackage
    }
}

