namespace CJPlus.Application.Friends.Server
{
    using System;

    public interface GInterface4
    {
        bool FriendConnectedNotifyEnabled { get; set; }

        bool FriendNotifyEnabled { get; set; }

        bool UseFriendNotifyThread { get; set; }
    }
}

