using CJBasic;
using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

internal class Class51
{
    private bool bool_0 = false;
    private bool bool_1 = true;
    private static Class51 class51_0 = null;
    private int int_0 = 1;
    private int int_1 = 0x2710;
    private int int_2 = 0x1e61;
    private int int_3 = 0;
    private int int_4 = 0;
    private int int_5 = 0;
    private int int_6 = 0;
    private int int_7 = 1;
    private int int_8 = 2;
    private int[] int_9 = new int[] { 20, 0x1c, 0x24, 0x2c, 0x34, 60, 0x44, 0x4c, 4, 12 };
    private NetworkStream object_0;
    private object object_1 = new object();
    private object object_2 = new object();
    private string string_0 = "12630963";
    private string string_1 = "127.0.0.1";

    public Class51()
    {
        this.int_1 = Class44.int_0;
        this.string_1 = Class62.string_3;
        Random random = new Random();
        this.int_3 = random.Next(0x3e8, 0x7d0);
        this.int_4 = random.Next(0x3e8);
        this.int_5 = random.Next(100);
    }

    public bool method_0()
    {
        try
        {
            bool flag;
            this.object_0 = new Class85(this.string_1, this.int_2).method_12();
            this.bool_0 = true;
            if (flag = this.method_5())
            {
                new CbGeneric(this.method_2).BeginInvoke(null, null);
            }
            return flag;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool method_1()
    {
        return this.bool_1;
    }

    private byte[] method_10(byte[] byte_0, string string_2)
    {
        DESCryptoServiceProvider provider = new DESCryptoServiceProvider {
            Padding = PaddingMode.None,
            Mode = CipherMode.ECB,
            Key = Encoding.ASCII.GetBytes(string_2),
            IV = Encoding.ASCII.GetBytes(string_2)
        };
        return provider.CreateDecryptor().TransformFinalBlock(byte_0, 0, byte_0.Length);
    }

    private void method_2()
    {
        while (true)
        {
            try
            {
                Thread.Sleep(0x2710);
                this.bool_1 = this.method_6();
            }
            catch (Exception)
            {
                this.method_3();
            }
        }
    }

    private void method_3()
    {
        this.bool_0 = false;
        this.object_0.Close();
        this.method_4();
    }

    private void method_4()
    {
        lock (this.object_2)
        {
            if (!this.bool_0)
            {
                while (true)
                {
                    try
                    {
                        this.object_0 = new Class85(this.string_1, this.int_2).method_12();
                        this.bool_0 = true;
                        break;
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(0x1388);
                    }
                }
            }
        }
    }

    public bool method_5()
    {
        object obj2;
        bool flag;
        Monitor.Enter(obj2 = this.object_1);
        try
        {
            if (!this.bool_0)
            {
                return false;
            }
            this.int_4++;
            Class53 class3 = new Class53 {
                int_0 = this.int_3,
                int_6 = this.int_4,
                int_7 = this.int_0,
                int_8 = this.int_1,
                int_9 = 0
            };
            byte[] src = class3.method_0();
            byte[] dst = new byte[4 + src.Length];
            Buffer.BlockCopy(BitConverter.GetBytes(this.int_7), 0, dst, 0, 4);
            Buffer.BlockCopy(src, 0, dst, 4, src.Length);
            byte[] buffer5 = this.method_9(dst, this.string_0);
            byte[] buffer6 = new byte[buffer5.Length + 8];
            byte[] bytes = BitConverter.GetBytes(buffer5.Length);
            byte[] buffer8 = BitConverter.GetBytes(this.int_0);
            Buffer.BlockCopy(bytes, 0, buffer6, 0, 4);
            Buffer.BlockCopy(buffer8, 0, buffer6, 4, 4);
            Buffer.BlockCopy(buffer5, 0, buffer6, 8, buffer5.Length);
            this.object_0.Write(buffer6, 0, buffer6.Length);
            int num = BitConverter.ToInt32(this.method_7((NetworkStream) this.object_0, 8), 0);
            byte[] buffer10 = this.method_7((NetworkStream) this.object_0, num);
            byte[] buffer = this.method_10(buffer10, this.string_0);
            if (BitConverter.ToInt32(buffer, 0) != this.int_8)
            {
                return false;
            }
            Class54 class2 = Class54.smethod_0(buffer, 4);
            if (class2.int_3 != class3.int_6)
            {
                return false;
            }
            flag = this.bool_1 = class2.int_4 == 1;
        }
        catch (Exception)
        {
            this.method_3();
            flag = false;
        }
        finally
        {
            Monitor.Exit(obj2);
        }
        return flag;
    }

    private bool method_6()
    {
        lock (this.object_1)
        {
            this.int_5++;
            Class52 class2 = new Class52 {
                int_6 = this.int_5
            };
            class2.int_7 = this.int_9[class2.int_5 % 10];
            class2.byte_0 = new byte[class2.int_7];
            for (int i = 0; i < class2.int_7; i++)
            {
                class2.byte_0[i] = (byte) ((class2.int_5 + i) % 0x80);
            }
            byte[] src = class2.method_0();
            byte[] dst = new byte[4 + src.Length];
            Buffer.BlockCopy(BitConverter.GetBytes(this.int_6), 0, dst, 0, 4);
            Buffer.BlockCopy(src, 0, dst, 4, src.Length);
            byte[] buffer4 = this.method_9(dst, this.string_0);
            byte[] buffer5 = new byte[buffer4.Length + 8];
            byte[] bytes = BitConverter.GetBytes(buffer4.Length);
            byte[] buffer7 = BitConverter.GetBytes(this.int_0);
            Buffer.BlockCopy(bytes, 0, buffer5, 0, 4);
            Buffer.BlockCopy(buffer7, 0, buffer5, 4, 4);
            Buffer.BlockCopy(buffer4, 0, buffer5, 8, buffer4.Length);
            this.object_0.Write(buffer5, 0, buffer5.Length);
            int num2 = BitConverter.ToInt32(this.method_7((NetworkStream) this.object_0, 8), 0);
            byte[] buffer9 = this.method_7((NetworkStream) this.object_0, num2);
            byte[] buffer10 = this.method_10(buffer9, this.string_0);
            if (BitConverter.ToInt32(buffer10, 0) != this.int_6)
            {
                return false;
            }
            return (Class52.smethod_0(buffer10, 4).int_6 == (class2.int_6 + 1));
        }
    }

    private byte[] method_7(NetworkStream networkStream_0, int int_10)
    {
        byte[] buffer = new byte[int_10];
        this.method_8(networkStream_0, buffer, 0, int_10);
        return buffer;
    }

    private void method_8(NetworkStream networkStream_0, byte[] byte_0, int int_10, int int_11)
    {
        int num = 0;
        int num2 = 0;
        int offset = int_10;
        while (num2 < int_11)
        {
            int count = int_11 - num2;
            num = networkStream_0.Read(byte_0, offset, count);
            if (num == 0)
            {
                throw new IOException("NetworkStream Interruptted !");
            }
            offset += num;
            num2 += num;
        }
    }

    private byte[] method_9(byte[] byte_0, string string_2)
    {
        DESCryptoServiceProvider provider = new DESCryptoServiceProvider {
            Padding = PaddingMode.None,
            Mode = CipherMode.ECB,
            Key = Encoding.ASCII.GetBytes(string_2),
            IV = Encoding.ASCII.GetBytes(string_2)
        };
        return provider.CreateEncryptor().TransformFinalBlock(byte_0, 0, byte_0.Length);
    }

    internal static bool smethod_0(object object_3, out string string_2)
    {
        string_2 = "";
        if (class51_0 == null)
        {
            class51_0 = new Class51();
            return class51_0.method_0();
        }
        return (class51_0.method_1() && class51_0.method_5());
    }
}

