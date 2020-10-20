namespace CJBasic.Helpers
{
    using System;
    using System.Reflection;
    using System.Reflection.Emit;

    public class ILGlobals
    {
        private OpCode[] multiByteOpCodes = new OpCode[0x100];
        private OpCode[] singleByteOpCodes = new OpCode[0x100];

        public ILGlobals()
        {
            foreach (FieldInfo info in typeof(OpCodes).GetFields())
            {
                if (info.FieldType == typeof(OpCode))
                {
                    OpCode code = (OpCode) info.GetValue(null);
                    ushort index = (ushort) code.Value;
                    if (index < 0x100)
                    {
                        this.singleByteOpCodes[index] = code;
                    }
                    else
                    {
                        if ((index & 0xff00) != 0xfe00)
                        {
                            throw new Exception("Invalid OpCode.");
                        }
                        this.multiByteOpCodes[index & 0xff] = code;
                    }
                }
            }
        }

        public static string ProcessSpecialTypes(string typeName)
        {
            string str = typeName;
            string str3 = typeName;
            if (str3 == null)
            {
                return str;
            }
            if (((str3 != "System.string") && (str3 != "System.String")) && (str3 != "String"))
            {
                if (((str3 != "System.Int32") && (str3 != "Int")) && (str3 != "Int32"))
                {
                    return str;
                }
            }
            else
            {
                return "string";
            }
            return "int";
        }

        public OpCode[] MultiByteOpCodes
        {
            get
            {
                return this.multiByteOpCodes;
            }
        }

        public OpCode[] SingleByteOpCodes
        {
            get
            {
                return this.singleByteOpCodes;
            }
        }
    }
}

