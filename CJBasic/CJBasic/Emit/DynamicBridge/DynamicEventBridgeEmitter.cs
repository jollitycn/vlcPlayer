namespace CJBasic.Emit.DynamicBridge
{
    using CJBasic.Emit;
    using CJBasic.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;

    public class DynamicEventBridgeEmitter
    {
        private string assemblyName;
        private AssemblyBuilder dynamicAssembly;
        private IDictionary<string, Type> eventBridgeTypeDictionary;
        protected ModuleBuilder moduleBuilder;
        private bool saveFile;
        private string theFileName;

        public DynamicEventBridgeEmitter() : this(false)
        {
        }

        public DynamicEventBridgeEmitter(bool save)
        {
            this.saveFile = false;
            this.assemblyName = "DynamicEventBridgeAssembly";
            this.eventBridgeTypeDictionary = new Dictionary<string, Type>();
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

        public Type EmitEventBridgeType(Type typeOfEventPublisher, Type typeOfEventHandler, IDictionary<string, string> eventAndHanlerMapping)
        {
            string str3;
            string key = string.Format("{0}_{1}_DynamicEventBridge", TypeHelper.GetClassSimpleName(typeOfEventPublisher), TypeHelper.GetClassSimpleName(typeOfEventHandler));
            if (this.eventBridgeTypeDictionary.ContainsKey(key))
            {
                return this.eventBridgeTypeDictionary[key];
            }
            TypeBuilder typeBuilder = this.moduleBuilder.DefineType(key, TypeAttributes.Public);
            typeBuilder.AddInterfaceImplementation(typeof(IEventBridge));
            FieldInfo field = typeBuilder.DefineField("handler", typeOfEventHandler, FieldAttributes.Private);
            FieldInfo info2 = typeBuilder.DefineField("eventPublisher", typeOfEventPublisher, FieldAttributes.Private);
            ILGenerator iLGenerator = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new Type[] { typeOfEventPublisher, typeOfEventHandler }).GetILGenerator();
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Call, typeof(object).GetConstructor(new Type[0]));
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldarg_1);
            iLGenerator.Emit(OpCodes.Stfld, info2);
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldarg_2);
            iLGenerator.Emit(OpCodes.Stfld, field);
            iLGenerator.Emit(OpCodes.Ret);
            Dictionary<string, MethodInfo> dictionary = new Dictionary<string, MethodInfo>();
            foreach (string str2 in eventAndHanlerMapping.Keys)
            {
                str3 = eventAndHanlerMapping[str2];
                MethodInfo info3 = typeOfEventHandler.GetMethod(str3);
                Type[] parametersType = EmitHelper.GetParametersType(info3);
                MethodBuilder builder3 = typeBuilder.DefineMethod("On" + str2, MethodAttributes.Private, typeof(void), parametersType);
                ILGenerator gen = builder3.GetILGenerator();
                gen.Emit(OpCodes.Ldarg_0);
                gen.Emit(OpCodes.Ldfld, field);
                int num = 0;
                foreach (Type type in parametersType)
                {
                    EmitHelper.LoadArg(gen, num + 1);
                    num++;
                }
                gen.Emit(OpCodes.Callvirt, info3);
                gen.Emit(OpCodes.Ret);
                dictionary.Add("On" + str2, builder3);
            }
            MethodInfo method = typeof(IEventBridge).GetMethod("Initialize");
            MethodBuilder methodInfoBody = EmitHelper.DefineDerivedMethodSignature(typeBuilder, method);
            ILGenerator generator3 = methodInfoBody.GetILGenerator();
            foreach (string str2 in eventAndHanlerMapping.Keys)
            {
                EventInfo info5 = typeOfEventPublisher.GetEvent(str2, BindingFlags.Public | BindingFlags.Instance);
                MethodInfo addMethod = info5.GetAddMethod();
                str3 = "On" + str2;
                generator3.Emit(OpCodes.Ldarg_0);
                generator3.Emit(OpCodes.Ldfld, info2);
                generator3.Emit(OpCodes.Ldarg_0);
                generator3.Emit(OpCodes.Ldftn, dictionary[str3]);
                generator3.Emit(OpCodes.Newobj, info5.EventHandlerType.GetConstructor(new Type[] { typeof(object), typeof(IntPtr) }));
                generator3.Emit(OpCodes.Callvirt, addMethod);
            }
            generator3.Emit(OpCodes.Ret);
            typeBuilder.DefineMethodOverride(methodInfoBody, method);
            Type type2 = typeBuilder.CreateType();
            this.eventBridgeTypeDictionary.Add(key, type2);
            return type2;
        }

        public Type EmitEventBridgeType(Type typeOfEventPublisher, Type typeOfEventHandler, string eventHandlerNamePrefix)
        {
            Dictionary<string, string> eventAndHanlerMapping = new Dictionary<string, string>();
            foreach (EventInfo info in typeOfEventPublisher.GetEvents())
            {
                string name = eventHandlerNamePrefix + info.Name;
                MethodInfo method = typeOfEventHandler.GetMethod(name);
                if (method == null)
                {
                    throw new Exception(string.Format("Can't find proper handler for {0}.{1} event in {2}!", typeOfEventPublisher, info.Name, typeOfEventHandler));
                }
                Type[] parametersType = EmitHelper.GetParametersType(method);
                Type[] typeArray2 = EmitHelper.GetParametersType(info.EventHandlerType.GetMethod("Invoke"));
                if (parametersType.Length != typeArray2.Length)
                {
                    throw new Exception(string.Format("Can't find proper handler for {0}.{1} event in {2}!", typeOfEventPublisher, info.Name, typeOfEventHandler));
                }
                for (int i = 0; i < parametersType.Length; i++)
                {
                    if (parametersType[i] != typeArray2[i])
                    {
                        throw new Exception(string.Format("Can't find proper handler for {0}.{1} event in {2}!", typeOfEventPublisher, info.Name, typeOfEventHandler));
                    }
                }
                eventAndHanlerMapping.Add(info.Name, name);
            }
            return this.EmitEventBridgeType(typeOfEventPublisher, typeOfEventHandler, eventAndHanlerMapping);
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

