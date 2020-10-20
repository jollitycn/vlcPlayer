using CJBasic;
using CJBasic.Collections;
using CJFramework.Engine.Udp.Reliable;
using System;
using System.Net;
using System.Threading;

internal class Class116 : Interface17
{
    private bool bool_0 = false;
    private Class161<Class145> class161_0 = new Class161<Class145>(500, 1L);
    private DateTime dateTime_0 = DateTime.Now;
    private DateTime dateTime_1 = DateTime.Now;
    private FeedbackVacancyBody feedbackVacancyBody_0 = new FeedbackVacancyBody(0L, 0L, new ulong[0]);
    private int int_0 = 500;
    private int int_1 = 520;
    private int int_2 = 20;
    private int int_3 = 0;
    private int int_4 = 0;
    private IPv6 interface15_0;
    private IPEndPoint ipendPoint_0;
    private object object_0 = new object();
    private bool  object_1 = false;
    private object object_2 = new object();
    private SortedArray<ulong> sortedArray_0 = new SortedArray<ulong>();
    private SortedArray<ulong> sortedArray_1 = new SortedArray<ulong>();
    private string string_0 = "";
    private uint uint_0 = 0;
    private ulong ulong_0 = 0L;
    private ulong ulong_1 = 0L;
    private ushort ushort_0 = 0x240;

    public event CbGeneric<Interface17, SessionClosedCause> SessionClosed;

    public Class116(IPv6 interface15_1, IPEndPoint ipendPoint_1, string string_1, int int_5)
    {
        this.interface15_0 = interface15_1;
        this.ipendPoint_0 = ipendPoint_1;
        this.string_0 = string_1;
        this.int_0 = int_5;
        new CbGeneric(this.method_13).BeginInvoke(null, null);
    }

    public void Close(SessionClosedCause sessionClosedCause_0, bool bool_1)
    {
        if (this.object_1 == false)
        {
            this.object_1 = true;
            if (bool_1 && (this.SessionClosed != null))
            {
                this.SessionClosed(this, sessionClosedCause_0);
            }
        }
    }

    public bool imethod_0()
    {
        return true;
    }

    public IPEndPoint imethod_1()
    {
        return this.ipendPoint_0;
    }

    public string imethod_2()
    {
        return this.string_0;
    }

    public bool method_0()
    {
        return (bool) this.object_1;
    }

    public DateTime method_1()
    {
        return this.dateTime_0;
    }

    private bool method_10(int int_5)
    {
        //   return (this.method_11(int_5) || (((( this.ulong_0 + int_5) - this.feedbackVacancyBody_0.MinIDInReceivedCache) >= this.int_0));
        return false;
    }

    public bool method_11(int int_5)
    {
        return ((this.class161_0.method_4() >= this.int_2) || this.class161_0.method_2(int_5));
    }

    private void method_12(ulong ulong_2, byte[] byte_0, int int_5, int int_6, DataFragmentType enum8_0)
    {
        DataBuffer buffer = new DataBuffer(byte_0, int_5, int_6);
        byte[] buffer2 = Class156.IHeader2(ulong_2, buffer, enum8_0).method_0();
        this.class161_0.vgxruqcnr8(ulong_2, new Class145(buffer2, ulong_2));
        this.interface15_0.Send(buffer2, this.ipendPoint_0);
        this.int_4++;
    }

    private void method_13()
    {
        for (int i = 0; i < MTUs.MTUValueArrayInAscOrder.Length; i++)
        {
            ushort num2 = MTUs.MTUValueArrayInAscOrder[i];
            Thread.Sleep(400);
            this.method_14(num2);
            Thread.Sleep(100);
            this.method_14(num2);
        }
    }

    public void method_14(ushort ushort_1)
    {
        ushort num = (ushort) ((ushort_1 - 40) - 4);
        byte[] buffer = Class156.IHeader7(num).method_0();
        this.interface15_0.Send(buffer, this.ipendPoint_0);
    }

    public void method_15(ushort ushort_1)
    {
        lock (this.object_0)
        {
            if (ushort_1 > this.ushort_0)
            {
                this.ushort_0 = ushort_1;
                this.int_1 = ((this.ushort_0 - 40) - 4) - DataFragmentBody.int_0;
            }
        }
    }

    public void method_16(int int_5)
    {
        if (this.object_1 ==false)
        {
            Class145 class2 = this.class161_0.method_10();
            if (class2 != null)
            {
                TimeSpan span = (TimeSpan) (DateTime.Now - class2.method_2());
                if (span.TotalSeconds > 30.0)
                {
                    this.Close(SessionClosedCause.ResendTimeout, true);
                    return;
                }
                this.interface15_0.Send(class2.method_1(), this.ipendPoint_0);
                this.uint_0++;
            }
            this.int_3 += int_5;
            if (this.int_3 >= 0x2710)
            {
                this.method_17();
                this.int_3 = 0;
                this.ulong_1 = this.uint_0;
                this.int_4 = 0;
            }
        }
    }

