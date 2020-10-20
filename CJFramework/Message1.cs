using System;
using System.Net;

[Serializable]
internal class Message1 : IMessageHandler
{
    private IPEndPoint ipendPoint_0;
    private IHeader4 object_0;
    private string string_0;

    public Message1(IHeader4 interface27_0, string string_1, IPEndPoint ipendPoint_1)
    {
        this.object_0 = interface27_0;
        this.string_0 = string_1;
        this.ipendPoint_0 = ipendPoint_1;
    }

    public IPEndPoint imethod_0()
    {
        return this.ipendPoint_0;
    }

    public int imethod_1()
    {
        return this.string_0.Length;
    }

    public string method_0()
    {
        return this.string_0;
    }

    public object method_1()
    {
        return base.MemberwiseClone();
    }

    public void tangJphipJ(string string_1)
    {
        this.string_0 = string_1;
    }

    public byte[] ToStream()
    {
        return this.object_0.imethod_2().imethod_9(this.string_0);
    }

    public override string ToString()
    {
        return string.Format("MessageType:{0},UserID:{1},DestUserID:{2}", this.object_0.MessageType, this.object_0.UserID, this.object_0.DestUserID);
    }

    public IHeader Header
    {
        get
        {
            return (IHeader) this.object_0;
        }
    }
}

