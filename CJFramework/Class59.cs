using CJPlus.Application.Friends;
using System;

internal class Class59 : IProcess
{
    private FriendsOutter class126_0;
    private IStreamContractHelper interface9_0 = null;
    private FriendsMessageTypeRoom object_0 = null;

    public bool CanProcess(int int_0)
    {
        return this.object_0.Contains(int_0);
    }

    public FriendsMessageTypeRoom method_0()
    {
        return (FriendsMessageTypeRoom) this.object_0;
    }

    public void method_1(FriendsMessageTypeRoom friendsMessageTypeRoom_0)
    {
        this.object_0 = friendsMessageTypeRoom_0;
    }

    public void method_2(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    public void method_3(FriendsOutter class126_1)
    {
        this.class126_0 = class126_1;
    }

    public IMessageHandler ProcessMessage(IMessageHandler interface37_0)
    {
        if (interface37_0.Header.MessageType == this.object_0.FriendNotify)
        {
            FriendNotifyContract contract = this.interface9_0.imethod_1<FriendNotifyContract>(interface37_0);
            if (contract.Connected)
            {
                this.class126_0.method_6(contract.FriendUserID);
            }
            else
            {
                this.class126_0.method_7(contract.FriendUserID);
            }
            return null;
        }
        return null;
    }
}

