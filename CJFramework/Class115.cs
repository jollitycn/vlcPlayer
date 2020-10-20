using CJBasic.Collections;
using System;
using System.Collections.Generic;

internal sealed class Class115 : Interface38
{
    private IList<IProcess> ilist_0;
    private object object_0;
    private SortedArray<int, IProcess> sortedArray_0;

    public Class115()
    {
        this.sortedArray_0 = new SortedArray<int, IProcess>();
        this.object_0 = new object();
        this.ilist_0 = new List<IProcess>();
    }

    public Class115(IProcess interface12_0)
    {
        this.sortedArray_0 = new SortedArray<int, IProcess>();
        this.object_0 = new object();
        this.ilist_0 = new List<IProcess>();
        this.ilist_0 = new List<IProcess>();
        this.ilist_0.Add(interface12_0);
    }

    public Class115(IEnumerable<IProcess> processers)
    {
        this.sortedArray_0 = new SortedArray<int, IProcess>();
        this.object_0 = new object();
        this.ilist_0 = new List<IProcess>();
        this.ilist_0 = new List<IProcess>(processers);
    }

    public IProcess imethod_0(int int_0)
    {
        if (this.sortedArray_0.ContainsKey(int_0))
        {
            return this.sortedArray_0[int_0];
        }
        IProcess val = null;
        using (IEnumerator<IProcess> enumerator = this.ilist_0.GetEnumerator())
        {
            IProcess current;
            while (enumerator.MoveNext())
            {
                current = enumerator.Current;
                if (current.CanProcess(int_0))
                {
                    goto Label_0050;
                }
            }
            goto Label_0062;
        Label_0050:
            val = current;
        }
    Label_0062:
        if (val != null)
        {
            lock (this.object_0)
            {
                if (!this.sortedArray_0.ContainsKey(int_0))
                {
                    this.sortedArray_0.Add(int_0, val);
                }
            }
        }
        return val;
    }

    public void method_0(IList<IProcess> value)
    {
        this.ilist_0 = value;
    }
}

