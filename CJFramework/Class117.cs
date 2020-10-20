using CJBasic;
using CJBasic.Loggers;
using System;
using System.Threading;

internal class Class117
{
    private bool bool_0;
    private bool bool_1;
    private bool bool_2;
    private bool bool_3;
    private Class119 class119_0;
    private DateTime dateTime_0;
    private ClientTimeEnum enum0_0;
    private IAgileLogger iagileLogger_0;
    private int int_0;
    private int int_1;
    private int int_2;
    private int int_3;
    private int int_4;
    private bool? nullable_0;
    private int object_0;
    protected string string_0;
    protected string string_1;
    protected string string_2;

    internal event CbGeneric<bool, bool> Event_0;

    internal static  event CbGeneric<int> Event_1;

    internal Class117()
    {
        this.string_0 = "http://59.175.145.163/AuthorizeService.asmx";
        this.string_1 = "http://ws.oraycn.com/AuthorizeService.asmx";
        this.bool_0 = true;
        this.bool_1 = true;
        this.string_2 = "";
        this.int_0 = 0x1d4c0;
        this.object_0 = 1;
        this.int_1 = 30;
        this.int_2 = 0;
        this.nullable_0 = null;
        this.dateTime_0 = DateTime.Now;
        this.int_3 = 0;
        this.int_4 = 0;
        this.bool_2 = false;
        this.bool_3 = false;
    }

    internal Class117(string string_3, ClientTimeEnum enum0_1, IAgileLogger iagileLogger_1, Class119 class119_1)
    {
        this.string_0 = "http://59.175.145.163/AuthorizeService.asmx";
        this.string_1 = "http://ws.oraycn.com/AuthorizeService.asmx";
        this.bool_0 = true;
        this.bool_1 = true;
        this.string_2 = "";
        this.int_0 = 0x1d4c0;
        this.object_0 = 1;
        this.int_1 = 30;
        this.int_2 = 0;
        this.nullable_0 = null;
        this.dateTime_0 = DateTime.Now;
        this.int_3 = 0;
        this.int_4 = 0;
        this.bool_2 = false;
        this.bool_3 = false;
        this.string_2 = string_3;
        this.enum0_0 = enum0_1;
        this.iagileLogger_0 = iagileLogger_1;
        this.class119_0 = class119_1;
    }

    public bool method_0()
    {
        return (this.bool_0 && this.bool_1);
    }

    private void method_1(bool bool_4, bool bool_5)
    {
        if ((this.bool_0 != bool_4) || (this.bool_1 != bool_5))
        {
            this.bool_0 = bool_4;
            this.bool_1 = bool_5;
            if (this.Event_0 != null)
            {
                this.Event_0(this.bool_0, this.bool_1);
            }
        }
    }

    internal void method_2()
    {
        this.object_0 = 0;
        new CbGeneric(this.method_5).BeginInvoke(null, null);
    }

    internal void method_3()
    {
        if (this.object_0 == 0)
        {
            this.object_0 = 1;
            try
            {
                this.method_4(this.string_0);
            }
            catch (Exception)
            {
                try
                {
                    this.method_4(this.string_1);
                }
                catch (Exception)
                {
                }
            }
        }
    }

    private void method_4(string string_3)
    {
        Class92.smethod_0(string_3, "UnregisterInstance", new object[] { Platform.string_0, this.string_2, Class30.int_0 });
    }

    private void method_5()
    {
        this.int_1 = new Random().Next(5, 40);
        Thread.Sleep(0x1adb0);
        while (this.object_0 == 0)
        {
            TimeSpan span;
            bool flag = true;
            try
            {
                flag = this.method_9(this.string_0);
                this.dateTime_0 = DateTime.Now;
            }
            catch (Exception)
            {
                try
                {
                    flag = this.method_9(this.string_1);
                    this.dateTime_0 = DateTime.Now;
                }
                catch (Exception)
                {
                    flag = true;
                }
            }
            bool flag2 = true;
            if (this.enum0_0 == ((ClientTimeEnum) 2))
            {
                flag2 = this.method_6();
            }
            if (this.enum0_0 == ((ClientTimeEnum) 1))
            {
                span = (TimeSpan) (DateTime.Now - this.dateTime_0);
                if (span.TotalDays >= 2.0)
                {
                    flag = false;
                    if (this.bool_0)
                    {
                        this.iagileLogger_0.LogWithTime("Current server is not authorized ! [days expired]");
                    }
                }
            }
            if ((this.enum0_0 == ((ClientTimeEnum) 3)) && (this.int_2 >= this.int_1))
            {
                if (!this.nullable_0.HasValue)
                {
                    this.nullable_0 = this.class119_0.method_0();
                }
                else if (this.nullable_0.Value)
                {
                    flag = false;
                }
            }
            if (((this.enum0_0 == ((ClientTimeEnum) 4)) || (this.enum0_0 == ((ClientTimeEnum) 2))) && (Platform.string_0 == "CJFramework"))
            {
                span = (TimeSpan) (DateTime.Now - this.dateTime_0);
                int totalDays = (int) span.TotalDays;
                if (totalDays > this.int_3)
                {
                    this.int_3 = totalDays;
                    if (Event_1 != null)
                    {
                        try
                        {
                            Event_1(Class30.int_0);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            this.method_1(flag, flag2);
            Thread.Sleep(this.int_0);
            this.int_2++;
        }
    }

    private bool method_6()
    {
        string str = null;
        if (!this.bool_2)
        {
            bool flag2;
            this.bool_2 = true;
            if (flag2 = Class44.smethod_0(this.string_2, out str))
            {
                this.bool_3 = true;
            }
            return flag2;
        }
        if (Class44.smethod_0(this.string_2, out str))
        {
            this.bool_3 = true;
            this.int_4 = 0;
            return true;
        }
        if (!this.bool_3)
        {
            return false;
        }
        this.int_4++;
        if (this.int_4 >= 15)
        {
            return false;
        }
        return true;
    }

    internal bool method_7()
    {
        DateTime now = DateTime.Now;
        try
        {
            DateTime time2 = (DateTime) Class92.smethod_0(this.string_0, "GetTime", null);
            return true;
        }
        catch
        {
        }
        try
        {
            DateTime time3 = (DateTime) Class92.smethod_0(this.string_1, "GetTime", null);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    internal void method_8(int int_5, string string_3, int int_6)
    {
        string_3 = string.Format("{0}-{1}", string_3, Class41.int_1);
        try
        {
            Class92.smethod_0(this.string_0, "ClientCallAuth", new object[] { Platform.string_0, AuthorizeTool.smethod_0().string_1, int_5, string_3, int_6 });
        }
        catch
        {
            try
            {
                Class92.smethod_0(this.string_1, "ClientCallAuth", new object[] { Platform.string_0, AuthorizeTool.smethod_0().string_1, int_5, string_3, int_6 });
            }
            catch
            {
            }
        }
    }

    private bool method_9(string string_3)
    {
        return (bool) Class92.smethod_0(string_3, "CheckAuthorizedUser", new object[] { Class30.int_0, Platform.string_0, Class30.string_2, this.string_2, "", Class30.string_0, Class30.string_1 });
    }
}

