using CJFramework.Core;
using System;
using System.Net;

internal class Class129 : Interface44
{
    private int int_0 = 0x400;
    private ITextContractHelper object_0;
    private string string_0 = "";

    public Class129(ITextContractHelper interface11_0, int int_1, string string_1)
    {
        this.object_0 = interface11_0;
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
        string str = this.object_0.imethod_8(byte_0, 0, byte_0.Length);
        if (!this.object_0.imethod_12(str))
        {
            return new Class29(ipendPoint_0, MessageInvalidType.InvalidToken);
        }
        IHeader4 interface2 = this.object_0.imethod_11(str);
        if (interface2 == null)
        {
            return new Class29(ipendPoint_0, MessageInvalidType.InvalidHeader);
        }
        return new Class29(ipendPoint_0, new Message1(interface2, str, ipendPoint_0));
    }
}

