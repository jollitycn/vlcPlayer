using System;
using System.Collections.Generic;

internal sealed class Class160 : Interface33
{
    private IList<Interface33> ilist_0 = new List<Interface33>();

    public IMessageHandler imethod_0(IMessageHandler interface37_0)
    {
        if (interface37_0 == null)
        {
            return null;
        }
        IMessageHandler interface2 = interface37_0;
        for (int i = this.ilist_0.Count - 1; i >= 0; i--)
        {
            interface2 = this.ilist_0[i].imethod_0(interface2);
        }
        return interface2;
    }

    public IMessageHandler imethod_1(IMessageHandler interface37_0)
    {
        if (interface37_0 == null)
        {
            return null;
        }
        IMessageHandler interface2 = interface37_0;
        for (int i = 0; i < this.ilist_0.Count; i++)
        {
            interface2 = this.ilist_0[i].imethod_1(interface2);
        }
        return interface2;
    }

    public void method_0(IList<Interface33> value)
    {
        this.ilist_0 = value ?? new List<Interface33>();
    }
}

