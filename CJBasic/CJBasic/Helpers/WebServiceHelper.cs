﻿namespace CJBasic.Helpers
{
    using Microsoft.CSharp;
    using System;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Net;
    using System.Reflection;
    using System.Text;
    using System.Web.Services.Description;

    public static class WebServiceHelper
    {
        private static IDictionary<string, Type> WSProxyTypeDictionary = new Dictionary<string, Type>();

        private static string GetWsClassName(string wsUrl)
        {
            string[] strArray = wsUrl.Split(new char[] { '/' });
            return strArray[strArray.Length - 1].Split(new char[] { '.' })[0];
        }

        public static Type GetWsProxyType(string wsUrl, string classname)
        {
            string name = "CJBasic.WebService.DynamicWebCalling";
            if ((classname == null) || (classname == ""))
            {
                classname = GetWsClassName(wsUrl);
            }
            string key = wsUrl + "@" + classname;
            if (WSProxyTypeDictionary.ContainsKey(key))
            {
                return WSProxyTypeDictionary[key];
            }
            WebClient client = new WebClient();
            ServiceDescription serviceDescription = ServiceDescription.Read(client.OpenRead(wsUrl + "?WSDL"));
            ServiceDescriptionImporter importer = new ServiceDescriptionImporter();
            importer.AddServiceDescription(serviceDescription, "", "");
            CodeNamespace namespace2 = new CodeNamespace(name);
            CodeCompileUnit codeCompileUnit = new CodeCompileUnit();
            codeCompileUnit.Namespaces.Add(namespace2);
            importer.Import(namespace2, codeCompileUnit);
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters options = new CompilerParameters();
            options.GenerateExecutable = false;
            options.GenerateInMemory = true;
            options.ReferencedAssemblies.Add("System.dll");
            options.ReferencedAssemblies.Add("System.XML.dll");
            options.ReferencedAssemblies.Add("System.Web.Services.dll");
            options.ReferencedAssemblies.Add("System.Data.dll");
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
            Type[] types = compiledAssembly.GetTypes();
            Type type = compiledAssembly.GetType(name + "." + classname, true, true);
            lock (WSProxyTypeDictionary)
            {
                if (!WSProxyTypeDictionary.ContainsKey(key))
                {
                    WSProxyTypeDictionary.Add(key, type);
                }
            }
            return type;
        }

        public static object InvokeWebService(string wsUrl, string methodname, object[] args)
        {
            return InvokeWebService(wsUrl, null, methodname, args);
        }

        public static object InvokeWebService(string wsUrl, string classname, string methodname, object[] args)
        {
            object obj3;
            try
            {
                Type wsProxyType = GetWsProxyType(wsUrl, classname);
                object obj2 = Activator.CreateInstance(wsProxyType);
                obj3 = wsProxyType.GetMethod(methodname).Invoke(obj2, args);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return obj3;
        }
    }
}

