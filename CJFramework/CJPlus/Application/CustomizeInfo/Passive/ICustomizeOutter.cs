namespace CJPlus.Application.CustomizeInfo.Passive
{
    using CJFramework;
    using CJFramework.Passive;
    using CJPlus.Application;
    using System;

    public interface ICustomizeOutter
    {
        byte[] Query(int informationType, byte[] info);
        byte[] Query(string targetUserID, int informationType, byte[] info);
        void Query(string targetUserID, int informationType, byte[] info, CallbackHandler handler, object tag);
        void Send(int informationType, byte[] info);
        void Send(string targetUserID, int informationType, byte[] info);
        bool Send(string targetUserID, int informationType, byte[] info, bool post, ActionTypeOnChannelIsBusy action);
        bool Send(string targetUserID, int informationType, byte[] info, bool post, ActionTypeOnChannelIsBusy action, ChannelMode mode);
        void SendBlob(string targetUserID, int informationType, byte[] blobInfo, int fragmentSize);
        void SendBlob(string targetUserID, int informationType, byte[] blobInfo, int fragmentSize, ChannelMode mode);
        bool SendByP2PChannel(string targetUserID, int informationType, byte[] info, ActionTypeOnNoP2PChannel actionType, bool post, ActionTypeOnChannelIsBusy action);
        void SendCertainly(string targetUserID, int informationType, byte[] info);
        void SendCertainly(string targetUserID, int informationType, byte[] info, ResultHandler ackHandler, object tag);
        void TransferByServer(string targetUserID, int informationType, byte[] info);
    }
}

