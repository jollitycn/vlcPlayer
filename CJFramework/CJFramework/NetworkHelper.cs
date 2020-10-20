namespace CJFramework
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Text.RegularExpressions;

    public static class NetworkHelper
    {
        public static string GetFirstIP()
        {
            List<string> list = smethod_1(AddressFamily.InterNetwork);
            if (list.Count == 0)
            {
                return null;
            }
            return list[0];
        }

        public static byte[] ReceiveData(Stream stream, int size)
        {
            byte[] buff = new byte[size];
            ReceiveData(stream, buff, 0, size);
            return buff;
        }

        public static void ReceiveData(Stream stream, byte[] buff, int offset, int size)
        {
            int num = 0;
            int num2 = 0;
            int num3 = offset;
            while (num2 < size)
            {
                int count = size - num2;
                num = stream.Read(buff, num3, count);
                if (num == 0)
                {
                    throw new IOException("NetworkStream Interruptted !");
                }
                num3 += num;
                num2 += num;
            }
        }

        public static List<string> smethod_0()
        {
            IPAddress[] hostAddresses = Dns.GetHostAddresses(Dns.GetHostName());
            List<string> list = new List<string>();
            foreach (IPAddress address in hostAddresses)
            {
                list.Add(address.ToString());
            }
            return list;
        }

        public static List<string> smethod_1(AddressFamily family)
        {
            IPAddress[] hostAddresses = Dns.GetHostAddresses(Dns.GetHostName());
            List<string> list = new List<string>();
            foreach (IPAddress address in hostAddresses)
            {
                if (address.AddressFamily == family)
                {
                    list.Add(address.ToString());
                }
            }
            return list;
        }

        public static ushort smethod_2()
        {
            try
            {
                int num = 0xffff;
                NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                int index = 0;
                while (true)
                {
                    if (index >= allNetworkInterfaces.Length)
                    {
                        break;
                    }
                    NetworkInterface interface2 = allNetworkInterfaces[index];
                    if (interface2.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                    {
                        try
                        {
                            IPv4InterfaceProperties properties = interface2.GetIPProperties().GetIPv4Properties();
                            if (properties != null)
                            {
                                num = Math.Min(num, properties.Mtu);
                            }
                        }
                        catch
                        {
                        }
                    }
                    index++;
                }
                return (ushort) num;
            }
            catch (Exception)
            {
                return 0x240;
            }
        }

        public static bool smethod_3(string txt)
        {
            return Regex.IsMatch(txt, @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])((\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])){3}|(\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])){5})$");
        }
    }
}

