namespace CJBasic.Helpers
{
    using System;

    public static class TypeHelper
    {
        public static object ChangeType(Type targetType, object val)
        {
            if (val == null)
            {
                return null;
            }
            if (targetType.IsAssignableFrom(val.GetType()))
            {
                return val;
            }
            if (targetType == val.GetType())
            {
                return val;
            }
            if (targetType == typeof(bool))
            {
                if (val.ToString() == "0")
                {
                    return false;
                }
                if (val.ToString() == "1")
                {
                    return true;
                }
            }
            if (targetType.IsEnum)
            {
                int result = 0;
                if (!int.TryParse(val.ToString(), out result))
                {
                    return Enum.Parse(targetType, val.ToString());
                }
                return val;
            }
            if (targetType == typeof(Type))
            {
                return ReflectionHelper.GetType(val.ToString());
            }
            if (targetType == typeof(IComparable))
            {
                return val;
            }
            return Convert.ChangeType(val, targetType);
        }

        public static bool ConvertToBool(object obj)
        {
            Type destDataType = obj.GetType();
            if (destDataType == typeof(string))
            {
                return bool.Parse(obj.ToString());
            }
            if (IsNumbericType(destDataType))
            {
                return (obj.ToString() != "0");
            }
            return (bool) obj;
        }

        public static string GetClassSimpleName(Type t)
        {
            string[] strArray = t.ToString().Split(new char[] { '.' });
            return strArray[strArray.Length - 1].ToString();
        }

        public static object GetDefaultValue(Type destType)
        {
            if (IsNumbericType(destType))
            {
                return 0;
            }
            if (destType == typeof(string))
            {
                return "";
            }
            if (destType == typeof(bool))
            {
                return false;
            }
            if (destType == typeof(DateTime))
            {
                return DateTime.Now;
            }
            if (destType == typeof(Guid))
            {
                return Guid.NewGuid();
            }
            if (destType == typeof(TimeSpan))
            {
                return TimeSpan.Zero;
            }
            return null;
        }

        public static string GetDefaultValueString(Type destType)
        {
            if (IsNumbericType(destType))
            {
                return "0";
            }
            if (destType == typeof(string))
            {
                return "\"\"";
            }
            if (destType == typeof(bool))
            {
                return "false";
            }
            if (destType == typeof(DateTime))
            {
                return "DateTime.Now";
            }
            if (destType == typeof(Guid))
            {
                return "System.Guid.NewGuid()";
            }
            if (destType == typeof(TimeSpan))
            {
                return "System.TimeSpan.Zero";
            }
            return "null";
        }

        public static Type GetTypeByRegularName(string regularName)
        {
            return ReflectionHelper.GetType(regularName);
        }

        public static string GetTypeRegularName(Type destType)
        {
            string str = destType.Assembly.FullName.Split(new char[] { ',' })[0];
            return string.Format("{0},{1}", destType.ToString(), str);
        }

        public static string GetTypeRegularNameOf(object obj)
        {
            return GetTypeRegularName(obj.GetType());
        }

        public static bool IsFixLength(Type destDataType)
        {
            return (IsNumbericType(destDataType) || ((destDataType == typeof(byte[])) || ((destDataType == typeof(DateTime)) || (destDataType == typeof(bool)))));
        }

        public static bool IsIntegerCompatibleType(Type destDataType)
        {
            return (((((destDataType == typeof(int)) || (destDataType == typeof(uint))) || ((destDataType == typeof(short)) || (destDataType == typeof(ushort)))) || (((destDataType == typeof(long)) || (destDataType == typeof(ulong))) || (destDataType == typeof(byte)))) || (destDataType == typeof(sbyte)));
        }

        public static bool IsNumbericType(Type destDataType)
        {
            return ((((((destDataType == typeof(int)) || (destDataType == typeof(uint))) || ((destDataType == typeof(double)) || (destDataType == typeof(short)))) || (((destDataType == typeof(ushort)) || (destDataType == typeof(decimal))) || ((destDataType == typeof(long)) || (destDataType == typeof(ulong))))) || ((destDataType == typeof(float)) || (destDataType == typeof(byte)))) || (destDataType == typeof(sbyte)));
        }

        public static bool IsSimpleType(Type t)
        {
            return (IsNumbericType(t) || ((t == typeof(char)) || ((t == typeof(string)) || ((t == typeof(bool)) || ((t == typeof(DateTime)) || ((t == typeof(Type)) || t.IsEnum))))));
        }
    }
}

