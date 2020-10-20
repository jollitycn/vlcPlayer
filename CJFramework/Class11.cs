using System;

internal class Class11
{
    private bool bool_0;
    private bool bool_1;
    private bool bool_2;
    private bool bool_3;
    private bool bool_4;
    private sbyte sbyte_0;
    private sbyte sbyte_1;

    public Class11(byte[] byte_0)
    {
        if (byte_0.Length < 2)
        {
            throw new Exception("无效的数据头.");
        }
        this.bool_0 = (byte_0[0] & 0x80) == 0x80;
        this.bool_1 = (byte_0[0] & 0x40) == 0x40;
        this.bool_2 = (byte_0[0] & 0x20) == 0x20;
        this.bool_3 = (byte_0[0] & 0x10) == 0x10;
        this.sbyte_0 = (sbyte) (byte_0[0] & 15);
        this.bool_4 = (byte_0[1] & 0x80) == 0x80;
        this.sbyte_1 = (sbyte) (byte_0[1] & 0x7f);
    }

    public Class11(bool bool_5, bool bool_6, bool bool_7, bool bool_8, sbyte sbyte_2, bool bool_9, int int_0)
    {
        this.bool_0 = bool_5;
        this.bool_1 = bool_6;
        this.bool_2 = bool_7;
        this.bool_3 = bool_8;
        this.sbyte_0 = sbyte_2;
        this.bool_4 = bool_9;
        this.sbyte_1 = (sbyte) int_0;
    }

    public bool method_0()
    {
        return this.bool_0;
    }

    public bool method_1()
    {
        return this.bool_1;
    }

    public bool method_2()
    {
        return this.bool_2;
    }

    public bool method_3()
    {
        return this.bool_3;
    }

    public sbyte method_4()
    {
        return this.sbyte_0;
    }

    public bool method_5()
    {
        return this.bool_4;
    }

    public sbyte method_6()
    {
        return this.sbyte_1;
    }

    public byte[] method_7()
    {
        byte[] buffer2 = new byte[2];
        if (this.bool_0)
        {
            buffer2[0] = (byte) (buffer2[0] ^ 0x80);
        }
        if (this.bool_1)
        {
            buffer2[0] = (byte) (buffer2[0] ^ 0x40);
        }
        if (this.bool_2)
        {
            buffer2[0] = (byte) (buffer2[0] ^ 0x20);
        }
        if (this.bool_3)
        {
            buffer2[0] = (byte) (buffer2[0] ^ 0x10);
        }
        buffer2[0] = (byte) (buffer2[0] ^ ((byte) this.sbyte_0));
        if (this.bool_4)
        {
            buffer2[1] = (byte) (buffer2[1] ^ 0x80);
        }
        buffer2[1] = (byte) (buffer2[1] ^ ((byte) this.sbyte_1));
        return buffer2;
    }
}

