using CJFramework;
using CJFramework.Passive;
using System;

internal class Class94 : Interface36
{
    private IP2PChannel class80_0;
    private IMessageForbidden class97_0;
    private ICommitMessageToServer interface4_0;

    public Class94()
    {
        this.class97_0 = new MessageForbiddenHandler2();
        this.class80_0 = new Class80();
    }

    public Class94(ICommitMessageToServer interface4_1, IMessageForbidden interface39_0, IP2PChannel interface23_0)
    {
        this.class97_0 = new MessageForbiddenHandler2();
        this.class80_0 = new Class80();
        this.imethod_1(interface4_1);
        this.imethod_0(interface39_0);
        this.imethod_2(interface23_0 ?? new Class80());
    }

    public void imethod_0(IMessageForbidden interface39_0)
    {
        this.class97_0 = interface39_0 ?? new MessageForbiddenHandler2();
    }

    public void imethod_1(ICommitMessageToServer interface4_1)
    {
        this.interface4_0 = interface4_1;
    }

    public void imethod_2(IP2PChannel interface23_0)
    {
        this.class80_0 = interface23_0 ?? new Class80();
    }

    public bool IsP2PChannelExist(string string_0)
    {
        return this.class80_0.IsP2PChannelExist(string_0);
    }

    public bool SendByP2PChannel(IMessageHandler interface37_0, ActionTypeOnNoP2PChannel actionTypeOnNoP2PChannel_0, bool bool_0, string string_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        bool flag2;
        IMessageHandler interface2 = this.class97_0.imethod_3(interface37_0);
        if (interface2 == null)
        {
            return false;
        }
        if (flag2 = this.class80_0.SendMessage(string_0, interface2, bool_0, actionTypeOnChannelIsBusy_0))
        {
            return true;
        }
        if (!(flag2 || (actionTypeOnNoP2PChannel_0 != ActionTypeOnNoP2PChannel.Discard)))
        {
            return false;
        }
        return this.interface4_0.CommitMessageToServer(interface2, bool_0, actionTypeOnChannelIsBusy_0);
    }

    public bool SendMessage(IMessageHandler interface37_0, bool bool_0, bool bool_1, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        if (NetServer.IsServerUser(interface37_0.Header.DestUserID) || bool_0)
        {
            if (this.class97_0.imethod_3(interface37_0) == null)
            {
                return false;
            }
            return this.interface4_0.CommitMessageToServer(interface37_0, bool_1, actionTypeOnChannelIsBusy_0);
        }
        return this.SendByP2PChannel(interface37_0, ActionTypeOnNoP2PChannel.TransferByServer, bool_1, interface37_0.Header.DestUserID, actionTypeOnChannelIsBusy_0);
    }

    public bool? Connected
    {
        get
        {
            Interface26 interface2 = this.interface4_0 as Interface26;
            if (interface2 == null)
            {
                return null;
            }
            return new bool?(interface2.Connected);
        }
    }
}

