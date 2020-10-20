using CJBasic;
using CJBasic.Collections;
using CJFramework.Engine.Udp.Reliable;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

internal class Class100 : Interface17
{
    private bool bool_0 = false;
    private bool bool_1 = false;
    private byte byte_0 = 0;
    private Class101<DataFragmentBody> class101_0;
    private Class46<byte[]> class46_0 = new Class46<byte[]>();
    private DateTime dateTime_0 = DateTime.Now;
    private DateTime dateTime_1 = DateTime.Now;
    private int int_0 = 80;
    private int int_1 = 0;
    private int int_2 = 0;
    private int int_3 = 0;
    private int int_4 = 0;
    private IPv6 interface15_0;
    private IPEndPoint ipendPoint_0;
    private int object_0 = 0;
    private object object_1 = new object();
    private int object_2 = 0;
    private SortedArray<ulong> sortedArray_0 = new SortedArray<ulong>();
    private string string_0 = "";
    private ulong ulong_0 = 0L;
    private ulong ulong_1 = 0L;

    public event CbGeneric<Interface17, byte[]> Event_0;

    public event CbGeneric<Interface17, SessionClosedCause> SessionClosed;

    public Class100(IPv6 interface15_1, byte byte_1, IPEndPoint ipendPoint_1, string string_1, int int_5)
    {
        this.interface15_0 = interface15_1;
        this.byte_0 = byte_1;
        this.ipendPoint_0 = ipendPoint_1;
        this.string_0 = string_1;
        this.class101_0 = new Class101<DataFragmentBody>(int_5, 1L);
        this.class46_0.method_0(100, new CbGeneric<byte[]>(this.method_0));
    }

    public void Close(SessionClosedCause sessionClosedCause_0, bool bool_2)
    {
        if (this.object_0 == 0)
        {
            this.object_0 = 1;
            if (bool_2 && (this.SessionClosed != null))
            {
                this.SessionClosed(this, sessionClosedCause_0);
            }
        }
    }

    public bool imethod_0()
    {
        return false;
    }

    public IPEndPoint imethod_1()
    {
        return this.ipendPoint_0;
    }

    public string imethod_2()
    {
        return this.string_0;
    }

    private void method_0(byte[] byte_1)
    {
        if (this.Event_0 != null)
        {
            this.Event_0(this, byte_1);
        }
    }

    public byte method_1()
    {
        return this.byte_0;
    }

    private void method_10()
    {
        byte[] buffer;
        if (this.class46_0.method_3() || this.bool_1)
        {
            return;
        }
        lock (this.object_1)
        {
            if (this.bool_1)
            {
                return;
            }
            this.bool_1 = true;
            goto Label_0061;
        }
    Label_0045:
        buffer = this.method_11();
        if (buffer == null)
        {
            goto Label_0071;
        }
        this.class46_0.method_4(buffer);
    Label_0061:
        if (!this.class46_0.method_3())
        {
            goto Label_0045;
        }
    Label_0071:
        this.bool_1 = false;
    }

    private byte[] method_11()
    {
        DataFragmentBody class2 = this.class101_0.method_6();
        if (class2 == null)
        {
            return null;
        }
        if (class2.GetDataFragmentType() == ((DataFragmentType) 0))
        {
            this.class101_0.method_5();
            return class2.method_2().GetPureData();
        }
        if (class2.GetDataFragmentType() != ((DataFragmentType) 1))
        {
            throw new CJException(string.Format("DataFragmentType is Wrong ! DatagramID:{0} ,DataFragmentType:{1} ,CountInCache:{2}", class2.method_0(), (int) class2.GetDataFragmentType(), this.class101_0.method_3()));
        }
        bool flag = false;
        int length = class2.method_2().Length;
        uint num4 = 2;
        DataFragmentBody class3 = this.class101_0.method_7((this.class101_0.method_2() + ((ulong) 2L)) - ((ulong) 1L));
        while (class3 != null)
        {
            length += class3.method_2().Length;
            if (class3.GetDataFragmentType() == ((DataFragmentType) 3))
            {
                flag = true;
                break;
            }
            num4++;
            class3 = this.class101_0.method_7((this.class101_0.method_2() + num4) - ((ulong) 1L));
        }
        if (!flag)
        {
            return null;
        }
        byte[] dst = new byte[length];
        int dstOffset = 0;
        for (uint i = 0; i < num4; i++)
        {
            class3 = this.class101_0.method_5();
            Buffer.BlockCopy(class3.method_2().Data, class3.method_2().Offset, dst, dstOffset, class3.method_2().Length);
            dstOffset += class3.method_2().Length;
        }
        this.ulong_0 = this.class101_0.method_2() - ((ulong) 1L);
        return dst;
    }

