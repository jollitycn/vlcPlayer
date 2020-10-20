using CJBasic;
using CJBasic.ObjectManagement;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal class Class46<T>
{
    private volatile bool bool_0;
    private CbGeneric<T> cbGeneric_0;
    private CircleQueue<T> circleQueue_0;
    private object object_0;

    public Class46()
    {
        this.bool_0 = false;
        this.object_0 = new object();
    }

    public void method_0(int int_0, CbGeneric<T> pointer)
    {
        this.circleQueue_0 = new CircleQueue<T>(int_0);
        this.cbGeneric_0 = pointer;
    }

    public bool method_1()
    {
        return this.bool_0;
    }

    public void method_2()
    {
        while (this.circleQueue_0.Full)
        {
            Thread.Sleep(5);
        }
    }

    public bool method_3()
    {
        return this.circleQueue_0.Full;
    }

    public void method_4(T obj)
    {
        this.circleQueue_0.Enqueue(obj);
        this.method_5();
    }

    private void method_5()
    {
        T local;
        if (this.bool_0 || (this.circleQueue_0.Count == 0))
        {
            return;
        }
        lock (this.object_0)
        {
            if (this.bool_0)
            {
                return;
            }
            this.bool_0 = true;
            goto Label_0066;
        }
    Label_004E:
        local = this.circleQueue_0.Dequeue();
        this.cbGeneric_0(local);
    Label_0066:
        if (this.circleQueue_0.Count > 0)
        {
            goto Label_004E;
        }
        this.bool_0 = false;
        this.method_5();
    }
}

