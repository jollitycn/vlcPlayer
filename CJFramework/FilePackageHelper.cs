using CJFramework;
using CJPlus.FileTransceiver;
using System;

internal class FilePackageHelper : IFilePackageHelper
{
    private int int_0;
    private IActionType interface31_0 = null;
    private IStreamContractHelper interface9_0;
    private string string_0;

    public FilePackageHelper(string string_1, int int_1, IActionType interface31_1, IStreamContractHelper interface9_1)
    {
        this.string_0 = string_1;
        this.int_0 = int_1;
        this.interface31_0 = interface31_1;
        this.interface9_0 = interface9_1;
    }

    public void sendMessage(string string_1, FilePackage filePackage_0)
    {
        IMessageHandler interface2 = this.interface9_0.imethod_4<FilePackage>(this.string_0, this.int_0, filePackage_0, string_1);
        this.interface31_0.Send(interface2, false, ActionTypeOnChannelIsBusy.Continue);
    }
}

