using CJFramework;
using CJPlus.Application.Basic;
using System;

internal class Class78 : IProcess
{
    private BasicOutter class113_0;
    private IActionType interface31_0;
    private ICommitMessageToServer interface4_0;
    private IStreamContractHelper interface9_0 = null;
    private BasicMessageTypeRoom object_0 = null;

    public bool CanProcess(int int_0)
    {
        return this.object_0.Contains(int_0);
    }

    public BasicMessageTypeRoom method_0()
    {
        return (BasicMessageTypeRoom) this.object_0;
    }

    public void method_1(BasicMessageTypeRoom basicMessageTypeRoom_0)
    {
        this.object_0 = basicMessageTypeRoom_0;
    }

    public void method_2(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    public void method_3(IActionType interface31_1)
    {
        this.interface31_0 = interface31_1;
    }

    public void method_4(ICommitMessageToServer interface4_1)
    {
        this.interface4_0 = interface4_1;
    }

    internal void method_5(BasicOutter class113_1)
    {
        this.class113_0 = class113_1;
    }

    public IMessageHandler ProcessMessage(IMessageHandler interface37_0)
    {
        IHeader interface3;
        IMessageHandler interface4;
        if (interface37_0.Header.MessageType == this.object_0.PingByServer)
        {
            interface3 = this.interface9_0.imethod_7(interface37_0.Header);
            interface3.MessageType = this.object_0.PingAck;
            interface4 = this.interface9_0.imethod_2<Class110>(interface3, null);
            this.interface31_0.imethod_0(interface4, true, ActionTypeOnChannelIsBusy.Continue);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.PingByP2PChannel)
        {
            interface3 = this.interface9_0.imethod_7(interface37_0.Header);
            interface3.MessageType = this.object_0.PingAck;
            interface4 = this.interface9_0.imethod_2<Class110>(interface3, null);
            this.interface31_0.imethod_0(interface4, true, ActionTypeOnChannelIsBusy.Continue);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.BeingPushedOutNotify)
        {
            this.class113_0.method_8();
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.BeingKickedOutNotify)
        {
            this.class113_0.method_9();
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.CallClient)
        {
            CallClientContract contract = this.interface9_0.imethod_1<CallClientContract>(interface37_0);
            new Class117().method_8(contract.InstanceID, this.interface4_0.GetAgileIPE().String_0, this.interface4_0.GetAgileIPE().Port);
            return null;
        }
        return null;
    }
}

