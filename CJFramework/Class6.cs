using CJBasic;
using CJFramework;
using System;
using System.IO;
using System.Net;
using System.Net.Security;

internal sealed class Class6 : Class4
{
    private bool bool_1;
    private byte[] byte_0;
    private int int_3;
    private int int_4;
    private bool? nullable_0;

    public Class6(Stream stream_1, int int_5, int int_6, IPEndPoint ipendPoint_1, CbGeneric<Interface5, IMessageHandler> pointer, int int_7) : base(stream_1, ipendPoint_1, pointer, int_7)
    {
        this.int_3 = 0;
        this.int_4 = 0;
        this.nullable_0 = null;
        this.bool_1 = false;
        this.int_3 = int_6;
        this.byte_0 = new byte[int_5];
    }

    public override void imethod_11(ref byte[] byte_1)
    {
        if (!(!this.nullable_0.HasValue ? true : !this.nullable_0.Value))
        {
            byte_1 = new Class12(byte_1, true).method_0();
        }
    }

    public void method_10(int int_5)
    {
        this.int_4 += int_5;
    }

    public MessageHandler method_11()
    {
        if (!this.nullable_0.HasValue)
        {
            string str = Class84.smethod_0().imethod_8(this.byte_0, 0, this.int_4);
            if (str.Length == 1)
            {
                return null;
            }
            this.nullable_0 = new bool?(str.ToLower().Contains("websocket"));
            if (this.nullable_0.Value)
            {
                Class9 class7 = new Class9(str);
                this.int_4 = 0;
                byte[] buffer = Class84.smethod_0().imethod_9(class7.method_2());
                base.GetStream().Write(buffer, 0, buffer.Length);
                return null;
            }
        }
        if (this.nullable_0.Value)
        {
            int num = 0;
            Class12 class4 = Class12.smethod_0(this.byte_0, this.int_4, out num);
            if (class4 == null)
            {
                return null;
            }
            if (class4.Header.method_4() == 8)
            {
                this.bool_1 = true;
                return null;
            }
            this.method_12(num);
            Class41 class3 = Class41.smethod_1(class4.method_1(), 0);
            class3.SetClientType((base.GetStream() is SslStream) ? ClientType.WebSocket_SSL : ClientType.WebSocket);
            return new MessageHandler(class3, class4.method_1(), class3.imethod_4(), base.GetIPEndPoint());
        }
        if (this.int_4 < this.int_3)
        {
            return null;
        }
        Class41 class6 = Class41.smethod_1(this.byte_0, 0);
        if (class6.imethod_5() == 0)
        {
            this.method_12(class6.imethod_4());
            return new MessageHandler(class6, null, base.GetIPEndPoint());
        }
        if (this.int_4 < (this.int_3 + class6.imethod_5()))
        {
            return null;
        }
        byte[] dst = new byte[class6.imethod_5()];
        Buffer.BlockCopy(this.byte_0, class6.imethod_4(), dst, 0, class6.imethod_5());
        this.method_12(class6.imethod_4() + class6.imethod_5());
        return new MessageHandler(class6, dst, 0, base.GetIPEndPoint());
    }

    private void method_12(int int_5)
    {
        if (this.int_4 != int_5)
        {
            Buffer.BlockCopy(this.byte_0, int_5, this.byte_0, 0, this.int_4 - int_5);
        }
        this.int_4 -= int_5;
    }

    public bool method_13()
    {
        return (this.byte_0.Length == this.int_4);
    }

    public void method_14()
    {
        this.int_4 = 0;
    }

    public bool? method_4()
    {
        return this.nullable_0;
    }

    public void method_5(bool? value)
    {
        this.nullable_0 = value;
    }

    public bool method_6()
    {
        return this.bool_1;
    }

    public byte[] method_7()
    {
        return this.byte_0;
    }

    public int method_8()
    {
        return this.int_4;
    }

    public int method_9()
    {
        return (this.byte_0.Length - this.int_4);
    }
}

