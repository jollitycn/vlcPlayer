using CJBasic;
using CJFramework.Engine.Udp.Reliable;
using System;
using System.Net;

internal class Class156
{
    private static byte byte_0 = ((byte) new Random().Next(1, 0xff));
    private IHeader1 class146_0;
    private IBody class147_0;

    public Class156(IHeader1 class146_1, IBody interface47_0)
    {
        this.class146_0 = class146_1;
        this.class147_0 = interface47_0 ?? new Body();
    }

    public byte[] method_0()
    {
        byte[] buffer = new byte[4 + this.class147_0.BodyTotalLength];
        this.class146_0.method_6(buffer);
        this.class147_0.ToStream(buffer, 4);
        return buffer;
    }

    public static Class156 IHeader2(ulong ulong_0, DataBuffer dataBuffer_0, DataFragmentType enum8_0)
    {
        DataFragmentBody class2 = new DataFragmentBody(ulong_0, dataBuffer_0, enum8_0);
        return new Class156(new IHeader1(2, byte_0, (ushort) class2.BodyTotalLength), class2);
    }

    public static Class156 IHeader0(string string_0, IPEndPoint ipendPoint_0)
    {
        IPEndPointBody class2 = new IPEndPointBody(string_0, ipendPoint_0.Address.ToString(), ipendPoint_0.Port);
        return new Class156(new IHeader1(0, byte_0, (ushort) class2.BodyTotalLength), class2);
    }

    public static Class156 IHeader1(string string_0)
    {
        StringBody class2 = new StringBody(string_0);
        return new Class156(new IHeader1(1, byte_0, (ushort) class2.BodyTotalLength), class2);
    }

    public static Class156 IHeader4(ulong ulong_0, ulong ulong_1, ulong[] ulong_2)
    {
        FeedbackVacancyBody body = new FeedbackVacancyBody(ulong_0, ulong_1, ulong_2);
        return new Class156(new IHeader1(4, byte_0, (ushort) body.BodyTotalLength), body);
    }

    public static Class156 IHeader5()
    {
        Body class2 = new Body();
        return new Class156(new IHeader1(5, byte_0, (ushort) class2.BodyTotalLength), class2);
    }

    public static Class156 IHeader6()
    {
        DateTimeBody class2 = new DateTimeBody();
        return new Class156(new IHeader1(6, byte_0, (ushort) class2.BodyTotalLength), class2);
    }

    public static Class156 IHeader7(ushort ushort_0)
    {
        Class154 class2 = new Class154(ushort_0);
        return new Class156(new IHeader1(7, byte_0, (ushort) class2.BodyTotalLength), class2);
    }

    public IBody Body
    {
        get
        {
            return this.class147_0;
        }
    }

    public IHeader1 Header
    {
        get
        {
            return this.class146_0;
        }
    }
}

