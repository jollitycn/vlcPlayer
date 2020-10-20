using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.Services.Description;

internal class Class92
{
    private static IDictionary<string, Type> idictionary_0 = new Dictionary<string, Type>();

    public static object smethod_0(string string_0, string string_1, object[] object_0)
    {
        return smethod_1(string_0, null, string_1, object_0);
    }

    public static object smethod_1(string string_0, string string_1, string string_2, object[] object_0)
    {
        object obj3;
        try
        {
            Type type = smethod_3(string_0, string_1);
            object obj2 = Activator.CreateInstance(type);
            obj3 = type.GetMethod(string_2).Invoke(obj2, object_0);
        }
        catch (Exception exception)
        {
            throw exception;
        }
        return obj3;
    }

    private static string smethod_2(string string_0)
    {
        string[] strArray = string_0.Split(new char[] { '/' });
        return strArray[strArray.Length - 1].Split(new char[] { '.' })[0];
    }

    public static Type smethod_3(string string_0, string string_1)
    {
        string name = "CJBasic.WebService.DynamicWebCalling";
        if ((string_1 == null) || (string_1 == ""))
        {
            string_1 = smethod_2(string_0);
        }
        string key = string_0 + "@" + string_1;
        if (idictionary_0.ContainsKey(key))
        {
            return idictionary_0[key];
        }
        WebClient client = new WebClient();
        ServiceDescription serviceDescription = ServiceDescription.Read(client.OpenRead(string_0 + "?WSDL"));
        ServiceDescriptionImporter importer = new ServiceDescriptionImporter();
        importer.AddServiceDescription(serviceDescription, "", "");
        CodeNamespace namespace2 = new CodeNamespace(name);
        CodeCompileUnit codeCompileUnit = new CodeCompileUnit();
        codeCompileUnit.Namespaces.Add(namespace2);
        importer.Import(namespace2, codeCompileUnit);
        CSharpCodeProvider provider = new CSharpCodeProvider();
        CompilerParameters options = new CompilerParameters {
            GenerateExecutable = false,
            GenerateInMemory = true,
            ReferencedAssemblies = { 
                "System.dll",
                "System.XML.dll",
                "System.Web.Services.dll",
                "System.Data.dll"
            }
        };
        CompilerResults results = provider.CompileAssemblyFromDom(options, new CodeCompileUnit[] { codeCompileUnit });
        if (results.Errors.HasErrors)
        {
            StringBuilder builder = new StringBuilder();
            foreach (CompilerError error in results.Errors)
            {
                builder.Append(error.ToString());
                builder.Append(Environment.NewLine);
            }
            throw new Exception(builder.ToString());
        }
        Assembly compiledAssembly = results.CompiledAssembly;
        compiledAssembly.GetTypes();
        Type type = compiledAssembly.GetType(name + "." + string_1, true, true);
        lock (idictionary_0)
        {
            if (!idictionary_0.ContainsKey(key))
            {
                idictionary_0.Add(key, type);
            }
        }
        return type;
    }
}

