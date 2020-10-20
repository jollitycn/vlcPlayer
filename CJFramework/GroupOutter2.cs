using CJBasic;
using CJFramework;
using CJPlus.Application;
using CJPlus.Application.Group;
using CJPlus.Application.Group.Passive;
using CJPlus.Application.P2PSession.Passive;
using System;
using System.Threading;

internal class GroupOutter2 : IGroupOutter
{
    private bool bool_0 = false;
    private IP2PController gclass0_0 = new GClass0();
    private GroupMessageTypeRoom groupMessageTypeRoom_0;
    private int int_0 = 0;
    private IActionType interface31_0 = null;
    private ICommitMessageToServer interface4_0;
    private IStreamContractHelper interface9_0 = null;
    private string string_0 = "";

    public event CbGeneric<string, string, int, byte[]> BroadcastReceived;

    public event CbGeneric<string> GroupmateConnected;

    public event CbGeneric<string> GroupmateOffline;

    public void Broadcast(string groupID, int broadcastType, byte[] broadcastContent, ActionTypeOnChannelIsBusy action)
    {
        BroadcastContract body = new BroadcastContract(groupID, broadcastType, broadcastContent, action);
        IMessageHandler interface2 = this.interface9_0.imethod_4<BroadcastContract>(this.string_0, this.groupMessageTypeRoom_0.BroadcastByServer, body, groupID);
        this.interface31_0.imethod_0(interface2, true, action);
    }

    public void BroadcastBlob(string groupID, int broadcastType, byte[] blobContent, int fragmentSize)
    {
        if (fragmentSize <= 0)
        {
            throw new ArgumentException("Value of fragmentSize must be greater than 0.");
        }
        int num2 = Interlocked.Increment(ref this.int_0);
        int num3 = blobContent.Length / fragmentSize;
        if ((blobContent.Length % fragmentSize) > 0)
        {
            num3++;
        }
        for (int i = 0; i < num3; i++)
        {
            if (!this.interface31_0.Connected.Value)
            {
                throw new Exception("The connection to server is interrupted !");
            }
            byte[] dst = null;
            if (i < (num3 - 1))
            {
                dst = new byte[fragmentSize];
            }
            else
            {
                dst = new byte[blobContent.Length - (i * fragmentSize)];
            }
            Buffer.BlockCopy(blobContent, i * fragmentSize, dst, 0, dst.Length);
            BlobFragmentContract body = new BlobFragmentContract(num2, broadcastType, i, dst, i == (num3 - 1));
            IMessageHandler interface2 = this.interface9_0.imethod_4<BlobFragmentContract>(this.string_0, this.groupMessageTypeRoom_0.BroadcastBlob, body, groupID);
            if (!this.interface31_0.imethod_0(interface2, false, ActionTypeOnChannelIsBusy.Continue))
            {
                throw new Exception("The connection to server is interrupted !");
            }
        }
    }

    public void BroadcastBlob(string groupID, int broadcastType, byte[] blobContent, int fragmentSize, ResultHandler handler, object handlerTag)
    {
        new CbGeneric<string, int, byte[], int, ResultHandler, object>(this.method_7).BeginInvoke(groupID, broadcastType, blobContent, fragmentSize, handler, handlerTag, null, null);
    }

    public Groupmates GetGroupMembers(string groupID)
    {
        IMessageHandler interface2 = this.interface9_0.imethod_5<GroupContract>(this.string_0, this.groupMessageTypeRoom_0.GetGroupMembers, new GroupContract(groupID));
        IMessageHandler interface3 = this.interface31_0.imethod_1(interface2, new int?(this.groupMessageTypeRoom_0.GetGroupMembers));
        return this.interface9_0.imethod_1<GroupmatesContract>(interface3);
    }

    internal void GroupmateConnectedNotify(string string_1)
    {
        if (this.GroupmateConnected != null)
        {
            this.GroupmateConnected(string_1);
        }
    }
    
    public void Iibebiqvn1(GroupMessageTypeRoom groupMessageTypeRoom_1)
    {
        this.groupMessageTypeRoom_0 = groupMessageTypeRoom_1;
    }

    public void method_0(IActionType interface31_1)
    {
        this.interface31_0 = interface31_1;
    }

    public void method_1(IP2PController ip2PController_0)
    {
        this.gclass0_0 = ip2PController_0 ?? new GClass0();
    }

    public void SetCommitMessageToServer(ICommitMessageToServer interface4_1)
    {
        this.interface4_0 = interface4_1;
    }

    public bool method_3()
    {
        return this.bool_0;
    }

    public void method_4(string string_1)
    {
        this.string_0 = string_1;
        this.bool_0 = true;
    }

    internal void GroupmateOfflineNotify(string string_1)
    {
        if (this.GroupmateOffline != null)
        {
            this.GroupmateOffline(string_1);
        }
    }
    //public event CbGeneric<string, string, int, byte[]> BroadcastReceived;

    //public event CbGeneric<string> GroupmateConnected;

    //public event CbGeneric<string> GroupmateOffline;
    internal void method_6(string string_1, string string_2, int int_1, byte[] byte_0)
    {
        if (this.BroadcastReceived != null)
        {
            this.BroadcastReceived(string_1, string_2, int_1, byte_0);
        }
    }

    private void method_7(string string_1, int int_1, byte[] byte_0, int int_2, ResultHandler resultHandler_0, object object_0)
    {
        try
        {
            this.BroadcastBlob(string_1, int_1, byte_0, int_2);
            if (resultHandler_0 != null)
            {
                resultHandler_0(true, object_0);
            }
        }
        catch (Exception)
        {
            if (resultHandler_0 != null)
            {
                resultHandler_0(false, object_0);
            }
        }
    }

    public void uBkeyEkxPJ(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }
}

