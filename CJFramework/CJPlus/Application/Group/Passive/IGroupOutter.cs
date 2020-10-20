namespace CJPlus.Application.Group.Passive
{
    using CJBasic;
    using CJFramework;
    using CJPlus.Application;
    using CJPlus.Application.Group;
    using System;

    public interface IGroupOutter
    {
        event CbGeneric<string, string, int, byte[]> BroadcastReceived;

        event CbGeneric<string> GroupmateConnected;

        event CbGeneric<string> GroupmateOffline;

        void Broadcast(string groupID, int broadcastType, byte[] broadcastContent, ActionTypeOnChannelIsBusy action);
        void BroadcastBlob(string groupID, int broadcastType, byte[] blobContent, int fragmentSize);
        void BroadcastBlob(string groupID, int broadcastType, byte[] blobContent, int fragmentSize, ResultHandler handler, object handlerTag);
        Groupmates GetGroupMembers(string groupID);
    }
}