    private void method_17()
    {
        int num = (int) (this.uint_0 - this.ulong_1);
        if ((this.int_4 != 0) || (num != 0))
        {
            if (this.int_4 == 0)
            {
                this.int_2 = (int) (this.int_2 * 0.8);
            }
            else if (num == 0)
            {
                this.int_2 = (int) (this.int_2 * 1.2);
            }
            else
            {
                float num3 = ((float) this.int_4) / ((float) (num * 2));
                if (num3 < 0.9)
                {
                    num3 = 0.9f;
                }
                if (num3 > 1.2)
                {
                    num3 = 1.2f;
                }
                this.int_2 = (int) (this.int_2 * num3);
            }
        }
        if (this.int_2 > 200)
        {
            this.int_2 = 200;
        }
        if (this.int_2 < 20)
        {
            this.int_2 = 20;
        }
        int num2 = 100;
        if ((this.ushort_0 >= 0x1100) && (this.int_2 < num2))
        {
            this.int_2 = num2;
        }
    }

    public void method_18(FeedbackVacancyBody feedbackVacancyBody_1, bool bool_1)
    {
        this.dateTime_1 = DateTime.Now;
        if (bool_1)
        {
            this.bool_0 = true;
        }
        if (feedbackVacancyBody_1.MinIDInReceivedCache >= this.feedbackVacancyBody_0.MinIDInReceivedCache)
        {
            this.feedbackVacancyBody_0 = feedbackVacancyBody_1;
            this.method_19(feedbackVacancyBody_1.MinIDInReceivedCache, feedbackVacancyBody_1.MaxIDInReceivedCache, feedbackVacancyBody_1.VacancyIDArray);
        }
    }

    private void method_19(ulong ulong_2, ulong ulong_3, ulong[] ulong_4)
    {
        if (ulong_4.Length != 0)
        {
            lock (this.object_2)
            {
                for (int i = 0; i < ulong_4.Length; i++)
                {
                    ulong num2 = ulong_4[i];
                    if (i == 0)
                    {
                        this.class161_0.method_5(num2 - ((ulong) 1L));
                    }
                    Class145 class2 = this.class161_0.method_8(num2);
                    if ((class2 != null) && !this.sortedArray_0.Contains(num2))
                    {
                        this.interface15_0.Send(class2.method_1(), this.ipendPoint_0);
                        this.sortedArray_1.Add(num2);
                        this.uint_0++;
                    }
                    if (i < (ulong_4.Length - 1))
                    {
                        this.class161_0.sJirjHxlxv(num2 + ((ulong) 1L), ulong_4[i + 1] - ((ulong) 1L));
                    }
                }
                SortedArray<ulong> array = this.sortedArray_0;
                this.sortedArray_0 = this.sortedArray_1;
                this.sortedArray_1 = array;
                this.sortedArray_1.Clear();
            }
        }
    }

    public int method_2()
    {
        return this.int_2;
    }

    public OutUdpSessionState method_20()
    {
        ulong num = 0L;
        Class145 class2 = this.class161_0.method_10();
        if (class2 != null)
        {
            num = class2.method_0();
        }
        return new OutUdpSessionState(this.ipendPoint_0, this.string_0, this.dateTime_0, this.int_2, this.class161_0.method_4(), num, (ulong) this.uint_0, this.ulong_0, this.feedbackVacancyBody_0.MaxIDInReceivedCache, 0, this.ushort_0, 0L, 0L, 0L);
    }

    public void method_21()
    {
        TimeSpan span = (TimeSpan) (DateTime.Now - this.dateTime_1);
        if (span.TotalSeconds > 30.0)
        {
            this.Close(SessionClosedCause.FeedbackTimeout, true);
        }
    }

    public void method_22()
    {
        byte[] buffer = Class156.IHeader6().method_0();
        this.interface15_0.Send(buffer, this.ipendPoint_0);
    }

    public uint method_3()
    {
        return this.uint_0;
    }

    public bool method_4()
    {
        return this.bool_0;
    }

    public DateTime method_5()
    {
        return this.dateTime_1;
    }

    public ushort method_6()
    {
        return this.ushort_0;
    }

    public void method_7(byte[] byte_0)
    {
        if (this.object_1 == false)
        {
            lock (this.object_0)
            {
                this.method_8(byte_0);
            }
        }
    }

    private void method_8(byte[] byte_0)
    {
        if (byte_0.Length <= this.int_1)
        {
            this.method_9(byte_0, 0, byte_0.Length, (DataFragmentType) 0);
        }
        else
        {
            int num2 = (byte_0.Length / this.int_1) + (((byte_0.Length % this.int_1) == 0) ? 0 : 1);
            for (int i = 0; i < num2; i++)
            {
                if (i < (num2 - 1))
                {
                    DataFragmentType enum2 = (i == 0) ? ((DataFragmentType) 1) : ((DataFragmentType) 2);
                    this.method_9(byte_0, i * this.int_1, this.int_1, enum2);
                }
                else
                {
                    this.method_9(byte_0, i * this.int_1, byte_0.Length - (i * this.int_1), (DataFragmentType) 3);
                }
            }
        }
    }

    private void method_9(byte[] byte_0, int int_5, int int_6, DataFragmentType enum8_0)
    {
        if (this.object_1 == false)
        {
            while (this.method_10(1))
            {
                Thread.Sleep(2);
                if (this.object_1 != false)
                {
                    return;
                }
            }
            if ((this.ulong_0 != 0L) || ((enum8_0 != ((DataFragmentType) 2)) && (enum8_0 != ((DataFragmentType) 3))))
            {
                this.ulong_0 += (ulong) 1L;
                try
                {
                    this.method_12(this.ulong_0, byte_0, int_5, int_6, enum8_0);
                }
                catch (Exception)
                {
                    this.Close(SessionClosedCause.SocketException, true);
                }
            }
        }
    }
}

