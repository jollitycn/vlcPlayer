using System;

internal class DateTimeBody : IBody
{
    private DateTime dateTime_0;

    public DateTimeBody()
    {
        this.dateTime_0 = DateTime.Now;
    }

    public DateTimeBody(DateTime dateTime_1)
    {
        this.dateTime_0 = DateTime.Now;
        this.dateTime_0 = dateTime_1;
    }

    public DateTime method_0()
    {
        return this.dateTime_0;
    }

    public static DateTimeBody smethod_0(byte[] byte_0, int int_0, int int_1)
    {
        double num = BitConverter.ToDouble(byte_0, int_0);
        return new DateTimeBody(DateTime.Parse("2010-01-01 00:00:00").AddMilliseconds(num));
    }

    public void ToStream(byte[] stream, int startIndex)
    {
        TimeSpan span = (TimeSpan) (this.dateTime_0 - DateTime.Parse("2010-01-01 00:00:00"));
        Buffer.BlockCopy(BitConverter.GetBytes(span.TotalMilliseconds), 0, stream, startIndex, 8);
    }

    public int BodyTotalLength
    {
        get
        {
            return 8;
        }
    }
}

