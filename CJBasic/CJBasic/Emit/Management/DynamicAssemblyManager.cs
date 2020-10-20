namespace CJBasic.Emit.Management
{
    using CJBasic.ObjectManagement.Managers;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class DynamicAssemblyManager
    {
        private IObjectManager<string, Assembly> assemblyManager = new ObjectManager<string, Assembly>();

        public DynamicAssemblyManager()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(this.CurrentDomain_AssemblyResolve);
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.FullName == args.Name)
                {
                    return assembly;
                }
            }
            return this.assemblyManager.Get(args.Name);
        }

        public IList<Assembly> GetAll()
        {
            return this.assemblyManager.GetAll();
        }

        public Assembly GetDynamicAssembly(string assmFullName)
        {
            return this.assemblyManager.Get(assmFullName);
        }

        public void RegisterAppDomain(AppDomain domain)
        {
            domain.AssemblyResolve += new ResolveEventHandler(this.CurrentDomain_AssemblyResolve);
        }

        public void RegisterDynamicAssembly(Assembly assm)
        {
            this.assemblyManager.Add(assm.FullName, assm);
        }
    }
}

