namespace CJPlus.Application.Contacts.Passive
{
    using CJBasic;
    using CJFramework;
    using CJPlus.Application;
    using CJPlus.Application.Contacts;
    using System;
    using System.Collections.Generic;

    public interface IContactsOutter
    {
        event CbGeneric<string, string, int, byte[], string> BroadcastReceived;

        event CbGeneric<string> ContactsConnected;

        event CbGeneric<string> ContactsOffline;

        void Broadcast(string groupID, int broadcastType, byte[] broadcastContent, string tag, ActionTypeOnChannelIsBusy action);
        void BroadcastBlob(string groupID, int broadcastType, byte[] blobContent, string tag, int fragmentSize);
        void BroadcastBlob(string groupID, int broadcastType, byte[] blobContent, string tag, int fragmentSize, ResultHandler handler, object handlerTag);
        List<string> GetAllOnlineContacts();
        List<string> GetContacts();
        Groupmates GetGroupMembers(string groupID);
    }
}

