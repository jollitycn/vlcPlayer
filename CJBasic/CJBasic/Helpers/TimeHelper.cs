namespace CJBasic.Helpers
{
    using System;

    public static class TimeHelper
    {
        public static bool IsOnTime(DateTime requiredTime, DateTime val, int maxToleranceInSecs)
        {
            TimeSpan span = (TimeSpan) (val - requiredTime);
            double num = (span.TotalMilliseconds < 0.0) ? -span.TotalMilliseconds : span.TotalMilliseconds;
            return (num <= (maxToleranceInSecs * 0x3e8));
        }

        public static bool IsOnTime(DateTime startTime, DateTime val, int cycleSpanInSecs, int maxToleranceInSecs)
        {
            TimeSpan span = (TimeSpan) (val - startTime);
            double num2 = span.TotalMilliseconds % ((double) (cycleSpanInSecs * 0x3e8));
            return (num2 <= (maxToleranceInSecs * 0x3e8));
        }
    }
}

