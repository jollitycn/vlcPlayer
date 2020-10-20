using CJBasic.ObjectManagement.Managers;
using CJPlus.Application;
using System;

internal class Contract
{
    private int int_0 = -1;
    private int int_1 = 0;
    private int int_2 = 0;
    private object object_0 = new object();
    private SafeDictionary<int, BlobFragmentContract> safeDictionary_0 = new SafeDictionary<int, BlobFragmentContract>();
    private string string_0 = "";
    private string string_1 = "";

    public Contract(int int_3, string string_2, string string_3, int int_4)
    {
        this.int_1 = int_3;
        this.string_0 = string_2;
        this.string_1 = string_3;
        this.int_2 = int_4;
    }

    public void ggvjrxohLf(int int_3)
    {
        this.int_2 = int_3;
    }

    public int method_0()
    {
        return this.int_1;
    }

    public void method_1(int int_3)
    {
        this.int_1 = int_3;
    }

    public string method_2()
    {
        return this.string_0;
    }

    public void method_3(string string_2)
    {
        this.string_0 = string_2;
    }

    public string method_4()
    {
        return this.string_1;
    }

    public void method_5(string string_2)
    {
        this.string_1 = string_2;
    }

    public int method_6()
    {
        return this.int_2;
    }

    public Information GetInformation(BlobFragmentContract blobFragmentContract_0)
    {
        lock (this.object_0)
        {
            if (blobFragmentContract_0.IsLast)
            {
                this.int_0 = blobFragmentContract_0.FragmentIndex;
            }
            this.safeDictionary_0.Add(blobFragmentContract_0.FragmentIndex, blobFragmentContract_0);
            return this.GetInformation();
        }
    }

    private Information GetInformation()
    {
        int num2;
        BlobFragmentContract contract;
        if (this.int_0 < 0)
        {
            return null;
        }
        int num = 0;
        for (num2 = 0; num2 <= this.int_0; num2++)
        {
            contract = this.safeDictionary_0.Get(num2);
            if (contract == null)
            {
                return null;
            }
            num += contract.Fragment.Length;
        }
        byte[] dst = new byte[num];
        int dstOffset = 0;
        for (num2 = 0; num2 <= this.int_0; num2++)
        {
            contract = this.safeDictionary_0.Get(num2);
            Buffer.BlockCopy(contract.Fragment, 0, dst, dstOffset, contract.Fragment.Length);
            dstOffset += contract.Fragment.Length;
        }
        return new Information(this.string_0, this.string_1, this.int_2, dst);
    }
}

