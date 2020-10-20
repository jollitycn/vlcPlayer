namespace CJBasic.Emit.ForEntity
{
    using CJBasic.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;

    public class DynamicEntityEmitter
    {
        private string assemblyName;
        private AssemblyBuilder dynamicAssembly;
        protected ModuleBuilder moduleBuilder;
        private bool saveFile;
        private string theFileName;

        public DynamicEntityEmitter() : this(false)
        {
        }

        public DynamicEntityEmitter(bool save)
        {
            this.saveFile = false;
            this.assemblyName = "DynamicEntityAssembly";
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

        public Type EmitEntityType(string entityTypeName, IDictionary<string, Type> entityPropertyDic, Type parentInterfaceType)
        {
            string name = string.Format("{0}.{1}", this.assemblyName, entityTypeName);
            TypeBuilder builder = this.moduleBuilder.DefineType(name, TypeAttributes.Serializable | TypeAttributes.Public);
            if (parentInterfaceType != null)
            {
                builder.AddInterfaceImplementation(parentInterfaceType);
            }
            List<FieldBuilder> list = new List<FieldBuilder>();
            foreach (string str2 in entityPropertyDic.Keys)
            {
                PropertyInfo property = parentInterfaceType.GetProperty(str2);
                Type type = entityPropertyDic[str2];
                FieldBuilder item = builder.DefineField("m_" + str2, type, FieldAttributes.Private);
                list.Add(item);
                item.SetConstant(TypeHelper.ChangeType(type, TypeHelper.GetDefaultValue(type)));
                PropertyBuilder builder3 = builder.DefineProperty(str2, PropertyAttributes.None, type, null);
                MethodBuilder methodInfoBody = builder.DefineMethod("get", MethodAttributes.SpecialName | MethodAttributes.HideBySig | MethodAttributes.Virtual | MethodAttributes.Public, type, Type.EmptyTypes);
                ILGenerator generator = methodInfoBody.GetILGenerator();
                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldfld, item);
                generator.Emit(OpCodes.Ret);
                if ((property != null) && property.CanRead)
                {
                    MethodInfo getMethod = property.GetGetMethod();
                    builder.DefineMethodOverride(methodInfoBody, getMethod);
                }
                MethodBuilder builder5 = builder.DefineMethod("set", MethodAttributes.SpecialName | MethodAttributes.HideBySig | MethodAttributes.Virtual | MethodAttributes.Public, null, new Type[] { type });
                ILGenerator generator2 = builder5.GetILGenerator();
                generator2.Emit(OpCodes.Ldarg_0);
                generator2.Emit(OpCodes.Ldarg_1);
                generator2.Emit(OpCodes.Stfld, item);
                generator2.Emit(OpCodes.Ret);
                if ((property != null) && property.CanWrite)
                {
                    MethodInfo setMethod = property.GetSetMethod();
                    builder.DefineMethodOverride(builder5, setMethod);
                }
                builder3.SetGetMethod(methodInfoBody);
                builder3.SetSetMethod(builder5);
            }
            ILGenerator iLGenerator = builder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes).GetILGenerator();
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Call, typeof(object).GetConstructor(new Type[0]));
            foreach (FieldBuilder builder2 in list)
            {
                if (builder2.FieldType == typeof(string))
                {
                    iLGenerator.Emit(OpCodes.Ldarg_0);
                    iLGenerator.Emit(OpCodes.Ldstr, "");
                    iLGenerator.Emit(OpCodes.Stfld, builder2);
                }
            }
            iLGenerator.Emit(OpCodes.Ret);
            return builder.CreateType();
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

