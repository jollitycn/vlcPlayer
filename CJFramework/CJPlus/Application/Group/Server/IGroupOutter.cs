namespace CJPlus.Application.Group.Server
{
    using CJBasic;
    using CJFramework;
    using System;

    public interface IGroupOutter
    {
        event CbGeneric<string, string, int, byte[]> BroadcastReceived;

        void Broadcast(string groupID, int broadcastType, byte[] broadcastContent, ActionTypeOnChannelIsBusy action);
        void BroadcastBlob(string groupID, int broadcastType, byte[] blobContent, int fragmentSize);

        bool BroadcastBlobListened { get; set; }

        bool GroupmateConnectedNotifyEnabled { get; set; }

        bool GroupNotifyEnabled { get; set; }

        bool UseGroupNotifyThread { get; set; }
    }
}

