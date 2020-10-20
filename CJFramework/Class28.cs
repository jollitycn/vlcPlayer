using CJFramework;
using CJPlus.Application.FileTransfering;
using CJPlus.Application.FileTransfering.Passive;
using System;

internal class Class28 : FileTransfer, IFile, CJPlus.Application.FileTransfering.Passive.IFileOutter
{
    private bool bool_0 = false;
    private IActionType interface31_0 = null;

    public virtual void Initialize(string string_1)
    {
        base.method_3(string_1);
        this.bool_0 = true;
    }

    public bool method_15()
    {
        return this.bool_0;
    }

    public void method_16(IActionType interface31_1)
    {
        this.interface31_0 = interface31_1;
    }

    protected override void SendMessage(IMessageHandler interface37_0, bool bool_1)
    {
        this.interface31_0.Send(interface37_0, bool_1, ActionTypeOnChannelIsBusy.Continue);
    }
}

