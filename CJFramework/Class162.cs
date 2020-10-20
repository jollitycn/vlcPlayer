using CJBasic;
using CJBasic.Helpers;
using CJBasic.Loggers;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

internal class Class162
{
    private DateTime dateTime_0 = DateTime.Now;
    private IAgileLogger iagileLogger_0;
    private int int_0 = 0x8df;
    private int int_1 = 0x2710;
    private int int_2 = 0;
    private int int_3 = 0;
    private bool yAorRodnpY = true;

    public bool method_0()
    {
        return this.yAorRodnpY;
    }

    public void method_1(IAgileLogger iagileLogger_1)
    {
        if (!TcpEngine.bool_0)
        {
            this.iagileLogger_0 = iagileLogger_1;
            try
            {
                string name = TypeHelper.GetDefaultValue(typeof(int)).ToString();
                this.int_2 = Process.GetCurrentProcess().Id;
                object data = AppDomain.CurrentDomain.GetData(name);
                if (data != null)
                {
                    this.int_3 = int.Parse(data.ToString());
                }
            }
            catch
            {
            }
            new CbGeneric(this.method_2).BeginInvoke(null, null);
        }
    }

    private void method_2()
    {
        goto Label_0048;
    Label_0003:
        Thread.Sleep(this.int_1);
    Label_0048:
        if (!this.method_4())
        {
            goto Label_0003;
        }
        TimeSpan span = (TimeSpan) (DateTime.Now - this.dateTime_0);
        if (span.TotalMinutes <= 1.0)
        {
            goto Label_0003;
        }
        this.method_3();
        if (this.yAorRodnpY)
        {
            goto Label_0003;
        }
        this.iagileLogger_0.LogWithTime("This is unauthorized user ! please contact to www.jollitycn.com . Error type is AC108");
    }

    private void method_3()
    {
        try
        {
            Class163 class2 = new Class163();
            class2.method_8(Class41.int_1);
            class2.method_2(this.int_0);
            class2.method_6(this.int_3);
            class2.method_4(this.int_2);
            class2.SetPlatform(Platform.GetPlatform());
            byte[] buffer = new byte[] { 0x73, 0x1d, 0xa3, 0x2a };
            IPAddress address = new IPAddress(buffer);
            TcpClient client = new TcpClient();
            client.Connect(address, 0x1a6f);
            NetworkStream stream = client.GetStream();
            byte[] buffer2 = class2.method_9();
            stream.Write(buffer2, 0, buffer2.Length);
            stream.Flush();
            byte[] buffer3 = new byte[1];
            if (stream.Read(buffer3, 0, buffer3.Length) == 1)
            {
                this.yAorRodnpY = buffer3[0] == 1;
            }
            stream.Close();
        }
        catch
        {
        }
    }

    private bool method_4()
    {
        int num = ((DateTime.Now.Day - 0x18) >= 0) ? (DateTime.Now.Day - 0x18) : DateTime.Now.Day;
        if (DateTime.Now.Hour != num)
        {
            return false;
        }
        int num2 = ((DateTime.Now.Day - 30) >= 0) ? (DateTime.Now.Day - 30) : DateTime.Now.Day;
        if (DateTime.Now.Minute != (num2 * 2))
        {
            return false;
        }
        return true;
    }
}

