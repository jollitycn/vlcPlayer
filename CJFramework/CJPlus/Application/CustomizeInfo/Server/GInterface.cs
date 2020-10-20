namespace CJPlus.Application.CustomizeInfo.Server
{
    using CJBasic;
    using CJFramework;
    using CJPlus.Application;
    using System;

    public interface GInterface
    {
        event CbGeneric<Information> InformationReceived;

        event CbGeneric<Information> TransmitFailed;

        byte[] QueryLocalClient(string userID, int informationType, byte[] info);
        void QueryLocalClient(string userID, int informationType, byte[] info, CallbackHandler handler, object tag);
        void Send(string userID, int informationType, byte[] info);
        bool Send(string userID, int informationType, byte[] info, bool post, ActionTypeOnChannelIsBusy action);
        void SendBlob(string userID, int informationType, byte[] blobInfo, int fragmentSize);
        void SendCertainlyToLocalClient(string userID, int informationType, byte[] info);
        void SendCertainlyToLocalClient(string userID, int informationType, byte[] info, ResultHandler handler, object tag);
    }
}

