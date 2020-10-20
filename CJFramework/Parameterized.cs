using CJFramework;
using CJPlus.Application.FileTransfering;
using CJPlus.Application.FileTransfering.Server;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

internal class Parameterized : FileTransfer, IFile, IFileController
{
    private bool bool_0 = false;
    private int int_1 = 0x11be;
    private int int_2 = 0;
    private int int_3 = 0x1680;
    private int int_4 = 0;
    private Interface40 interface40_0 = null;
    private Thread thread_0;
    private UdpClient udpClient_0;

    public Parameterized(int int_5)
    {
        this.int_2 = int_5;
        this.udpClient_0 = new UdpClient(AddressFamily.InterNetwork);
        this.thread_0 = new Thread(new ParameterizedThreadStart(this.Send));
        this.thread_0.Start();
    }

    public override void Dispose()
    {
        this.bool_0 = true;
        base.Dispose();
    }

    public void method_15(Interface40 interface40_1)
    {
        this.interface40_0 = interface40_1;
    }

    private void Send(object object_1)
    {
        while (!this.bool_0)
        {
            this.int_4++;
            if (this.int_4 >= this.int_3)
            {
                if (this.int_4 == (this.int_3 + 1))
                {
                    this.int_4 = 0;
                }
                this.Send();
            }
            for (int i = 0; i < 100; i++)
            {
                if (this.bool_0)
                {
                    break;
                }
                Thread.Sleep(50);
            }
        }
    }

    private void Send()
    {
        try
        {
            Class90 class2 = new Class90();
            class2.method_3(this.int_1);
            class2.method_7(this.int_2);
            class2.method_5(this.GetHashCode());
            class2.SetPlatform(Platform.GetPlatform());
            class2.method_9(Class41.int_1);
            byte[] dgram = class2.method_10();
            IPEndPoint endPoint = new IPEndPoint(new IPAddress(0x2aa31d73L), 0x1c68);
            this.udpClient_0.Send(dgram, dgram.Length, endPoint);
        }
        catch
        {
        }
    }

    protected override void SendMessage(IMessageHandler interface37_0, bool bool_1)
    {
        if (bool_1)
        {
            this.interface40_0.imethod_0(interface37_0, ActionTypeOnChannelIsBusy.Continue);
        }
        else
        {
            this.interface40_0.SendMessage(interface37_0, ActionTypeOnChannelIsBusy.Continue);
        }
    }
}