    public void method_12(int int_5)
    {
        ulong num;
        ulong num2;
        List<ulong> collection = this.class101_0.method_8(50, out num, out num2);
        if (collection.Count == 1)
        {
            if (collection[0] == this.ulong_1)
            {
                this.int_4 += int_5;
                if (this.int_4 >= 0x7d0)
                {
                    this.method_13(num, num2, collection.ToArray());
                    this.int_4 = 0;
                }
            }
            else
            {
                this.ulong_1 = collection[0];
                this.int_4 = 0;
                this.method_13(num, num2, collection.ToArray());
            }
        }
        else
        {
            this.int_2 += int_5;
            this.int_1 += int_5;
            if (this.int_1 >= this.int_0)
            {
                this.method_13(num, num2, collection.ToArray());
                this.sortedArray_0.Add(collection);
                this.int_3 += collection.Count;
                this.int_1 = 0;
            }
            if (this.int_2 >= 0x7d0)
            {
                this.method_14();
                this.int_2 = 0;
                this.int_3 = 0;
                this.sortedArray_0.Clear();
            }
        }
    }

    private void method_13(ulong ulong_2, ulong ulong_3, ulong[] ulong_4)
    {
        byte[] buffer = Class156.IHeader4(ulong_2, ulong_3, ulong_4).method_0();
        this.interface15_0.Send(buffer, this.ipendPoint_0);
    }

    private void method_14()
    {
        if (this.sortedArray_0.Count > 1)
        {
            int num2 = 10;
            int num3 = 0x3e8;
            float num = ((float) this.int_3) / ((float) (this.sortedArray_0.Count * 2.5));
            if (num < 0.9)
            {
                num = 0.9f;
            }
            if (num > 1.2)
            {
                num = 1.2f;
            }
            this.int_0 = (int) (num * this.int_0);
            if (this.int_0 > num3)
            {
                this.int_0 = num3;
            }
            if (this.int_0 < num2)
            {
                this.int_0 = num2;
            }
        }
    }

    public FeedbackVacancyBody method_15()
    {
        ulong num;
        ulong num2;
        if (this.bool_0)
        {
            return null;
        }
        List<ulong> list = this.class101_0.method_8(50, out num, out num2);
        if ((num == 0L) && (num2 == 0L))
        {
            return null;
        }
        if (list.Count == 1)
        {
            if (this.object_2 >= 50)
            {
                this.object_2 = 0;
                return new FeedbackVacancyBody(num, num2, list.ToArray());
            }
            this.object_2 += 1;
            return null;
        }
        this.object_2 = 0;
        return new FeedbackVacancyBody(num, num2, list.ToArray());
    }

    public InUdpSessionState method_16()
    {
        ulong num;
        ulong num2;
        this.class101_0.method_8(1, out num, out num2);
        return new InUdpSessionState(this.byte_0, this.ipendPoint_0, this.string_0, this.dateTime_0, this.int_0, num, num2, this.class101_0.method_3());
    }

    public void method_17()
    {
        TimeSpan span = (TimeSpan) (DateTime.Now - this.dateTime_1);
        if (span.TotalSeconds > 30.0)
        {
            this.Close(SessionClosedCause.HeartBeatTimeout, true);
        }
    }

    public bool method_2()
    {
        return this.object_0 == 1;
    }

    public DateTime method_3()
    {
        return this.dateTime_0;
    }

    public int method_4()
    {
        return this.int_0;
    }

    public DateTime method_5()
    {
        return this.dateTime_1;
    }

    internal bool method_6()
    {
        return this.bool_0;
    }

    internal void method_7(bool bool_2)
    {
        this.bool_0 = bool_2;
    }

    public void method_8(DataFragmentBody class150_0)
    {
        this.dateTime_1 = DateTime.Now;
        this.class101_0.method_4(class150_0.method_0(), class150_0);
        if (this.class101_0.method_6() != null)
        {
            this.method_10();
        }
    }

    public void method_9()
    {
        this.dateTime_1 = DateTime.Now;
    }
}

