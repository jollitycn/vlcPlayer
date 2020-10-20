using System;
using System.Collections.Generic;

internal sealed class Class143 : Interface45
{
    private bool bool_0 = true;
    private IList<Interface45> ilist_0 = new List<Interface45>();

    public bool imethod_0(IMessageHandler interface37_0)
    {
        if (this.bool_0)
        {
            foreach (Interface45 interface2 in this.ilist_0)
            {
                if (!interface2.imethod_0(interface37_0))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool imethod_1(IMessageHandler interface37_0)
    {
        if (this.bool_0)
        {
            foreach (Interface45 interface2 in this.ilist_0)
            {
                if (!interface2.imethod_1(interface37_0))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void method_0(IList<Interface45> value)
    {
        this.ilist_0 = value ?? new List<Interface45>();
    }

    public void method_1(bool bool_1)
    {
        this.bool_0 = bool_1;
    }

    public bool method_2()
    {
        return this.bool_0;
    }
}

