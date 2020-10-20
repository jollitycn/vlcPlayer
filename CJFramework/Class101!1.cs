using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class Class101<T> where T: class
{
    private T[] gparam_0;
    private int int_0;
    private object object_0;
    private ulong ulong_0;
    private ulong ulong_1;
    private ulong ulong_2;
    private ulong ulong_3;

    public Class101(int int_1, ulong ulong_4)
    {
        this.object_0 = new object();
        this.int_0 = 0;
        this.ulong_0 = 0L;
        this.ulong_1 = 0L;
        this.ulong_2 = 0L;
        this.ulong_3 = 0L;
        this.gparam_0 = new T[int_1];
        this.ulong_0 = ulong_4;
        this.int_0 = 0;
        this.ulong_1 = ulong_4;
    }

    public ulong method_0()
    {
        return this.ulong_2;
    }

    public long method_1()
    {
        return (long) this.gparam_0.Length;
    }

    public ulong method_2()
    {
        return this.ulong_1;
    }

    public uint method_3()
    {
        uint num = 0;
        for (int i = 0; i < this.gparam_0.Length; i++)
        {
            if (this.gparam_0[i] != null)
            {
                num++;
            }
        }
        return num;
    }

    public void method_4(ulong ulong_4, T obj)
    {
        lock (this.object_0)
        {
            if (ulong_4 >= this.ulong_1)
            {
                if ((ulong_4 - this.ulong_1) >= (ulong)this.gparam_0.Length)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Value of parameter id is out of range !id:{0},headID:{1},size:{2}", ulong_4, this.ulong_1, this.gparam_0.Length));
                }
                ulong num = (ulong_4 - this.ulong_0) % ((ulong) this.gparam_0.Length);
                this.gparam_0[(int) ((IntPtr) num)] = obj;
                if (ulong_4 > this.ulong_2)
                {
                    this.ulong_2 = ulong_4;
                }
            }
        }
    }

    public T method_5()
    {
        lock (this.object_0)
        {
            T local = this.gparam_0[this.int_0];
            this.gparam_0[this.int_0] = default(T);
            this.ulong_3 = this.ulong_1;
            this.int_0 = (this.int_0 + 1) % this.gparam_0.Length;
            this.ulong_1 += (ulong) 1L;
            return local;
        }
    }

    public T method_6()
    {
        return this.gparam_0[this.int_0];
    }

    public T method_7(ulong ulong_4)
    {
        if ((ulong_4 > this.ulong_2) || (ulong_4 < this.ulong_1))
        {
            return default(T);
        }
        ulong num = (ulong_4 - this.ulong_0) % ((ulong) this.gparam_0.Length);
        return this.gparam_0[(int) ((IntPtr) num)];
    }

    public List<ulong> method_8(int int_1, out ulong ulong_4, out ulong ulong_5)
    {
        lock (this.object_0)
        {
            List<ulong> list = new List<ulong>();
            ulong_4 = this.ulong_1;
            ulong_5 = this.ulong_2;
            if (ulong_4 > ulong_5)
            {
                ulong_4 = ulong_5;
                list.Add(this.ulong_2 + ((ulong) 1L));
                return list;
            }
            int index = this.int_0;
            for (ulong i = this.ulong_1; i <= (this.ulong_2 + ((ulong) 1L)); i += (ulong) 1L)
            {
                if (this.gparam_0[index] == null)
                {
                    list.Add(i);
                    if (list.Count >= int_1)
                    {
                        break;
                    }
                }
                index = (index + 1) % this.gparam_0.Length;
            }
            if (list.Count != 0)
            {
            }
            return list;
        }
    }

    public List<ulong> method_9(int int_1, out ulong ulong_4, out ulong ulong_5)
    {
        lock (this.object_0)
        {
            ulong_4 = this.ulong_1;
            ulong_5 = this.ulong_2;
            List<ulong> list = new List<ulong>();
            if (this.ulong_2 >= this.ulong_0)
            {
                int index = (int) ((this.ulong_2 - this.ulong_0) % ((ulong) this.gparam_0.Length));
                for (ulong i = this.ulong_2; i >= this.ulong_1; i -= (ulong) 1L)
                {
                    if (this.gparam_0[index] == null)
                    {
                        list.Add(i);
                        if (list.Count >= int_1)
                        {
                            break;
                        }
                    }
                    index = ((index - 1) + this.gparam_0.Length) % this.gparam_0.Length;
                }
            }
            return list;
        }
    }
}

