using CJFramework.Core;
using System;
using System.Net;

internal class Class130 : Interface44
{
    private int int_0 = 0x400;
    private IStreamContractHelper1 interface46_0;
    private string string_0 = "";

    public Class130(IStreamContractHelper1 interface46_1, int int_1, string string_1)
    {
        this.interface46_0 = interface46_1;
        this.int_0 = int_1;
        this.string_0 = string_1;
    }

    public Class29 imethod_0(IPEndPoint ipendPoint_0, byte[] byte_0)
    {
        if (byte_0 == null)
        {
            return null;
        }
        if (byte_0.Length > this.int_0)
        {
            return new Class29(ipendPoint_0, MessageInvalidType.MessageSizeOverflow);
        }
        if (byte_0.Length < this.interface46_0.imethod_9())
        {
            return new Class29(ipendPoint_0, MessageInvalidType.DataLacked);
        }
        Interface22 interface2 = this.interface46_0.imethod_10(byte_0, 0);
        if (interface2 == null)
        {
            return new Class29(ipendPoint_0, MessageInvalidType.InvalidHeader);
        }
        if (interface2.imethod_2() != this.interface46_0.imethod_8())
        {
            return new Class29(ipendPoint_0, MessageInvalidType.InvalidToken);
        }
        int num = this.interface46_0.imethod_9() + interface2.imethod_5();
        if (interface2.imethod_5() < 0)
        {
            return new Class29(ipendPoint_0, MessageInvalidType.InvalidHeader);
        }
        if (num > byte_0.Length)
        {
            return new Class29(ipendPoint_0, MessageInvalidType.DataLacked);
        }
        byte[] dst = null;
        if (interface2.imethod_5() > 0)
        {
            dst = new byte[interface2.imethod_5()];
            Buffer.BlockCopy(byte_0, this.interface46_0.imethod_9(), dst, 0, interface2.imethod_5());
        }
        return new Class29(ipendPoint_0, new MessageHandler(interface2, dst, 0, ipendPoint_0));
    }
}

