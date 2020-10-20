using CJBasic;
using CJFramework;
using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;

internal abstract class Class4 : Interface5
{
    private bool bool_0 = false;
    private CbGeneric<Interface5, IMessageHandler> cbGeneric_0;
    private Class47 class47_0;
    private ClientType clientType_0 = ClientType.DotNET;
    private DateTime dateTime_0 = DateTime.Now;
    private Enum4 enum4_0 = ((Enum4) 0);
    private int int_0;
    private int int_1 = 0;
    private int int_2 = 0;
    private IPEndPoint ipendPoint_0;
    private long long_0 = 0L;
    private Stream stream_0 = null;
    private string string_0;

    public Class4(Stream stream_1, IPEndPoint ipendPoint_1, CbGeneric<Interface5, IMessageHandler> pointer, int int_3)
    {
        this.stream_0 = stream_1;
        this.ipendPoint_0 = ipendPoint_1;
        this.cbGeneric_0 = pointer;
        this.int_0 = int_3;
        this.class47_0 = new Class47(new CbGeneric<IMessageHandler>(this.method_0));
    }

    public DateTime GetDateTime()
    {
        return this.dateTime_0;
    }

    public bool imethod_1()
    {
        return (this.long_0 > 0L);
    }

    public Class47 imethod_10()
    {
        return this.class47_0;
    }

    public virtual void imethod_11(ref byte[] byte_0)
    {
    }

    public void imethod_12()
    {
        Interlocked.Increment(ref this.long_0);
    }

    public void imethod_13(string string_1)
    {
        this.string_0 = string_1;
        this.enum4_0 = (Enum4) 1;
    }

    public void imethod_14()
    {
        Interlocked.Increment(ref this.int_1);
    }

    public void imethod_15()
    {
        Interlocked.Decrement(ref this.int_1);
        if (this.int_1 < 0)
        {
            this.int_1 = 0;
        }
    }

    public void imethod_16()
    {
        Interlocked.Increment(ref this.int_2);
    }

    public void imethod_17()
    {
        Interlocked.Decrement(ref this.int_2);
        if (this.int_2 < 0)
        {
            this.int_2 = 0;
        }
    }

    public void imethod_18(out int int_3, out int int_4)
    {
        int_3 = this.method_3();
        int_4 = this.method_2();
    }

    public int imethod_19()
    {
        return (this.int_1 + this.int_2);
    }

    public ClientType GetClientType()
    {
        return this.clientType_0;
    }

    public void SetClientType(ClientType clientType_1)
    {
        this.clientType_0 = clientType_1;
    }

    public Enum4 imethod_4()
    {
        return this.enum4_0;
    }

    public void imethod_5(Enum4 enum4_1)
    {
        this.enum4_0 = enum4_1;
    }

    public bool imethod_6()
    {
        return this.bool_0;
    }

    public void imethod_7(bool bool_1)
    {
        this.bool_0 = bool_1;
    }

    public Stream GetStream()
    {
        return this.stream_0;
    }

    public IPEndPoint GetIPEndPoint()
    {
        return this.ipendPoint_0;
    }

    private void method_0(IMessageHandler interface37_0)
    {
        this.cbGeneric_0(this, interface37_0);
    }

    public void method_1(Stream stream_1)
    {
        this.stream_0 = stream_1;
    }

    public int method_2()
    {
        return this.int_1;
    }

    public int method_3()
    {
        return this.int_2;
    }

    public bool VerifyUser(string string_1)
    {
        return ((this.string_0 == null) || (this.string_0 == string_1));
    }

    public bool ChannelIsBusy
    {
        get
        {
            if (this.int_0 < 0)
            {
                return false;
            }
            return ((this.int_1 + this.int_2) > this.int_0);
        }
    }

    public string UserID
    {
        get
        {
            return this.string_0;
        }
    }
}

