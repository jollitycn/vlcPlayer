namespace CJPlus.Application.Contacts.Server
{
    using CJBasic;
    using CJFramework;
    using CJPlus.Application;
    using System;

    public interface IContactsOutter
    {
        event CbGeneric<string, BroadcastInformation> BroadcastFailed;

        event CbGeneric<string, string, int, byte[], string> BroadcastReceived;

        void Broadcast(string groupID, int broadcastType, byte[] broadcastContent, string tag, ActionTypeOnChannelIsBusy action);
        void BroadcastBlob(string groupID, int broadcastType, byte[] blobContent, string tag, int fragmentSize);
        void BroadcastBlob(string groupID, int broadcastType, byte[] blobContent, string tag, int fragmentSize, ResultHandler handler, object handlerTag);

        bool BroadcastBlobListened { get; set; }

        bool ContactsConnectedNotifyEnabled { get; set; }

        bool ContactsDisconnectedNotifyEnabled { get; set; }

        bool UseContactsNotifyThread { get; set; }
    }
}

