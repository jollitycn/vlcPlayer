namespace CJBasic.Emit
{
    using CJBasic.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;

    public abstract class AgileCreator
    {
        private static Dictionary<CreatorKey, AgileCreator> DicCreator = new Dictionary<CreatorKey, AgileCreator>();
        private static AssemblyBuilder DynamicAssembly = null;
        private static System.Reflection.Emit.ModuleBuilder ModuleBuilder = null;

        protected AgileCreator()
        {
        }

        private static void CreateMethod(TypeBuilder tb, Type originalType, object[] param)
        {
            int num;
            MethodInfo method = typeof(AgileCreator).GetMethod("CreateObject");
            MethodBuilder methodInfoBody = tb.DefineMethod("CreateObject", method.Attributes & ~MethodAttributes.Abstract, method.CallingConvention, method.ReturnType, new Type[] { typeof(object[]) });
            ConstructorInfo[] constructors = originalType.GetConstructors();
            ConstructorInfo con = null;
            ParameterInfo[] parameters = null;
            foreach (ConstructorInfo info3 in constructors)
            {
                parameters = info3.GetParameters();
                if (parameters.Length == param.Length)
                {
                    con = info3;
                    num = 0;
                    while (num < parameters.Length)
                    {
                        if (param[num] == null)
                        {
                            if (parameters[num].ParameterType.IsValueType)
                            {
                                con = null;
                                break;
                            }
                        }
                        else
                        {
                            Type destDataType = param[num].GetType();
                            Type parameterType = parameters[num].ParameterType;
                            if ((!TypeHelper.IsNumbericType(destDataType) || !TypeHelper.IsNumbericType(parameterType)) && !(((destDataType == parameterType) || destDataType.IsSubclassOf(parameterType)) || parameterType.IsAssignableFrom(destDataType)))
                            {
                                con = null;
                                break;
                            }
                        }
                        num++;
                    }
                    if (con != null)
                    {
                        break;
                    }
                }
            }
            if (con == null)
            {
                throw new ArgumentException("The ctor parameter number or type is not correct!");
            }
            ILGenerator iLGenerator = methodInfoBody.GetILGenerator();
            for (num = 0; num < param.Length; num++)
            {
                iLGenerator.Emit(OpCodes.Ldarg_1);
                iLGenerator.Emit(OpCodes.Ldc_I4, num);
                iLGenerator.Emit(OpCodes.Ldelem_Ref);
                if (parameters[num].ParameterType.IsValueType)
                {
                    iLGenerator.Emit(OpCodes.Unbox_Any, parameters[num].ParameterType);
                }
            }
            iLGenerator.Emit(OpCodes.Newobj, con);
            iLGenerator.Emit(OpCodes.Ret);
            tb.DefineMethodOverride(methodInfoBody, method);
        }

        public abstract object CreateObject(object[] param);
        private static AgileCreator GetCreator(Type type, object[] param)
        {
            Type[] paraTypeAry = null;
            if (param != null)
            {
                paraTypeAry = new Type[param.Length];
                for (int i = 0; i < param.Length; i++)
                {
                    if (param[i] != null)
                    {
                        paraTypeAry[i] = param[i].GetType();
                    }
                    else
                    {
                        paraTypeAry[i] = typeof(object);
                    }
                }
            }
            CreatorKey key = new CreatorKey(type, paraTypeAry);
            if (!DicCreator.ContainsKey(key))
            {
                TypeBuilder tb = GetDynamicModule().DefineType(string.Concat(new object[] { "__dynamicCreator.", type.FullName, "_", key.GetHashCode() }), TypeAttributes.Public, typeof(AgileCreator));
                CreateMethod(tb, type, param);
                DicCreator.Add(key, (AgileCreator) Activator.CreateInstance(tb.CreateType()));
            }
            return DicCreator[key];
        }

        private static System.Reflection.Emit.ModuleBuilder GetDynamicModule()
        {
            if (DynamicAssembly == null)
            {
                DynamicAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("DynamicAssembly"), AssemblyBuilderAccess.Run);
                ModuleBuilder = DynamicAssembly.DefineDynamicModule("MainModule");
            }
            return ModuleBuilder;
        }

        public static object New(Type type, params object[] param)
        {
            return GetCreator(type, param).CreateObject(param);
        }
    }
}

