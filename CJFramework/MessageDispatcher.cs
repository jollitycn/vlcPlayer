using CJBasic.Loggers;
using System;

internal sealed class MessageDispatcher : Interface25
{
    private IMessageForbidden class97_0;
    private IAgileLogger emptyAgileLogger_0;
    private Interface32 interface32_0;

    public MessageDispatcher()
    {
        this.emptyAgileLogger_0 = new EmptyAgileLogger();
        this.class97_0 = new MessageForbiddenHandler2();
    }

    public MessageDispatcher(Interface32 interface32_1, IMessageForbidden interface39_0)
    {
        this.emptyAgileLogger_0 = new EmptyAgileLogger();
        this.class97_0 = new MessageForbiddenHandler2();
        this.interface32_0 = interface32_1;
        this.imethod_2(interface39_0);
    }

    public void imethod_0(IAgileLogger iagileLogger_0)
    {
        if (iagileLogger_0 != null)
        {
            this.emptyAgileLogger_0 = iagileLogger_0 ?? new EmptyAgileLogger();
        }
    }

    public IMessageForbidden GetMessageForbidden()
    {
        return this.class97_0;
    }

    public void imethod_2(IMessageForbidden interface39_0)
    {
        this.class97_0 = interface39_0 ?? new MessageForbiddenHandler2();
    }

    public void imethod_3(Interface32 interface32_1)
    {
        this.interface32_0 = interface32_1;
    }

    public IMessageHandler DispatchMessage(IMessageHandler interface37_0)
    {
        try
        {
            IMessageHandler interface2 = this.class97_0.imethod_4(interface37_0);
            if (interface2 == null)
            {
                return null;
            }
            IMessageHandler interface3 = this.interface32_0.imethod_1(interface2);
            if (interface3 == null)
            {
                return null;
            }
            return this.class97_0.imethod_3(interface3);
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, string.Format("CJFramework.Core.MessageDispatcher.DispatchMessage - {0}", interface37_0.ToString()), ErrorLevel.High);
            return null;
        }
    }
}

