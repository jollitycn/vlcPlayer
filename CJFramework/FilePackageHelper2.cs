using CJFramework;
using CJPlus.FileTransceiver;
using System;

internal class FilePackageHelper2 : IFilePackageHelper
{
    private Interface40 FnbMxAwygf = null;
    private int int_0;
    private IStreamContractHelper interface9_0;
    private string string_0;

    public FilePackageHelper2(string string_1, int int_1, Interface40 interface40_0, IStreamContractHelper interface9_1)
    {
        this.string_0 = string_1;
        this.int_0 = int_1;
        this.FnbMxAwygf = interface40_0;
        this.interface9_0 = interface9_1;
    }

    public void sendMessage(string string_1, FilePackage filePackage_0)
    {
        IMessageHandler interface2 = this.interface9_0.imethod_4<FilePackage>(this.string_0, this.int_0, filePackage_0, string_1);
        this.FnbMxAwygf.SendMessage(interface2, string_1, ActionTypeOnChannelIsBusy.Continue);
    }
}

