namespace CJBasic.Emit.DynamicProxy
{
    using CJBasic.Emit;
    using CJBasic.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;

    public class EfficientAopProxyEmitter
    {
        private string assemblyName;
        private AssemblyBuilder dynamicAssembly;
        protected ModuleBuilder moduleBuilder;
        private IDictionary<string, Type> proxyTypeDictionary;
        private bool saveFile;
        private string theFileName;

        public EfficientAopProxyEmitter() : this(false)
        {
        }

        public EfficientAopProxyEmitter(bool save)
        {
            this.saveFile = false;
            this.assemblyName = "DynamicProxyAssembly";
            this.proxyTypeDictionary = new Dictionary<string, Type>();
            this.saveFile = save;
            this.theFileName = this.assemblyName + ".dll";
            AssemblyBuilderAccess access = this.saveFile ? AssemblyBuilderAccess.RunAndSave : AssemblyBuilderAccess.Run;
            this.dynamicAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(this.assemblyName), access);
            if (this.saveFile)
            {
                this.moduleBuilder = this.dynamicAssembly.DefineDynamicModule("MainModule", this.theFileName);
            }
            else
            {
                this.moduleBuilder = this.dynamicAssembly.DefineDynamicModule("MainModule");
            }
        }

        private Type DoEmitProxyType(Type interfaceType, Type originType)
        {
            string dynamicTypeName = this.GetDynamicTypeName(interfaceType, originType);
            TypeBuilder typeBuilder = this.moduleBuilder.DefineType(dynamicTypeName, TypeAttributes.Public);
            typeBuilder.SetParent(typeof(MarshalByRefObject));
            typeBuilder.AddInterfaceImplementation(interfaceType);
            FieldBuilder field = typeBuilder.DefineField("target", originType, FieldAttributes.Private);
            FieldBuilder builder3 = typeBuilder.DefineField("aopInterceptor", typeof(IAopInterceptor), FieldAttributes.Private);
            ILGenerator iLGenerator = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new Type[] { originType, typeof(IAopInterceptor) }).GetILGenerator();
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Call, typeof(object).GetConstructor(new Type[0]));
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldarg_1);
            iLGenerator.Emit(OpCodes.Stfld, field);
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldarg_2);
            iLGenerator.Emit(OpCodes.Stfld, builder3);
            iLGenerator.Emit(OpCodes.Ret);
            this.EmitInitializeLifetimeServiceMethod(typeBuilder);
            foreach (MethodInfo info in ReflectionHelper.GetAllMethods(new Type[] { interfaceType }))
            {
                this.EmitMethod(originType, typeBuilder, info, field, builder3);
            }
            return typeBuilder.CreateType();
        }

        private void EmitInitializeLifetimeServiceMethod(TypeBuilder typeBuilder)
        {
            MethodInfo info = ReflectionHelper.SearchMethod(typeof(MarshalByRefObject), "InitializeLifetimeService", new Type[0]);
            ILGenerator iLGenerator = typeBuilder.DefineMethod(info.Name, MethodAttributes.Virtual | MethodAttributes.Public, info.ReturnType, new Type[0]).GetILGenerator();
            iLGenerator.Emit(OpCodes.Ldnull);
            iLGenerator.Emit(OpCodes.Ret);
        }

        private void EmitMethod(Type originType, TypeBuilder typeBuilder, MethodInfo baseMethod, FieldBuilder targetField, FieldBuilder aopInterceptorField)
        {
            int num;
            Type[] parametersType = EmitHelper.GetParametersType(baseMethod);
            MethodInfo meth = ReflectionHelper.SearchMethod(originType, baseMethod.Name, parametersType);
            MethodBuilder methodInfoBody = EmitHelper.DefineDerivedMethodSignature(typeBuilder, baseMethod);
            ILGenerator iLGenerator = methodInfoBody.GetILGenerator();
            LocalBuilder local = iLGenerator.DeclareLocal(typeof(Type[]));
            if (meth.IsGenericMethod)
            {
                Type[] genericArguments = meth.GetGenericArguments();
                iLGenerator.Emit(OpCodes.Ldc_I4, genericArguments.Length);
                iLGenerator.Emit(OpCodes.Newarr, typeof(Type));
                iLGenerator.Emit(OpCodes.Stloc, local);
                for (num = 0; num < genericArguments.Length; num++)
                {
                    iLGenerator.Emit(OpCodes.Ldloc, local);
                    iLGenerator.Emit(OpCodes.Ldc_I4, num);
                    EmitHelper.LoadType(iLGenerator, genericArguments[num]);
                    iLGenerator.Emit(OpCodes.Stelem_Ref);
                }
            }
            ParameterInfo[] parameters = meth.GetParameters();
            LocalBuilder builder3 = iLGenerator.DeclareLocal(typeof(string[]));
            LocalBuilder builder4 = iLGenerator.DeclareLocal(typeof(object[]));
            if (parameters.Length > 0)
            {
                iLGenerator.Emit(OpCodes.Ldc_I4, parameters.Length);
                iLGenerator.Emit(OpCodes.Newarr, typeof(string));
                iLGenerator.Emit(OpCodes.Stloc, builder3);
                for (num = 0; num < parameters.Length; num++)
                {
                    iLGenerator.Emit(OpCodes.Ldloc, builder3);
                    iLGenerator.Emit(OpCodes.Ldc_I4, num);
                    iLGenerator.Emit(OpCodes.Ldstr, parameters[num].Name);
                    iLGenerator.Emit(OpCodes.Stelem_Ref);
                }
                iLGenerator.Emit(OpCodes.Ldc_I4, parameters.Length);
                iLGenerator.Emit(OpCodes.Newarr, typeof(object));
                iLGenerator.Emit(OpCodes.Stloc, builder4);
                for (num = 0; num < parameters.Length; num++)
                {
                    iLGenerator.Emit(OpCodes.Ldloc, builder4);
                    iLGenerator.Emit(OpCodes.Ldc_I4, num);
                    iLGenerator.Emit(OpCodes.Ldarg, (int) (num + 1));
                    if (parameters[num].ParameterType.IsByRef)
                    {
                        EmitHelper.Ldind(iLGenerator, parameters[num].ParameterType);
                        iLGenerator.Emit(OpCodes.Box, parameters[num].ParameterType.GetElementType());
                    }
                    else if (parameters[num].ParameterType.IsValueType)
                    {
                        iLGenerator.Emit(OpCodes.Box, parameters[num].ParameterType);
                    }
                    iLGenerator.Emit(OpCodes.Stelem_Ref);
                }
            }
            LocalBuilder builder5 = iLGenerator.DeclareLocal(typeof(InterceptedMethod));
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldfld, targetField);
            iLGenerator.Emit(OpCodes.Ldstr, meth.Name);
            iLGenerator.Emit(OpCodes.Ldloc, local);
            iLGenerator.Emit(OpCodes.Ldloc, builder3);
            iLGenerator.Emit(OpCodes.Ldloc, builder4);
            iLGenerator.Emit(OpCodes.Newobj, typeof(InterceptedMethod).GetConstructor(new Type[] { typeof(object), typeof(string), typeof(Type[]), typeof(string[]), typeof(object[]) }));
            iLGenerator.Emit(OpCodes.Stloc, builder5);
            MethodInfo method = typeof(IAopInterceptor).GetMethod("PreProcess", new Type[] { typeof(InterceptedMethod) });
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldfld, aopInterceptorField);
            iLGenerator.Emit(OpCodes.Ldloc, builder5);
            iLGenerator.Emit(OpCodes.Callvirt, method);
            LocalBuilder builder6 = iLGenerator.DeclareLocal(typeof(IArounder));
            MethodInfo info3 = typeof(IAopInterceptor).GetMethod("NewArounder");
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldfld, aopInterceptorField);
            iLGenerator.Emit(OpCodes.Callvirt, info3);
            iLGenerator.Emit(OpCodes.Stloc, builder6);
            MethodInfo info4 = typeof(IArounder).GetMethod("BeginAround");
            iLGenerator.Emit(OpCodes.Ldloc, builder6);
            iLGenerator.Emit(OpCodes.Ldloc, builder5);
            iLGenerator.Emit(OpCodes.Callvirt, info4);
            LocalBuilder builder7 = null;
            if (meth.ReturnType != typeof(void))
            {
                builder7 = iLGenerator.DeclareLocal(meth.ReturnType);
            }
            LocalBuilder builder8 = iLGenerator.DeclareLocal(typeof(Exception));
            Label label = iLGenerator.BeginExceptionBlock();
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldfld, targetField);
            int index = 0;
            foreach (ParameterInfo info5 in meth.GetParameters())
            {
                EmitHelper.LoadArg(iLGenerator, index + 1);
                EmitHelper.ConvertTopArgType(iLGenerator, parametersType[index], info5.ParameterType);
                index++;
            }
            iLGenerator.Emit(OpCodes.Callvirt, meth);
            if (builder7 != null)
            {
                iLGenerator.Emit(OpCodes.Stloc, builder7);
            }
            iLGenerator.BeginCatchBlock(typeof(Exception));
            iLGenerator.Emit(OpCodes.Stloc, builder8);
            MethodInfo info6 = typeof(IArounder).GetMethod("OnException");
            iLGenerator.Emit(OpCodes.Ldloc, builder6);
            iLGenerator.Emit(OpCodes.Ldloc, builder5);
            iLGenerator.Emit(OpCodes.Ldloc, builder8);
            iLGenerator.Emit(OpCodes.Callvirt, info6);
            iLGenerator.Emit(OpCodes.Nop);
            iLGenerator.Emit(OpCodes.Rethrow);
            iLGenerator.Emit(OpCodes.Nop);
            iLGenerator.EndExceptionBlock();
            MethodInfo info7 = typeof(IArounder).GetMethod("EndAround");
            iLGenerator.Emit(OpCodes.Ldloc, builder6);
            if (builder7 != null)
            {
                if (meth.ReturnType.IsValueType)
                {
                    iLGenerator.Emit(OpCodes.Ldloc, builder7);
                    iLGenerator.Emit(OpCodes.Box, meth.ReturnType);
                }
                else
                {
                    iLGenerator.Emit(OpCodes.Ldloc, builder7);
                }
            }
            else
            {
                iLGenerator.Emit(OpCodes.Ldnull);
            }
            iLGenerator.Emit(OpCodes.Callvirt, info7);
            iLGenerator.Emit(OpCodes.Nop);
            MethodInfo info8 = typeof(IAopInterceptor).GetMethod("PostProcess", new Type[] { typeof(InterceptedMethod), typeof(object) });
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldfld, aopInterceptorField);
            iLGenerator.Emit(OpCodes.Ldloc, builder5);
            if (builder7 != null)
            {
                if (meth.ReturnType.IsValueType)
                {
                    iLGenerator.Emit(OpCodes.Ldloc, builder7);
                    iLGenerator.Emit(OpCodes.Box, meth.ReturnType);
                }
                else
                {
                    iLGenerator.Emit(OpCodes.Ldloc, builder7);
                }
            }
            else
            {
                iLGenerator.Emit(OpCodes.Ldnull);
            }
            iLGenerator.Emit(OpCodes.Callvirt, info8);
            iLGenerator.Emit(OpCodes.Nop);
            if (builder7 != null)
            {
                iLGenerator.Emit(OpCodes.Ldloc, builder7);
            }
            iLGenerator.Emit(OpCodes.Ret);
            typeBuilder.DefineMethodOverride(methodInfoBody, baseMethod);
        }

        public Type EmitProxyType<TInterface>(Type originType)
        {
            Type interfaceType = typeof(TInterface);
            return this.EmitProxyType(interfaceType, originType);
        }

        public Type EmitProxyType(Type interfaceType, Type originType)
        {
            if (!interfaceType.IsInterface)
            {
                throw new Exception("TInterface must be interface type !");
            }
            if (interfaceType.ContainsGenericParameters)
            {
                throw new Exception("TInterface can't be generic !");
            }
            string dynamicTypeName = this.GetDynamicTypeName(interfaceType, originType);
            if (this.proxyTypeDictionary.ContainsKey(dynamicTypeName))
            {
                return this.proxyTypeDictionary[dynamicTypeName];
            }
            Type type = this.DoEmitProxyType(interfaceType, originType);
            this.proxyTypeDictionary.Add(dynamicTypeName, type);
            return type;
        }

        private string GetDynamicTypeName(Type interfaceType, Type originType)
        {
            return string.Format("{0}.{1}_{2}_EfficientAopProxy", this.assemblyName, originType.ToString(), interfaceType.ToString());
        }

        public void Save()
        {
            if (this.saveFile)
            {
                this.dynamicAssembly.Save(this.theFileName);
            }
        }
    }
}

