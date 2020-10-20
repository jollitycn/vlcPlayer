using CJFramework;
using System;

[Serializable]
internal class Class41 : ICloneable, IHeader, Interface22
{
    internal static readonly byte byte_0 = 0xff;
    private byte byte_1;
    private byte byte_2;
    private static int int_0 = 11;
    internal static int int_1 = 0x24;
    private int int_2;
    private int int_3;
    private string string_0;
    private string string_1;
    private ushort ushort_0;

    public Class41()
    {
        this.byte_1 = byte_0;
        this.byte_2 = 0;
        this.string_0 = "";
        this.string_1 = "";
        this.ushort_0 = 0;
        this.int_2 = 0;
        this.int_3 = 0;
    }

    public Class41(string string_2, int int_4, int int_5, string string_3, int int_6)
    {
        this.byte_1 = byte_0;
        this.byte_2 = 0;
        this.string_0 = "";
        this.string_1 = "";
        this.ushort_0 = 0;
        this.int_2 = 0;
        this.int_3 = 0;
        this.MessageType = int_4;
        this.imethod_6(int_5);
        this.UserID = string_2;
        this.DestUserID = string_3;
        this.int_2 = int_6;
        this.SetClientType(ClientType.DotNET);
    }

    public object Clone()
    {
        return new Class41(this.string_0, this.ushort_0, this.int_3, this.string_1, this.int_2);
    }

    public ClientType GetClientType()
    {
        return (ClientType) this.byte_2;
    }

    public void SetClientType(ClientType clientType_0)
    {
        this.byte_2 = (byte) clientType_0;
    }

    public byte imethod_2()
    {
        return this.byte_1;
    }

    public void imethod_3(byte byte_3)
    {
        this.byte_1 = byte_3;
    }

    public int imethod_4()
    {
        return int_1;
    }

    public int imethod_5()
    {
        return this.int_3;
    }

    public void imethod_6(int int_4)
    {
        this.int_3 = int_4;
    }

    public static void SetMaxLengthOfUserID(byte maxLen)
    {
        if (maxLen < 1)
        {
            throw new Exception("maxLen must be greater than 0 !");
        }
        int num = ((maxLen * 2) + 12) + 2;
        int num2 = (num / 4) * 4;
        if ((num % 4) > 0)
        {
            num2 += 4;
        }
        int_1 = num2;
        int_0 = ((num2 - 12) - 2) / 2;
    }

    public static Class41 smethod_1(byte[] byte_3, int int_4)
    {
        try
        {
            Class41 class2 = new Class41();
            int index = int_4;
            class2.byte_1 = byte_3[index];
            index++;
            class2.byte_2 = byte_3[index];
            index++;
            class2.ushort_0 = BitConverter.ToUInt16(byte_3, index);
            index += 2;
            class2.int_2 = BitConverter.ToInt32(byte_3, index);
            index += 4;
            class2.int_3 = BitConverter.ToInt32(byte_3, index);
            index += 4;
            byte num2 = byte_3[index];
            index++;
            class2.string_0 = Class84.smethod_0().imethod_8(byte_3, index, num2);
            index += int_0;
            byte num3 = byte_3[index];
            index++;
            class2.string_1 = Class84.smethod_0().imethod_8(byte_3, index, num3);
            index += int_0;
            return class2;
        }
        catch
        {
            return null;
        }
    }

    public byte[] ToStream()
    {
        int num2;
        byte[] buffer = new byte[this.imethod_4()];
        int index = 0;
        buffer[0] = this.byte_1;
        index = 1;
        buffer[1] = this.byte_2;
        index = 2;
        byte[] bytes = BitConverter.GetBytes(this.ushort_0);
        for (num2 = 0; num2 < bytes.Length; num2++)
        {
            buffer[index + num2] = bytes[num2];
        }
        index += 2;
        byte[] buffer5 = BitConverter.GetBytes(this.int_2);
        for (num2 = 0; num2 < buffer5.Length; num2++)
        {
            buffer[index + num2] = buffer5[num2];
        }
        index += 4;
        byte[] buffer4 = BitConverter.GetBytes(this.int_3);
        for (num2 = 0; num2 < buffer4.Length; num2++)
        {
            buffer[index + num2] = buffer4[num2];
        }
        index += 4;
        byte[] buffer6 = Class84.smethod_0().imethod_9(this.string_0);
        if (buffer6.Length > int_0)
        {
            throw new Exception(string.Format("Length of UserID [{0}] exceed limited !", this.string_0));
        }
        buffer[index] = (byte) buffer6.Length;
        index++;
        for (num2 = 0; num2 < buffer6.Length; num2++)
        {
            buffer[index + num2] = buffer6[num2];
        }
        index += int_0;
        byte[] buffer3 = Class84.smethod_0().imethod_9(this.string_1);
        if (buffer3.Length > int_0)
        {
            throw new Exception(string.Format("Length of DestUserID [{0}] exceed limited !", this.string_1));
        }
        buffer[index] = (byte) buffer3.Length;
        index++;
        for (num2 = 0; num2 < buffer3.Length; num2++)
        {
            buffer[index + num2] = buffer3[num2];
        }
        index += int_0;
        return buffer;
    }

    public void ToStream(byte[] byte_3, int int_4)
    {
        byte[] src = this.ToStream();
        Buffer.BlockCopy(src, 0, byte_3, int_4, src.Length);
    }

    public override string ToString()
    {
        return string.Format("MessageType:{0} ,UserID:{1}", this.ushort_0, this.string_0);
    }
     
    public string DestUserID
    {
        get
        {
            return this.string_1;
        }
        set
        {
            this.string_1 = value;
        }
    }

    public int MessageID
    {
        get
        {
            return this.int_2;
        }
        set
        {
            this.int_2 = value;
        }
    }

    public int MessageType
    {
        get
        {
            return this.ushort_0;
        }
        set
        {
            this.ushort_0 = (ushort) value;
        }
    }

    public string UserID
    {
        get
        {
            return this.string_0;
        }
        set
        {
            this.string_0 = value;
        }
    }
}

