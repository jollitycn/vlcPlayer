namespace CJBasic.Helpers
{
    using System;

    public static class ValidationHelper
    {
        public static void NotDefault<T>(T t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("参数不能为null");
            }
            if (t is ValueType)
            {
                throw new ArgumentException("参数{0}不能使用默认值");
            }
        }

        public static void NotDefault<T>(T t, string name)
        {
            if (t == null)
            {
                throw new ArgumentNullException(string.Format("参数{0}不能为null", name), name);
            }
            if (t is ValueType)
            {
                throw new ArgumentException(string.Format("参数{0}不能使用默认值", name), name);
            }
        }
    }
}

