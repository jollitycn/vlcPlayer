namespace CJBasic.Helpers
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Reflection.Emit;

    public static class NullReferenceHelper
    {
        public static string GetExceptionMethodAddress(Exception ee)
        {
            if (!(ee is NullReferenceException))
            {
                return "";
            }
            StackFrame frame = new StackTrace(ee, true).GetFrame(0);
            int iLOffset = frame.GetILOffset();
            byte[] iLAsByteArray = frame.GetMethod().GetMethodBody().GetILAsByteArray();
            iLOffset++;
            ushort index = iLAsByteArray[iLOffset++];
            ILGlobals globals = new ILGlobals();
            OpCode nop = OpCodes.Nop;
            if (index != 0xfe)
            {
                nop = globals.SingleByteOpCodes[index];
            }
            else
            {
                index = iLAsByteArray[iLOffset++];
                nop = globals.MultiByteOpCodes[index];
                index = (ushort) (index | 0xfe00);
            }
            int metadataToken = ReadInt32(iLAsByteArray, ref iLOffset);
            MethodBase base2 = frame.GetMethod().Module.ResolveMethod(metadataToken, frame.GetMethod().DeclaringType.GetGenericArguments(), frame.GetMethod().GetGenericArguments());
            return (base2.DeclaringType + "." + base2.Name);
        }

        private static int ReadInt32(byte[] il, ref int position)
        {
            return (((il[position++] | (il[position++] << 8)) | (il[position++] << 0x10)) | (il[position++] << 0x18));
        }
    }
}

