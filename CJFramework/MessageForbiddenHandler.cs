using CJBasic;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal class MessageForbiddenHandler : IMessageForbidden
{
    [CompilerGenerated]
    private static CbGeneric<IMessageHandler> cbGeneric_1;
    private Interface45 class133_0 = new Class133();
    private Interface45 class133_1 = new Class133();
    private Interface33 class91_0 = new Class91();

    public event CbGeneric<IMessageHandler> MessageForbidden;

    public MessageForbiddenHandler()
    {
        if (cbGeneric_1 == null)
        {
            cbGeneric_1 = new CbGeneric<IMessageHandler>(MessageForbiddenHandler.smethod_0);
        }
        this.MessageForbidden += cbGeneric_1;
    }

    public void imethod_0(Interface33 interface33_0)
    {
        this.class91_0 = interface33_0 ?? new Class91();
    }

    public void imethod_1(Interface45 interface45_0)
    {
        if (interface45_0 != null)
        {
            this.class133_1 = interface45_0 ?? new Class133();
        }
    }

    public void imethod_2(Interface45 interface45_0)
    {
        if (interface45_0 != null)
        {
            this.class133_0 = interface45_0 ?? new Class133();
        }
    }

    public IMessageHandler imethod_3(IMessageHandler interface37_0)
    {
        if (!this.class133_0.imethod_1(interface37_0))
        {
            this.MessageForbidden(interface37_0);
            return null;
        }
        IMessageHandler interface3 = this.class91_0.imethod_0(interface37_0);
        if (!this.class133_1.imethod_1(interface3))
        {
            this.MessageForbidden(interface37_0);
            return null;
        }
        return interface3;
    }

    public IMessageHandler imethod_4(IMessageHandler interface37_0)
    {
        if (!this.class133_1.imethod_0(interface37_0))
        {
            this.MessageForbidden(interface37_0);
            return null;
        }
        IMessageHandler interface3 = this.class91_0.imethod_1(interface37_0);
        if (!this.class133_0.imethod_0(interface3))
        {
            this.MessageForbidden(interface37_0);
            return null;
        }
        return interface3;
    }

    public Interface33 method_0()
    {
        return this.class91_0;
    }

    [CompilerGenerated]
    private static void smethod_0(object object_0)
    {
    }
}

