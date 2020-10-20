namespace CJBasic.Emit.DynamicDispatcher
{
    using CJBasic.Emit;
    using CJBasic.Helpers;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;

    public class DynamicDispatcherEmitter
    {
        private string assemblyName;
        private IDictionary<Type, Type> dicDispatcherType;
        private AssemblyBuilder dynamicAssembly;
        protected ModuleBuilder moduleBuilder;
        private bool saveFile;
        private string theFileName;

        public DynamicDispatcherEmitter() : this(false)
        {
        }

        public DynamicDispatcherEmitter(bool save)
        {
            this.saveFile = false;
            this.assemblyName = "DynamicDispatcherAssembly";
            this.dicDispatcherType = new Dictionary<Type, Type>();
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

        public Type CreateDispatcherType(Type typeOfIDispatcher)
        {
            lock (this.dicDispatcherType)
            {
                if (this.dicDispatcherType.ContainsKey(typeOfIDispatcher))
                {
                    return this.dicDispatcherType[typeOfIDispatcher];
                }
                Type type = this.EmitDispatcherType(typeOfIDispatcher);
                this.dicDispatcherType.Add(typeOfIDispatcher, type);
                return type;
            }
        }

        public Type EmitDispatcherType(Type typeOfIDispatcher)
        {
            string name = string.Format("{0}_DynamicDispatcher", TypeHelper.GetClassSimpleName(typeOfIDispatcher));
            TypeBuilder typeBuilder = this.moduleBuilder.DefineType(name, TypeAttributes.Public);
            typeBuilder.AddInterfaceImplementation(typeOfIDispatcher);
            Type type = typeof(IEnumerable<>).MakeGenericType(new Type[] { typeOfIDispatcher });
            FieldBuilder field = typeBuilder.DefineField("executers", type, FieldAttributes.Private);
            ILGenerator iLGenerator = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new Type[] { type }).GetILGenerator();
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Call, typeof(object).GetConstructor(new Type[0]));
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldarg_1);
            iLGenerator.Emit(OpCodes.Stfld, field);
            iLGenerator.Emit(OpCodes.Ret);
            MethodInfo method = typeof(IEnumerable<>).MakeGenericType(new Type[] { typeOfIDispatcher }).GetMethod("GetEnumerator");
            MethodInfo meth = typeof(IEnumerator<>).MakeGenericType(new Type[] { typeOfIDispatcher }).GetMethod("get_Current");
            MethodInfo info3 = typeof(IEnumerator).GetMethod("MoveNext");
            MethodInfo info4 = typeof(IDisposable).GetMethod("Dispose");
            foreach (MethodInfo info5 in ReflectionHelper.GetAllMethods(new Type[] { typeOfIDispatcher }))
            {
                Type[] parametersType = EmitHelper.GetParametersType(info5);
                MethodBuilder methodInfoBody = EmitHelper.DefineDerivedMethodSignature(typeBuilder, info5);
                ILGenerator gen = methodInfoBody.GetILGenerator();
                LocalBuilder local = gen.DeclareLocal(typeof(IEnumerator<>).MakeGenericType(new Type[] { typeOfIDispatcher }));
                LocalBuilder builder6 = gen.DeclareLocal(typeOfIDispatcher);
                Label loc = gen.DefineLabel();
                Label label = gen.DefineLabel();
                Label label3 = gen.DefineLabel();
                Label label4 = gen.DefineLabel();
                gen.Emit(OpCodes.Ldarg_0);
                gen.Emit(OpCodes.Ldfld, field);
                gen.Emit(OpCodes.Callvirt, method);
                gen.Emit(OpCodes.Stloc, local);
                Label label5 = gen.BeginExceptionBlock();
                gen.Emit(OpCodes.Br, label);
                gen.MarkLabel(loc);
                gen.Emit(OpCodes.Ldloc, local);
                gen.Emit(OpCodes.Callvirt, meth);
                gen.Emit(OpCodes.Stloc, builder6);
                gen.Emit(OpCodes.Ldloc, builder6);
                int num = 0;
                foreach (ParameterInfo info6 in info5.GetParameters())
                {
                    EmitHelper.LoadArg(gen, num + 1);
                    num++;
                }
                gen.Emit(OpCodes.Callvirt, info5);
                gen.Emit(OpCodes.Nop);
                gen.MarkLabel(label);
                gen.Emit(OpCodes.Ldloc, local);
                gen.Emit(OpCodes.Callvirt, info3);
                gen.Emit(OpCodes.Brtrue, loc);
                gen.Emit(OpCodes.Leave, label3);
                gen.BeginFinallyBlock();
                gen.Emit(OpCodes.Ldloc, local);
                gen.Emit(OpCodes.Ldnull);
                gen.Emit(OpCodes.Ceq);
                gen.Emit(OpCodes.Brtrue, label4);
                gen.Emit(OpCodes.Ldloc, local);
                gen.Emit(OpCodes.Callvirt, info4);
                gen.Emit(OpCodes.Nop);
                gen.MarkLabel(label4);
                gen.EndExceptionBlock();
                gen.Emit(OpCodes.Nop);
                gen.MarkLabel(label3);
                gen.Emit(OpCodes.Ret);
                typeBuilder.DefineMethodOverride(methodInfoBody, info5);
            }
            return typeBuilder.CreateType();
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

