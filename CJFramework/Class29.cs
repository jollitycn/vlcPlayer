using CJFramework.Core;
using System;
using System.Net;

internal class Class29
{
    private IMessageHandler interface37_0;
    private IPEndPoint ipendPoint_0;
    private MessageInvalidType messageInvalidType_0;

    public Class29(IPEndPoint ipendPoint_1, MessageInvalidType messageInvalidType_1)
    {
        this.ipendPoint_0 = ipendPoint_1;
        this.messageInvalidType_0 = messageInvalidType_1;
        if (messageInvalidType_1 == MessageInvalidType.Valid)
        {
            throw new Exception("The Ctor just support Invalid Message !");
        }
    }

    public Class29(IPEndPoint ipendPoint_1, IMessageHandler interface37_1)
    {
        this.messageInvalidType_0 = MessageInvalidType.Valid;
        this.ipendPoint_0 = ipendPoint_1;
        this.interface37_0 = interface37_1;
    }

    public IPEndPoint method_0()
    {
        return this.ipendPoint_0;
    }

    public void method_1(IPEndPoint ipendPoint_1)
    {
        this.ipendPoint_0 = ipendPoint_1;
    }

    public IMessageHandler method_2()
    {
        return this.interface37_0;
    }

    public void method_3(IMessageHandler interface37_1)
    {
        this.interface37_0 = interface37_1;
    }

    public MessageInvalidType method_4()
    {
        return this.messageInvalidType_0;
    }

    public void method_5(MessageInvalidType messageInvalidType_1)
    {
        this.messageInvalidType_0 = messageInvalidType_1;
    }

    public bool method_6()
    {
        return (this.messageInvalidType_0 == MessageInvalidType.Valid);
    }
}

