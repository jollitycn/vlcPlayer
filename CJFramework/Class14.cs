using System;
using System.Threading;

internal abstract class Class14 : IStreamContract, IStreamContractHelper
{
    private int int_0 = 0;

    protected Class14()
    {
    }

    public abstract Enum6 imethod_0();
    public abstract TBody imethod_1<TBody>(IMessageHandler interface37_0) where TBody: class, new();
    public IMessageHandler imethod_2<TBody>(IHeader interface21_0, TBody body) where TBody: class
    {
        return this.imethod_3<TBody>(interface21_0.UserID, interface21_0.MessageType, body, interface21_0.DestUserID, interface21_0.MessageID);
    }

    public abstract IMessageHandler imethod_3<TBody>(string string_0, int int_1, TBody body, string string_1, int int_2) where TBody: class;
    public IMessageHandler imethod_4<TBody>(string string_0, int int_1, TBody body, string string_1) where TBody: class
    {
        return this.imethod_3<TBody>(string_0, int_1, body, string_1, this.method_0());
    }

    public IMessageHandler imethod_5<TBody>(string string_0, int int_1, TBody body) where TBody: class
    {
        return this.imethod_3<TBody>(string_0, int_1, body, "_0", this.method_0());
    }

    public IMessageHandler imethod_6(string string_0, int int_1)
    {
        return this.imethod_3<Class110>(string_0, int_1, null, "_0", this.method_0());
    }

    public IHeader imethod_7(IHeader interface21_0)
    {
        IHeader interface2 = (IHeader) interface21_0.Clone();
        interface2.UserID = interface21_0.DestUserID;
        interface2.DestUserID = interface21_0.UserID;
        return interface2;
    }

    private int method_0()
    {
        if (this.int_0 == 0x7fffffff)
        {
            this.int_0 = 0;
        }
        return Interlocked.Increment(ref this.int_0);
    }
}

