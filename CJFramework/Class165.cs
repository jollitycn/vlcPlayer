using System;
using System.Collections.Generic;

internal abstract class Class165 : Interface33
{
    private bool bool_0 = true;
    private Enum9 enum9_0 = ((Enum9) 0);
    private IList<int> ilist_0 = new List<int>();
    private IList<int> ilist_1 = new List<int>();

    protected Class165()
    {
    }

    public IMessageHandler imethod_0(IMessageHandler interface37_0)
    {
        if (!this.bool_0)
        {
            return interface37_0;
        }
        if (!this.method_0(interface37_0.Header.MessageType))
        {
            return interface37_0;
        }
        return this.vmethod_0(interface37_0);
    }

    public IMessageHandler imethod_1(IMessageHandler interface37_0)
    {
        if (!this.bool_0)
        {
            return interface37_0;
        }
        if (!this.method_0(interface37_0.Header.MessageType))
        {
            return interface37_0;
        }
        return this.vmethod_1(interface37_0);
    }

    private bool method_0(int int_0)
    {
        if (this.enum9_0 != ((Enum9) 0))
        {
            if (this.enum9_0 == ((Enum9) 1))
            {
                foreach (int num in this.ilist_0)
                {
                    if (num == int_0)
                    {
                        return true;
                    }
                }
                return false;
            }
            foreach (int num in this.ilist_1)
            {
                if (num == int_0)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool method_1()
    {
        return this.bool_0;
    }

    public void method_2(bool bool_1)
    {
        this.bool_0 = bool_1;
    }

    public void method_3(IList<int> value)
    {
        this.ilist_0 = value ?? new List<int>();
    }

    public Enum9 method_4()
    {
        return this.enum9_0;
    }

    public void method_5(Enum9 enum9_1)
    {
        this.enum9_0 = enum9_1;
    }

    public void method_6(IList<int> value)
    {
        this.ilist_1 = value ?? new List<int>();
    }

    protected abstract IMessageHandler vmethod_0(IMessageHandler interface37_0);
    protected abstract IMessageHandler vmethod_1(IMessageHandler interface37_0);

    public enum Enum9
    {
    }
}

