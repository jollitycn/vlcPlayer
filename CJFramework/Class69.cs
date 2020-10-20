using CJFramework;
using System;

internal class Class69 : FileMessage, IProcess
{
    private Interface40 interface40_0 = null;

    public void method_6(Interface40 interface40_1)
    {
        this.interface40_0 = interface40_1;
    }

    public IMessageHandler ProcessMessage(IMessageHandler interface37_0)
    {
        if (!NetServer.IsServerUser(interface37_0.Header.DestUserID))
        {
            this.interface40_0.SendMessage(interface37_0, interface37_0.Header.DestUserID, ActionTypeOnChannelIsBusy.Continue);
            return null;
        }
        if (interface37_0.Header.MessageType == base.object_0.ContinueTransFile)
        {
            new ContinueTransFile().method_0();
            return null;
        }
        return base.method_5(interface37_0);
    }
}

