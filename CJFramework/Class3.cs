using CJPlus.FileTransceiver;
using System;

internal class Class3 : Interface2
{
    private int int_0;

    public Class3()
    {
        this.int_0 = 0x800;
    }

    public Class3(int int_1)
    {
        this.int_0 = 0x800;
        this.int_0 = int_1;
    }

    public SendingFileParas imethod_0(string string_0)
    {
        return new SendingFileParas(this.int_0, 0);
    }

    public int method_0()
    {
        return this.int_0;
    }

    public void method_1(int int_1)
    {
        this.int_0 = int_1;
    }
}

