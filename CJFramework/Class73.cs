using System;

internal class Class73
{
    private DateTime dateTime_0;
    private IMessageHandler interface37_0;
    private string string_0;

    public Class73(string string_1, IMessageHandler interface37_1, DateTime dateTime_1)
    {
        this.string_0 = string_1;
        this.interface37_0 = interface37_1;
        this.dateTime_0 = dateTime_1;
    }

    public IMessageHandler method_0()
    {
        return this.interface37_0;
    }

    public void method_1(IMessageHandler interface37_1)
    {
        this.interface37_0 = interface37_1;
    }

    public DateTime method_2()
    {
        return this.dateTime_0;
    }

    public void method_3(DateTime dateTime_1)
    {
        this.dateTime_0 = dateTime_1;
    }

    public string Key
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

