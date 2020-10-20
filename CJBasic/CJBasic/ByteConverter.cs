namespace CJBasic
{
    using System;

    public static class ByteConverter
    {
        private static DateTime StartTime = new DateTime(0x7b2, 1, 1);

        public static T Parse<T>(byte[] buff, ref int offset) where T: struct
        {
            return (T) Parse(typeof(T), buff, ref offset);
        }

        public static object Parse(Type type, byte[] buff, ref int offset)
        {
            int num;
            long num7;
            byte num10;
            if (type == typeof(int))
            {
                num = BitConverter.ToInt32(buff, offset);
                offset += 4;
                return num;
            }
            if (type == typeof(uint))
            {
                uint num2 = BitConverter.ToUInt32(buff, offset);
                offset += 4;
                return num2;
            }
            if (type == typeof(double))
            {
                double num3 = BitConverter.ToDouble(buff, offset);
                offset += 8;
                return num3;
            }
            if (type == typeof(short))
            {
                short num4 = BitConverter.ToInt16(buff, offset);
                offset += 2;
                return num4;
            }
            if (type == typeof(ushort))
            {
                ushort num5 = BitConverter.ToUInt16(buff, offset);
                offset += 2;
                return num5;
            }
            if (type == typeof(decimal))
            {
                decimal num6 = (decimal) BitConverter.ToDouble(buff, offset);
                offset += 8;
                return num6;
            }
            if (type == typeof(long))
            {
                num7 = BitConverter.ToInt64(buff, offset);
                offset += 8;
                return num7;
            }
            if (type == typeof(ulong))
            {
                ulong num8 = BitConverter.ToUInt64(buff, offset);
                offset += 8;
                return num8;
            }
            if (type == typeof(float))
            {
                float num9 = BitConverter.ToSingle(buff, offset);
                offset += 4;
                return num9;
            }
            if (type == typeof(byte))
            {
                num10 = buff[offset];
                offset++;
                return num10;
            }
            if (type == typeof(sbyte))
            {
                sbyte num11 = (sbyte) buff[offset];
                offset++;
                return num11;
            }
            if (type == typeof(char))
            {
                char ch = BitConverter.ToChar(buff, offset);
                offset += 2;
                return ch;
            }
            if (type == typeof(bool))
            {
                num10 = buff[offset];
                offset++;
                return (num10 == 1);
            }
            if (type == typeof(DateTime))
            {
                num7 = BitConverter.ToInt64(buff, offset);
                offset += 8;
                return StartTime.AddMilliseconds((double) num7);
            }
            if (!type.IsEnum)
            {
                throw new Exception(string.Format("Not Support the Type {0} !", type));
            }
            num = BitConverter.ToInt32(buff, offset);
            offset += 4;
            return num;
        }

        public static bool SupportType(Type destDataType)
        {
            return ((((((destDataType == typeof(int)) || (destDataType == typeof(uint))) || ((destDataType == typeof(double)) || (destDataType == typeof(short)))) || (((destDataType == typeof(ushort)) || (destDataType == typeof(decimal))) || ((destDataType == typeof(long)) || (destDataType == typeof(ulong))))) || ((((destDataType == typeof(float)) || (destDataType == typeof(byte))) || ((destDataType == typeof(sbyte)) || (destDataType == typeof(char)))) || ((destDataType == typeof(bool)) || (destDataType == typeof(DateTime))))) || destDataType.IsEnum);
        }

        public static byte[] ToBytes<T>(T t) where T: struct
        {
            return ToBytes(typeof(T), t);
        }

        public static byte[] ToBytes(Type type, object obj)
        {
            if (type != typeof(int))
            {
                if (type == typeof(uint))
                {
                    return BitConverter.GetBytes((uint) obj);
                }
                if (type == typeof(double))
                {
                    return BitConverter.GetBytes((double) obj);
                }
                if (type == typeof(short))
                {
                    return BitConverter.GetBytes((short) obj);
                }
                if (type == typeof(ushort))
                {
                    return BitConverter.GetBytes((ushort) obj);
                }
                if (type == typeof(decimal))
                {
                    return BitConverter.GetBytes(decimal.ToDouble((decimal) obj));
                }
                if (type == typeof(long))
                {
                    return BitConverter.GetBytes((long) obj);
                }
                if (type == typeof(ulong))
                {
                    return BitConverter.GetBytes((ulong) obj);
                }
                if (type == typeof(float))
                {
                    return BitConverter.GetBytes((float) obj);
                }
                if ((type == typeof(byte)) || (type == typeof(sbyte)))
                {
                    return new byte[] { ((byte) obj) };
                }
                if (type == typeof(char))
                {
                    return BitConverter.GetBytes((char) obj);
                }
                if (type == typeof(bool))
                {
                    byte num = 0;
                    if ((bool) obj)
                    {
                        num = 1;
                    }
                    return new byte[] { num };
                }
                if (type == typeof(DateTime))
                {
                    DateTime time = (DateTime) obj;
                    TimeSpan span = (TimeSpan) (time - StartTime);
                    return BitConverter.GetBytes((long) span.TotalMilliseconds);
                }
                if (!type.IsEnum)
                {
                    throw new Exception(string.Format("Not Support the Type {0} !", type));
                }
            }
            return BitConverter.GetBytes((int) obj);
        }
    }
}

