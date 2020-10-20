using CJBasic;
using System;
using System.Net;

[Serializable]
internal class MessageHandler : IMessageHandler
{
    private DataBuffer dataBuffer_0;
    private IPEndPoint ipendPoint_0;
    private Interface22 object_0;

    public MessageHandler(Interface22 interface22_0, DataBuffer dataBuffer_1, IPEndPoint ipendPoint_1)
    {
        this.object_0 = interface22_0;
        this.dataBuffer_0 = dataBuffer_1;
        this.ipendPoint_0 = ipendPoint_1;
        if (this.object_0.imethod_5() == 0)
        {
            this.dataBuffer_0 = null;
        }
    }

    public MessageHandler(Interface22 interface22_0, byte[] byte_0, int int_0, IPEndPoint ipendPoint_1)
    {
        this.object_0 = interface22_0;
        this.ipendPoint_0 = ipendPoint_1;
        if (byte_0 != null)
        {
            this.dataBuffer_0 = new DataBuffer(byte_0, int_0, interface22_0.imethod_5());
        }
    }

    public IPEndPoint imethod_0()
    {
        return this.ipendPoint_0;
    }

    public int imethod_1()
    {
        return (this.object_0.imethod_4() + this.object_0.imethod_5());
    }

    public Interface22 method_0()
    {
        return (Interface22) this.object_0;
    }

    public void method_1(Interface22 interface22_0)
    {
        this.object_0 = interface22_0;
    }

    public object method_2()
    {
        return base.MemberwiseClone();
    }

    public byte[] ToStream()
    {
        byte[] buffer = new byte[this.object_0.imethod_4() + this.object_0.imethod_5()];
        this.object_0.ToStream(buffer, 0);
        if (this.object_0.imethod_5() > 0)
        {
            Buffer.BlockCopy(this.dataBuffer_0.Data, this.dataBuffer_0.Offset, buffer, this.object_0.imethod_4(), this.object_0.imethod_5());
        }
        return buffer;
    }

    public override string ToString()
    {
        return string.Format("MessageType:{0},UserID:{1},DestUserID:{2}", this.object_0.MessageType, this.object_0.UserID, this.object_0.DestUserID);
    }

    public DataBuffer Body
    {
        get
        {
            return this.dataBuffer_0;
        }
        set
        {
            this.dataBuffer_0 = value;
        }
    }

    public IHeader Header
    {
        get
        {
            return (IHeader) this.object_0;
        }
    }
}

