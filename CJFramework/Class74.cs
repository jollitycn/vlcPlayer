using System;

internal class Class74
{
    private DateTime dateTime_0 = DateTime.Now;
    private Delegate0 delegate0_0;
    private object object_0;
    private string string_0;

    public Class74(string string_1, Delegate0 delegate0_1, object object_1)
    {
        this.string_0 = string_1;
        this.delegate0_0 = delegate0_1;
        this.object_0 = object_1;
    }

    public DateTime method_0()
    {
        return this.dateTime_0;
    }

    public Delegate0 method_1()
    {
        return this.delegate0_0;
    }

    public object method_2()
    {
        return this.object_0;
    }

    public string Key
    {
        get
        {
            return this.string_0;
        }
    }
}

