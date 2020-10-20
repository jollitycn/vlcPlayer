namespace CJFramework.Server
{
    using System;

    public enum DisconnectedType
    {
        NetworkInterrupted,
        InvalidMessage,
        MessageWithWrongUserID,
        HeartBeatTimeout,
        BeingPushedOut,
        NewConnectionIgnored,
        ChannelCacheOverflow,
        UnauthorizedClientType,
        MaxConnectionCountLimitted
    }
}

