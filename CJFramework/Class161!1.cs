using CJBasic;
using System;
using System.Threading;

internal class Class161<T> where T: class
{
    private T[] gparam_0;
    private int int_0;
    private object object_0;
    private ulong ulong_0;
    private ulong ulong_1;
    private ulong ulong_2;

    public event CbGeneric SessionResetted;

    public Class161(int int_1, ulong ulong_3)
    {
        this.object_0 = new object();
        this.int_0 = 0;
        this.ulong_0 = 0L;
        this.ulong_1 = 0L;
        this.ulong_2 = 0L;
        this.gparam_0 = new T[int_1];
        this.ulong_0 = ulong_3;
        this.ulong_1 = ulong_3;
        this.int_0 = 0;
    }

    public ulong method_0()
    {
        return this.ulong_1;
    }

    public ulong method_1()
    {
        return this.ulong_2;
    }

    public T method_10()
    {
        return this.gparam_0[this.int_0];
    }

    public bool method_2(int int_1)
    {
        return (((int) (this.ulong_2 - this.ulong_1)) >= ((this.gparam_0.Length - 1) - int_1));
    }

    public long method_3()
    {
        return (long) this.gparam_0.Length;
    }

    public int method_4()
    {
        int num = 0;
        for (ulong i = this.ulong_1; i <= this.ulong_2; i += (ulong) 1L)
        {
            ulong num4 = (i - this.ulong_0) % ((ulong) this.gparam_0.Length);
            if (this.gparam_0[(int) ((IntPtr) num4)] != null)
            {
                num++;
            }
        }
        return num;
    }

    public void method_5(ulong ulong_3)
    {
        lock (this.object_0)
        {
            if (ulong_3 >= this.ulong_1)
            {
                if (ulong_3 > this.ulong_2)
                {
                    if (this.SessionResetted != null)
                    {
                        this.SessionResetted();
                    }
                    if (this.ulong_2 > 0L)
                    {
                        throw new Exception(string.Format("Wrong parameter value !ackID:{0},maxID:{1}", ulong_3, this.ulong_2));
                    }
                }
                for (ulong i = this.ulong_1; i <= ulong_3; i += (ulong) 1L)
                {
                    ulong num2 = (i - this.ulong_0) % ((ulong) this.gparam_0.Length);
                    T local = default(T);
                    this.gparam_0[(int) ((IntPtr) num2)] = local;
                }
                this.method_7();
            }
        }
    }

    public void method_6(ulong ulong_3)
    {
        lock (this.object_0)
        {
            if ((ulong_3 <= this.ulong_2) && (ulong_3 >= this.ulong_1))
            {
                ulong num = (ulong_3 - this.ulong_0) % ((ulong)this.gparam_0.Length);
                this.gparam_0[(int) ((IntPtr) num)] = default(T);
                this.method_7();
            }
        }
    }

    private void method_7()
    {
        // This item is obfuscated and can not be translated.
        while (this.ulong_1 > this.ulong_2)
        {
       // Label_0004:
            if (0 == 0)
            {
                return;
            }
            this.int_0 = (this.int_0 + 1) % this.gparam_0.Length;
            this.ulong_1 += (ulong) 1L;
        }
      //  goto Label_0004;
    }

    public T method_8(ulong ulong_3)
    {
        if ((ulong_3 > this.ulong_2) || (ulong_3 < this.ulong_1))
        {
            return default(T);
        }
        ulong num = (ulong_3 - this.ulong_0) % ((ulong) this.gparam_0.Length);
        return this.gparam_0[(int) ((IntPtr) num)];
    }

    public bool method_9(ulong ulong_3)
    {
        if ((ulong_3 > this.ulong_2) || (ulong_3 < this.ulong_1))
        {
            return false;
        }
        ulong num = (ulong_3 - this.ulong_0) % ((ulong) this.gparam_0.Length);
        return (this.gparam_0[(int) ((IntPtr) num)] != null);
    }

    public void sJirjHxlxv(ulong ulong_3, ulong ulong_4)
    {
        lock (this.object_0)
        {
            if (((ulong_3 <= ulong_4) && (ulong_3 <= this.ulong_2)) && (ulong_4 >= this.ulong_1))
            {
                if (ulong_3 < this.ulong_1)
                {
                    ulong_3 = this.ulong_1;
                }
                if (ulong_4 > this.ulong_2)
                {
                    ulong_4 = this.ulong_2;
                }
                for (ulong i = ulong_3; i <= ulong_4; i += (ulong) 1L)
                {
                    ulong num2 = (i - this.ulong_0) % ((ulong) this.gparam_0.Length);
                    T local = default(T);
                    this.gparam_0[(int) ((IntPtr) num2)] = local;
                }
                this.method_7();
            }
        }
    }

    public void vgxruqcnr8(ulong ulong_3, T obj)
    {
        lock (this.object_0)
        {
            ulong num = (ulong_3 - this.ulong_0) % ((ulong) this.gparam_0.Length);
            this.gparam_0[(int) ((IntPtr) num)] = obj;
            if (ulong_3 > this.ulong_2)
            {
                this.ulong_2 = ulong_3;
            }
        }
    }
}

