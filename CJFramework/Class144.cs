using System;

internal sealed class Class144 : Interface32
{
    private bool bool_0;
    private Interface38 interface38_0;

    public Class144()
    {
        this.interface38_0 = null;
        this.bool_0 = true;
    }

    public Class144(Interface38 interface38_1)
    {
        this.interface38_0 = null;
        this.bool_0 = true;
        this.interface38_0 = interface38_1;
    }

    public void imethod_0(Interface38 interface38_1)
    {
        this.interface38_0 = interface38_1;
    }

    public IMessageHandler imethod_1(IMessageHandler interface37_0)
    {
        if (interface37_0.Header.MessageType == 100)
        {
            if (interface37_0.Header.MessageID == 0x7fffff90)
            {
                this.bool_0 = false;
                return null;
            }
            if (interface37_0.Header.MessageID == 0x7fffff8f)
            {
                this.bool_0 = true;
                return null;
            }
        }
        if (!this.bool_0)
        {
            return null;
        }
        IProcess interface2 = this.interface38_0.imethod_0(interface37_0.Header.MessageType);
        if (interface2 == null)
        {
            throw new Exception(string.Format("The Message Processer On Key [{0}] is not found !", interface37_0.Header.MessageType));
        }
        return interface2.ProcessMessage(interface37_0);
    }
}

