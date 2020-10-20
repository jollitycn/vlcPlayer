namespace CJBasic.Emit
{
    using System;
    using System.Reflection;
    using System.Reflection.Emit;

    public static class EmitHelper
    {
        private static MethodInfo GetTypeFromHandleMethodInfo = typeof(Type).GetMethod("GetTypeFromHandle", new Type[] { typeof(RuntimeTypeHandle) });
        private static MethodInfo MakeByRefTypeMethodInfo = typeof(Type).GetMethod("MakeByRefType");

        public static void ConvertTopArgType(ILGenerator ilGenerator, Type source, Type dest)
        {
            if (!dest.IsAssignableFrom(source))
            {
                if (dest.IsClass)
                {
                    if (source.IsValueType)
                    {
                        ilGenerator.Emit(OpCodes.Box, dest);
                    }
                    else
                    {
                        ilGenerator.Emit(OpCodes.Castclass, dest);
                    }
                }
                else if (source.IsValueType)
                {
                    ilGenerator.Emit(OpCodes.Castclass, dest);
                }
                else
                {
                    ilGenerator.Emit(OpCodes.Unbox_Any, dest);
                }
            }
        }

        public static MethodBuilder DefineDerivedMethodSignature(TypeBuilder typeBuilder, MethodInfo baseMethod)
        {
            Type[] parametersType = GetParametersType(baseMethod);
            MethodBuilder builder = typeBuilder.DefineMethod(baseMethod.Name, baseMethod.Attributes & ~MethodAttributes.Abstract, baseMethod.ReturnType, parametersType);
            if (baseMethod.IsGenericMethod)
            {
                Type[] genericArguments = baseMethod.GetGenericArguments();
                string[] genericParameterNames = GetGenericParameterNames(baseMethod);
                GenericTypeParameterBuilder[] builderArray = builder.DefineGenericParameters(genericParameterNames);
                for (int i = 0; i < builderArray.Length; i++)
                {
                    builderArray[i].SetInterfaceConstraints(genericArguments[i].GetGenericParameterConstraints());
                }
            }
            return builder;
        }

        public static string[] GetGenericParameterNames(MethodInfo method)
        {
            Type[] genericArguments = method.GetGenericArguments();
            string[] strArray = new string[genericArguments.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                strArray[i] = genericArguments[i].Name;
            }
            return strArray;
        }

        public static Type[] GetParametersType(MethodInfo method)
        {
            ParameterInfo[] parameters = method.GetParameters();
            Type[] typeArray = new Type[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                typeArray[i] = parameters[i].ParameterType;
            }
            return typeArray;
        }

        public static void Ldind(ILGenerator ilGenerator, Type type)
        {
            if (!type.IsValueType)
            {
                ilGenerator.Emit(OpCodes.Ldind_Ref);
            }
            else if (type.IsEnum)
            {
                Type underlyingType = Enum.GetUnderlyingType(type);
                Ldind(ilGenerator, underlyingType);
            }
            else if (type == typeof(long))
            {
                ilGenerator.Emit(OpCodes.Ldind_I8);
            }
            else if (type == typeof(int))
            {
                ilGenerator.Emit(OpCodes.Ldind_I4);
            }
            else if (type == typeof(short))
            {
                ilGenerator.Emit(OpCodes.Ldind_I2);
            }
            else if (type == typeof(byte))
            {
                ilGenerator.Emit(OpCodes.Ldind_U1);
            }
            else if (type == typeof(sbyte))
            {
                ilGenerator.Emit(OpCodes.Ldind_I1);
            }
            else if (type == typeof(bool))
            {
                ilGenerator.Emit(OpCodes.Ldind_I1);
            }
            else if (type == typeof(ulong))
            {
                ilGenerator.Emit(OpCodes.Ldind_I8);
            }
            else if (type == typeof(uint))
            {
                ilGenerator.Emit(OpCodes.Ldind_U4);
            }
            else if (type == typeof(ushort))
            {
                ilGenerator.Emit(OpCodes.Ldind_U2);
            }
            else if (type == typeof(float))
            {
                ilGenerator.Emit(OpCodes.Ldind_R4);
            }
            else if (type == typeof(double))
            {
                ilGenerator.Emit(OpCodes.Ldind_R8);
            }
            else if (type == typeof(IntPtr))
            {
                ilGenerator.Emit(OpCodes.Ldind_I4);
            }
            else
            {
                if (type != typeof(UIntPtr))
                {
                    throw new Exception(string.Format("The target type:{0} is not supported by EmitHelper.Ldind()", type));
                }
                ilGenerator.Emit(OpCodes.Ldind_I4);
            }
        }

        public static void LoadArg(ILGenerator gen, int index)
        {
            switch (index)
            {
                case 0:
                    gen.Emit(OpCodes.Ldarg_0);
                    break;

                case 1:
                    gen.Emit(OpCodes.Ldarg_1);
                    break;

                case 2:
                    gen.Emit(OpCodes.Ldarg_2);
                    break;

                case 3:
                    gen.Emit(OpCodes.Ldarg_3);
                    break;

                default:
                    if (index < 0x80)
                    {
                        gen.Emit(OpCodes.Ldarg_S, index);
                    }
                    else
                    {
                        gen.Emit(OpCodes.Ldarg, index);
                    }
                    break;
            }
        }

        public static void LoadType(ILGenerator gen, Type targetType)
        {
            if (targetType.IsByRef)
            {
                gen.Emit(OpCodes.Ldtoken, targetType.GetElementType());
                gen.Emit(OpCodes.Call, GetTypeFromHandleMethodInfo);
                gen.Emit(OpCodes.Callvirt, MakeByRefTypeMethodInfo);
            }
            else
            {
                gen.Emit(OpCodes.Ldtoken, targetType);
                gen.Emit(OpCodes.Call, GetTypeFromHandleMethodInfo);
            }
        }

        public static void Stind(ILGenerator ilGenerator, Type type)
        {
            if (!type.IsValueType)
            {
                ilGenerator.Emit(OpCodes.Stind_Ref);
            }
            else if (type.IsEnum)
            {
                Type underlyingType = Enum.GetUnderlyingType(type);
                Stind(ilGenerator, underlyingType);
            }
            else if (type == typeof(long))
            {
                ilGenerator.Emit(OpCodes.Stind_I8);
            }
            else if (type == typeof(int))
            {
                ilGenerator.Emit(OpCodes.Stind_I4);
            }
            else if (type == typeof(short))
            {
                ilGenerator.Emit(OpCodes.Stind_I2);
            }
            else if (type == typeof(byte))
            {
                ilGenerator.Emit(OpCodes.Stind_I1);
            }
            else if (type == typeof(sbyte))
            {
                ilGenerator.Emit(OpCodes.Stind_I1);
            }
            else if (type == typeof(bool))
            {
                ilGenerator.Emit(OpCodes.Stind_I1);
            }
            else if (type == typeof(ulong))
            {
                ilGenerator.Emit(OpCodes.Stind_I8);
            }
            else if (type == typeof(uint))
            {
                ilGenerator.Emit(OpCodes.Stind_I4);
            }
            else if (type == typeof(ushort))
            {
                ilGenerator.Emit(OpCodes.Stind_I2);
            }
            else if (type == typeof(float))
            {
                ilGenerator.Emit(OpCodes.Stind_R4);
            }
            else if (type == typeof(double))
            {
                ilGenerator.Emit(OpCodes.Stind_R8);
            }
            else if (type == typeof(IntPtr))
            {
                ilGenerator.Emit(OpCodes.Stind_I4);
            }
            else
            {
                if (type != typeof(UIntPtr))
                {
                    throw new Exception(string.Format("The target type:{0} is not supported by EmitHelper.Stind_ForValueType()", type));
                }
                ilGenerator.Emit(OpCodes.Stind_I4);
            }
        }
    }
}

