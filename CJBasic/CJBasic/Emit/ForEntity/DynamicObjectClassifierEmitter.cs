namespace CJBasic.Emit.ForEntity
{
    using CJBasic.Arithmetic;
    using CJBasic.Collections;
    using CJBasic.Emit;
    using CJBasic.Helpers;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;

    public class DynamicObjectClassifierEmitter
    {
        public const string AssemblyName = "DynamicObjectClassifierAssembly";
        private AssemblyBuilder dynamicAssembly;
        protected ModuleBuilder moduleBuilder;
        private bool saveFile;
        private string theFileName;

        public DynamicObjectClassifierEmitter() : this(false)
        {
        }

        public DynamicObjectClassifierEmitter(bool save)
        {
            this.saveFile = false;
            this.saveFile = save;
            this.theFileName = "DynamicObjectClassifierAssembly.dll";
            AssemblyBuilderAccess access = this.saveFile ? AssemblyBuilderAccess.RunAndSave : AssemblyBuilderAccess.Run;
            this.dynamicAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(new System.Reflection.AssemblyName("DynamicObjectClassifierAssembly"), access);
            if (this.saveFile)
            {
                this.moduleBuilder = this.dynamicAssembly.DefineDynamicModule("MainModule", this.theFileName);
            }
            else
            {
                this.moduleBuilder = this.dynamicAssembly.DefineDynamicModule("MainModule");
            }
        }

        public static List<object[]> AdjustMappingValues(object[] propertyValues4Classify, IList[] distinctValList)
        {
            int num;
            List<object[]> list = new List<object[]>();
            Dictionary<int, IList<object>> dictionary = new Dictionary<int, IList<object>>();
            for (num = 0; num < propertyValues4Classify.Length; num++)
            {
                if (propertyValues4Classify[num] == null)
                {
                    List<object> list2 = new List<object>();
                    foreach (object obj2 in distinctValList[num])
                    {
                        list2.Add(obj2);
                    }
                    dictionary.Add(num, list2);
                }
                else
                {
                    IList<object> list3 = new List<object>();
                    list3.Add(propertyValues4Classify[num]);
                    dictionary.Add(num, list3);
                }
            }
            SimpleCrossJoiner<object> joiner = new SimpleCrossJoiner<object>();
            for (num = 0; num < propertyValues4Classify.Length; num++)
            {
                joiner.CrossJoin(dictionary[num]);
            }
            foreach (CrossJoinPath<object> path in joiner.Result)
            {
                list.Add(path.Path.ToArray());
            }
            return list;
        }

        private void EmitAddMethod<TEntity>(int tierNumber, Type entityType, Type baseType, Type nestedDicType, TypeBuilder typeBuilder, Type[] nestedKeyTypes, FieldBuilder dicField, FieldBuilder columns4ClassifyField, FieldBuilder containerListField, Dictionary<int, FieldBuilder> distinctArrayFieldInfoDic, FieldBuilder containerCreatorField, FieldBuilder propertyQuickerField)
        {
            int num;
            MethodInfo info8;
            MethodInfo method = ReflectionHelper.SearchMethod(baseType, "Add", new Type[] { entityType });
            MethodBuilder methodInfoBody = typeBuilder.DefineMethod("Add", method.Attributes & ~MethodAttributes.Abstract, method.CallingConvention, method.ReturnType, EmitHelper.GetParametersType(method));
            ILGenerator iLGenerator = methodInfoBody.GetILGenerator();
            MethodInfo meth = typeof(IPropertyQuicker<TEntity>).GetMethod("GetPropertyValue");
            MethodInfo info3 = typeof(IObjectContainerCreator<TEntity>).GetMethod("CreateNewContainer");
            MethodInfo info4 = typeof(IObjectContainer<TEntity>).GetMethod("Add");
            MethodInfo info5 = typeof(Activator).GetMethod("CreateInstance", new Type[] { typeof(Type) });
            MethodInfo info6 = typeof(List<IObjectContainer<TEntity>>).GetMethod("Add");
            LocalBuilder[] builderArray = new LocalBuilder[nestedKeyTypes.Length];
            Type localType = nestedDicType;
            LocalBuilder local = iLGenerator.DeclareLocal(localType);
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldfld, dicField);
            iLGenerator.Emit(OpCodes.Stloc, local);
            for (num = 0; num < tierNumber; num++)
            {
                MethodInfo info7 = localType.GetMethod("ContainsKey");
                info8 = localType.GetMethod("get_Item");
                MethodInfo info9 = localType.GetMethod("Add");
                MethodInfo info10 = typeof(SortedArray<>).MakeGenericType(new Type[] { nestedKeyTypes[num] }).GetMethod("Add", new Type[] { nestedKeyTypes[num] });
                Label label = iLGenerator.DefineLabel();
                builderArray[num] = iLGenerator.DeclareLocal(nestedKeyTypes[num]);
                iLGenerator.Emit(OpCodes.Ldarg_0);
                iLGenerator.Emit(OpCodes.Ldfld, propertyQuickerField);
                iLGenerator.Emit(OpCodes.Ldarg_1);
                iLGenerator.Emit(OpCodes.Ldarg_0);
                iLGenerator.Emit(OpCodes.Ldfld, columns4ClassifyField);
                iLGenerator.Emit(OpCodes.Ldc_I4, num);
                iLGenerator.Emit(OpCodes.Ldelem_Ref);
                iLGenerator.Emit(OpCodes.Callvirt, meth);
                iLGenerator.Emit(OpCodes.Unbox_Any, nestedKeyTypes[num]);
                iLGenerator.Emit(OpCodes.Stloc, builderArray[num]);
                iLGenerator.Emit(OpCodes.Ldarg_0);
                iLGenerator.Emit(OpCodes.Ldfld, distinctArrayFieldInfoDic[num]);
                iLGenerator.Emit(OpCodes.Ldloc, builderArray[num]);
                iLGenerator.Emit(OpCodes.Call, info10);
                iLGenerator.Emit(OpCodes.Ldloc, local);
                iLGenerator.Emit(OpCodes.Ldloc, builderArray[num]);
                iLGenerator.Emit(OpCodes.Callvirt, info7);
                iLGenerator.Emit(OpCodes.Brtrue, label);
                iLGenerator.Emit(OpCodes.Nop);
                iLGenerator.Emit(OpCodes.Ldloc, local);
                iLGenerator.Emit(OpCodes.Ldloc, builderArray[num]);
                if (num == (tierNumber - 1))
                {
                    LocalBuilder builder3 = iLGenerator.DeclareLocal(typeof(IObjectContainer<TEntity>));
                    iLGenerator.Emit(OpCodes.Ldarg_0);
                    iLGenerator.Emit(OpCodes.Ldfld, containerCreatorField);
                    iLGenerator.Emit(OpCodes.Callvirt, info3);
                    iLGenerator.Emit(OpCodes.Stloc, builder3);
                    iLGenerator.Emit(OpCodes.Ldarg_0);
                    iLGenerator.Emit(OpCodes.Ldfld, containerListField);
                    iLGenerator.Emit(OpCodes.Ldloc, builder3);
                    iLGenerator.Emit(OpCodes.Callvirt, info6);
                    iLGenerator.Emit(OpCodes.Ldloc, builder3);
                    iLGenerator.Emit(OpCodes.Callvirt, info9);
                    iLGenerator.Emit(OpCodes.Nop);
                    iLGenerator.MarkLabel(label);
                }
                else
                {
                    localType = localType.GetGenericArguments()[1];
                    iLGenerator.Emit(OpCodes.Newobj, localType.GetConstructor(Type.EmptyTypes));
                    iLGenerator.Emit(OpCodes.Callvirt, info9);
                    iLGenerator.Emit(OpCodes.Nop);
                    iLGenerator.MarkLabel(label);
                    iLGenerator.Emit(OpCodes.Ldloc, local);
                    iLGenerator.Emit(OpCodes.Ldloc, builderArray[num]);
                    iLGenerator.Emit(OpCodes.Callvirt, info8);
                    local = iLGenerator.DeclareLocal(localType);
                    iLGenerator.Emit(OpCodes.Stloc, local);
                }
            }
            Type type2 = nestedDicType;
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldfld, dicField);
            for (num = 0; num < tierNumber; num++)
            {
                info8 = type2.GetMethod("get_Item");
                iLGenerator.Emit(OpCodes.Ldloc, builderArray[num]);
                iLGenerator.Emit(OpCodes.Callvirt, info8);
                type2 = type2.GetGenericArguments()[1];
            }
            iLGenerator.Emit(OpCodes.Ldarg_1);
            iLGenerator.Emit(OpCodes.Callvirt, info4);
            iLGenerator.Emit(OpCodes.Nop);
            iLGenerator.Emit(OpCodes.Ret);
            typeBuilder.DefineMethodOverride(methodInfoBody, method);
        }

        private MethodBuilder EmitDoGetContainerMethod<TEntity>(int tierNumber, Type entityType, Type baseType, Type nestedDicType, TypeBuilder typeBuilder, Type[] nestedKeyTypes, FieldBuilder dicField, FieldBuilder columns4ClassifyField)
        {
            int num;
            MethodInfo info2;
            MethodBuilder builder = typeBuilder.DefineMethod("DoGetContainer", MethodAttributes.Private, typeof(IObjectContainer<TEntity>), new Type[] { typeof(object[]) });
            ILGenerator iLGenerator = builder.GetILGenerator();
            LocalBuilder local = iLGenerator.DeclareLocal(typeof(IObjectContainer<TEntity>));
            Label label = iLGenerator.DefineLabel();
            LocalBuilder[] builderArray = new LocalBuilder[nestedKeyTypes.Length];
            Type localType = nestedDicType;
            LocalBuilder builder3 = iLGenerator.DeclareLocal(localType);
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldfld, dicField);
            iLGenerator.Emit(OpCodes.Stloc, builder3);
            for (num = 0; num < nestedKeyTypes.Length; num++)
            {
                Label label2 = iLGenerator.DefineLabel();
                MethodInfo method = localType.GetMethod("ContainsKey");
                info2 = localType.GetMethod("get_Item");
                builderArray[num] = iLGenerator.DeclareLocal(nestedKeyTypes[num]);
                iLGenerator.Emit(OpCodes.Ldarg_1);
                iLGenerator.Emit(OpCodes.Ldc_I4, num);
                iLGenerator.Emit(OpCodes.Ldelem_Ref);
                iLGenerator.Emit(OpCodes.Unbox_Any, nestedKeyTypes[num]);
                iLGenerator.Emit(OpCodes.Stloc, builderArray[num]);
                iLGenerator.Emit(OpCodes.Ldloc, builder3);
                iLGenerator.Emit(OpCodes.Ldloc, builderArray[num]);
                iLGenerator.Emit(OpCodes.Callvirt, method);
                iLGenerator.Emit(OpCodes.Brtrue, label2);
                iLGenerator.Emit(OpCodes.Nop);
                iLGenerator.Emit(OpCodes.Ldnull);
                iLGenerator.Emit(OpCodes.Stloc, local);
                iLGenerator.Emit(OpCodes.Br, label);
                iLGenerator.MarkLabel(label2);
                if (num < (nestedKeyTypes.Length - 1))
                {
                    localType = localType.GetGenericArguments()[1];
                    iLGenerator.Emit(OpCodes.Ldloc, builder3);
                    iLGenerator.Emit(OpCodes.Ldloc, builderArray[num]);
                    iLGenerator.Emit(OpCodes.Callvirt, info2);
                    builder3 = iLGenerator.DeclareLocal(localType);
                    iLGenerator.Emit(OpCodes.Stloc, builder3);
                }
            }
            Type type2 = nestedDicType;
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldfld, dicField);
            for (num = 0; num < nestedKeyTypes.Length; num++)
            {
                info2 = type2.GetMethod("get_Item");
                iLGenerator.Emit(OpCodes.Ldloc, builderArray[num]);
                iLGenerator.Emit(OpCodes.Callvirt, info2);
                type2 = type2.GetGenericArguments()[1];
            }
            iLGenerator.Emit(OpCodes.Stloc, local);
            iLGenerator.MarkLabel(label);
            iLGenerator.Emit(OpCodes.Ldloc, local);
            iLGenerator.Emit(OpCodes.Ret);
            return builder;
        }

        public Type EmitDynamicNTierDictionaryType<TObject>(Type[] nestedKeyTypes)
        {
            int num2;
            Type entityType = typeof(TObject);
            int length = nestedKeyTypes.Length;
            string str = entityType.ToString();
            for (num2 = 0; num2 < nestedKeyTypes.Length; num2++)
            {
                str = str + "_" + TypeHelper.GetClassSimpleName(nestedKeyTypes[num2]);
            }
            Type interfaceType = typeof(IObjectClassifier<TObject>);
            string name = string.Format("{0}_Classifier", str);
            TypeBuilder typeBuilder = this.moduleBuilder.DefineType(name, TypeAttributes.Public);
            typeBuilder.AddInterfaceImplementation(interfaceType);
            typeBuilder.SetCustomAttribute(new CustomAttributeBuilder(typeof(SerializableAttribute).GetConstructor(Type.EmptyTypes), new object[0]));
            Type type = typeof(Dictionary<,>).MakeGenericType(new Type[] { nestedKeyTypes[length - 1], typeof(IObjectContainer<TObject>) });
            if (length > 1)
            {
                for (num2 = nestedKeyTypes.Length - 2; num2 >= 0; num2--)
                {
                    type = typeof(Dictionary<,>).MakeGenericType(new Type[] { nestedKeyTypes[num2], type });
                }
            }
            FieldBuilder field = typeBuilder.DefineField("dic", type, FieldAttributes.Private);
            FieldBuilder builder3 = typeBuilder.DefineField("columns4Classify", typeof(string[]), FieldAttributes.Private);
            FieldBuilder builder4 = typeBuilder.DefineField("containerList", typeof(List<IObjectContainer<TObject>>), FieldAttributes.Private);
            FieldBuilder containerCreatorField = typeBuilder.DefineField("containerCreator", typeof(IObjectContainerCreator<TObject>), FieldAttributes.Private);
            containerCreatorField.SetCustomAttribute(new CustomAttributeBuilder(typeof(NonSerializedAttribute).GetConstructor(Type.EmptyTypes), new object[0]));
            FieldBuilder propertyQuickerField = typeBuilder.DefineField("propertyQuicker", typeof(IPropertyQuicker<TObject>), FieldAttributes.Private);
            propertyQuickerField.SetCustomAttribute(new CustomAttributeBuilder(typeof(NonSerializedAttribute).GetConstructor(Type.EmptyTypes), new object[0]));
            Dictionary<int, FieldBuilder> distinctArrayFieldInfoDic = new Dictionary<int, FieldBuilder>();
            for (num2 = 0; num2 < nestedKeyTypes.Length; num2++)
            {
                distinctArrayFieldInfoDic.Add(num2, typeBuilder.DefineField("distinctArray" + num2.ToString(), typeof(SortedArray<>).MakeGenericType(new Type[] { nestedKeyTypes[num2] }), FieldAttributes.Private));
            }
            ILGenerator iLGenerator = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new Type[] { typeof(string[]) }).GetILGenerator();
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Newobj, type.GetConstructor(Type.EmptyTypes));
            iLGenerator.Emit(OpCodes.Stfld, field);
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Newobj, typeof(List<IObjectContainer<TObject>>).GetConstructor(Type.EmptyTypes));
            iLGenerator.Emit(OpCodes.Stfld, builder4);
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldarg_1);
            iLGenerator.Emit(OpCodes.Stfld, builder3);
            for (num2 = 0; num2 < nestedKeyTypes.Length; num2++)
            {
                iLGenerator.Emit(OpCodes.Ldarg_0);
                iLGenerator.Emit(OpCodes.Newobj, typeof(SortedArray<>).MakeGenericType(new Type[] { nestedKeyTypes[num2] }).GetConstructor(Type.EmptyTypes));
                iLGenerator.Emit(OpCodes.Stfld, distinctArrayFieldInfoDic[num2]);
            }
            iLGenerator.Emit(OpCodes.Ret);
            this.EmitInitializeMethod<TObject>(interfaceType, typeBuilder, containerCreatorField, propertyQuickerField);
            this.EmitAddMethod<TObject>(length, entityType, interfaceType, type, typeBuilder, nestedKeyTypes, field, builder3, builder4, distinctArrayFieldInfoDic, containerCreatorField, propertyQuickerField);
            MethodBuilder doGetContainerMethodBuilder = this.EmitDoGetContainerMethod<TObject>(length, entityType, interfaceType, type, typeBuilder, nestedKeyTypes, field, builder3);
            this.EmitGetContainersMethod<TObject>(interfaceType, typeBuilder, nestedKeyTypes, distinctArrayFieldInfoDic, doGetContainerMethodBuilder);
            this.EmitGetAllContainersMethod(interfaceType, typeBuilder, builder4);
            this.EmitGetDistinctValuesMethod(interfaceType, typeBuilder, nestedKeyTypes, builder3, distinctArrayFieldInfoDic);
            this.EmitProperties4ClassifyProperty(interfaceType, typeBuilder, builder3);
            return typeBuilder.CreateType();
        }

        private void EmitGetAllContainersMethod(Type baseType, TypeBuilder typeBuilder, FieldBuilder containerListField)
        {
            MethodInfo method = ReflectionHelper.SearchMethod(baseType, "GetAllContainers", new Type[0]);
            MethodBuilder methodInfoBody = typeBuilder.DefineMethod("GetAllContainers", method.Attributes & ~MethodAttributes.Abstract, method.CallingConvention, method.ReturnType, EmitHelper.GetParametersType(method));
            ILGenerator iLGenerator = methodInfoBody.GetILGenerator();
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldfld, containerListField);
            iLGenerator.Emit(OpCodes.Ret);
            typeBuilder.DefineMethodOverride(methodInfoBody, method);
        }

        private void EmitGetContainersMethod<TEntity>(Type baseType, TypeBuilder typeBuilder, Type[] nestedKeyTypes, Dictionary<int, FieldBuilder> distinctArrayFieldInfoDic, MethodBuilder doGetContainerMethodBuilder)
        {
            MethodInfo method = ReflectionHelper.SearchMethod(baseType, "GetContainers", new Type[] { typeof(object[]) });
            MethodBuilder methodInfoBody = typeBuilder.DefineMethod("GetContainers", method.Attributes & ~MethodAttributes.Abstract, method.CallingConvention, method.ReturnType, EmitHelper.GetParametersType(method));
            ILGenerator iLGenerator = methodInfoBody.GetILGenerator();
            LocalBuilder local = iLGenerator.DeclareLocal(typeof(IList[]));
            iLGenerator.Emit(OpCodes.Ldc_I4, nestedKeyTypes.Length);
            iLGenerator.Emit(OpCodes.Newarr, typeof(IList));
            iLGenerator.Emit(OpCodes.Stloc, local);
            for (int i = 0; i < nestedKeyTypes.Length; i++)
            {
                MethodInfo info2 = typeof(SortedArray<>).MakeGenericType(new Type[] { nestedKeyTypes[i] }).GetMethod("GetAll", new Type[0]);
                iLGenerator.Emit(OpCodes.Ldloc, local);
                iLGenerator.Emit(OpCodes.Ldc_I4, i);
                iLGenerator.Emit(OpCodes.Ldarg_0);
                iLGenerator.Emit(OpCodes.Ldfld, distinctArrayFieldInfoDic[i]);
                iLGenerator.Emit(OpCodes.Call, info2);
                iLGenerator.Emit(OpCodes.Stelem_Ref);
            }
            LocalBuilder builder3 = iLGenerator.DeclareLocal(typeof(List<object[]>));
            LocalBuilder builder4 = iLGenerator.DeclareLocal(typeof(List<IObjectContainer<TEntity>>));
            LocalBuilder builder5 = iLGenerator.DeclareLocal(typeof(IObjectContainer<TEntity>));
            LocalBuilder builder6 = iLGenerator.DeclareLocal(typeof(int));
            Label loc = iLGenerator.DefineLabel();
            Label label = iLGenerator.DefineLabel();
            Label label3 = iLGenerator.DefineLabel();
            MethodInfo meth = typeof(DynamicObjectClassifierEmitter).GetMethod("AdjustMappingValues", BindingFlags.Public | BindingFlags.Static);
            MethodInfo info4 = typeof(List<object[]>).GetMethod("get_Item", new Type[] { typeof(int) });
            MethodInfo info5 = typeof(List<IObjectContainer<TEntity>>).GetMethod("Add");
            MethodInfo info6 = typeof(List<object[]>).GetMethod("get_Count");
            iLGenerator.Emit(OpCodes.Ldarg_1);
            iLGenerator.Emit(OpCodes.Ldloc, local);
            iLGenerator.Emit(OpCodes.Call, meth);
            iLGenerator.Emit(OpCodes.Stloc, builder3);
            iLGenerator.Emit(OpCodes.Newobj, typeof(List<IObjectContainer<TEntity>>).GetConstructor(Type.EmptyTypes));
            iLGenerator.Emit(OpCodes.Stloc, builder4);
            iLGenerator.Emit(OpCodes.Ldc_I4_0);
            iLGenerator.Emit(OpCodes.Stloc, builder6);
            iLGenerator.Emit(OpCodes.Br, label3);
            iLGenerator.MarkLabel(loc);
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldloc, builder3);
            iLGenerator.Emit(OpCodes.Ldloc, builder6);
            iLGenerator.Emit(OpCodes.Callvirt, info4);
            iLGenerator.Emit(OpCodes.Call, doGetContainerMethodBuilder);
            iLGenerator.Emit(OpCodes.Stloc, builder5);
            iLGenerator.Emit(OpCodes.Ldloc, builder5);
            iLGenerator.Emit(OpCodes.Ldnull);
            iLGenerator.Emit(OpCodes.Ceq);
            iLGenerator.Emit(OpCodes.Brtrue, label);
            iLGenerator.Emit(OpCodes.Ldloc, builder4);
            iLGenerator.Emit(OpCodes.Ldloc, builder5);
            iLGenerator.Emit(OpCodes.Callvirt, info5);
            iLGenerator.Emit(OpCodes.Nop);
            iLGenerator.MarkLabel(label);
            iLGenerator.Emit(OpCodes.Nop);
            iLGenerator.Emit(OpCodes.Ldloc, builder6);
            iLGenerator.Emit(OpCodes.Ldc_I4_1);
            iLGenerator.Emit(OpCodes.Add);
            iLGenerator.Emit(OpCodes.Stloc, builder6);
            iLGenerator.MarkLabel(label3);
            iLGenerator.Emit(OpCodes.Ldloc, builder6);
            iLGenerator.Emit(OpCodes.Ldloc, builder3);
            iLGenerator.Emit(OpCodes.Callvirt, info6);
            iLGenerator.Emit(OpCodes.Clt);
            iLGenerator.Emit(OpCodes.Brtrue, loc);
            iLGenerator.Emit(OpCodes.Ldloc, builder4);
            iLGenerator.Emit(OpCodes.Ret);
            typeBuilder.DefineMethodOverride(methodInfoBody, method);
        }

        private void EmitGetDistinctValuesMethod(Type baseType, TypeBuilder typeBuilder, Type[] nestedKeyTypes, FieldBuilder columns4ClassifyField, Dictionary<int, FieldBuilder> distinctArrayFieldInfoDic)
        {
            MethodInfo method = ReflectionHelper.SearchMethod(baseType, "GetDistinctValues", new Type[] { typeof(string) });
            MethodBuilder methodInfoBody = typeBuilder.DefineMethod("GetDistinctValues", method.Attributes & ~MethodAttributes.Abstract, method.CallingConvention, method.ReturnType, EmitHelper.GetParametersType(method));
            ILGenerator iLGenerator = methodInfoBody.GetILGenerator();
            MethodInfo meth = typeof(string).GetMethod("Equals", new Type[] { typeof(object) });
            LocalBuilder local = iLGenerator.DeclareLocal(typeof(IList));
            iLGenerator.Emit(OpCodes.Ldnull);
            iLGenerator.Emit(OpCodes.Stloc, local);
            for (int i = 0; i < nestedKeyTypes.Length; i++)
            {
                MethodInfo info3 = typeof(SortedArray<>).MakeGenericType(new Type[] { nestedKeyTypes[i] }).GetMethod("GetAll", new Type[0]);
                Label label = iLGenerator.DefineLabel();
                iLGenerator.Emit(OpCodes.Ldarg_0);
                iLGenerator.Emit(OpCodes.Ldfld, columns4ClassifyField);
                iLGenerator.Emit(OpCodes.Ldc_I4, i);
                iLGenerator.Emit(OpCodes.Ldelem_Ref);
                iLGenerator.Emit(OpCodes.Ldarg_1);
                iLGenerator.Emit(OpCodes.Callvirt, meth);
                iLGenerator.Emit(OpCodes.Brfalse, label);
                iLGenerator.Emit(OpCodes.Ldarg_0);
                iLGenerator.Emit(OpCodes.Ldfld, distinctArrayFieldInfoDic[i]);
                iLGenerator.Emit(OpCodes.Call, info3);
                iLGenerator.Emit(OpCodes.Stloc, local);
                iLGenerator.MarkLabel(label);
            }
            iLGenerator.Emit(OpCodes.Ldloc, local);
            iLGenerator.Emit(OpCodes.Ret);
            typeBuilder.DefineMethodOverride(methodInfoBody, method);
        }

        private void EmitInitializeMethod<TObject>(Type baseType, TypeBuilder typeBuilder, FieldBuilder containerCreatorField, FieldBuilder propertyQuickerField)
        {
            MethodInfo method = ReflectionHelper.SearchMethod(baseType, "Initialize", new Type[] { typeof(IObjectContainerCreator<TObject>) });
            MethodBuilder methodInfoBody = typeBuilder.DefineMethod("Initialize", method.Attributes & ~MethodAttributes.Abstract, method.CallingConvention, method.ReturnType, EmitHelper.GetParametersType(method));
            ILGenerator iLGenerator = methodInfoBody.GetILGenerator();
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldarg_1);
            iLGenerator.Emit(OpCodes.Stfld, containerCreatorField);
            iLGenerator.Emit(OpCodes.Ldarg_0);
            MethodInfo meth = typeof(PropertyQuickerFactory).GetMethod("CreatePropertyQuicker", new Type[0]).MakeGenericMethod(new Type[] { typeof(TObject) });
            iLGenerator.Emit(OpCodes.Call, meth);
            iLGenerator.Emit(OpCodes.Stfld, propertyQuickerField);
            iLGenerator.Emit(OpCodes.Ret);
            typeBuilder.DefineMethodOverride(methodInfoBody, method);
        }

        private void EmitProperties4ClassifyProperty(Type baseType, TypeBuilder typeBuilder, FieldBuilder columns4ClassifyField)
        {
            PropertyBuilder builder = typeBuilder.DefineProperty("Properties4Classify", PropertyAttributes.None, typeof(string[]), null);
            MethodInfo method = ReflectionHelper.SearchMethod(baseType, "get_Properties4Classify", Type.EmptyTypes);
            MethodBuilder methodInfoBody = typeBuilder.DefineMethod("get_Properties4Classify", method.Attributes & ~MethodAttributes.Abstract, method.CallingConvention, method.ReturnType, EmitHelper.GetParametersType(method));
            ILGenerator iLGenerator = methodInfoBody.GetILGenerator();
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldfld, columns4ClassifyField);
            iLGenerator.Emit(OpCodes.Ret);
            typeBuilder.DefineMethodOverride(methodInfoBody, method);
            builder.SetGetMethod(methodInfoBody);
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

