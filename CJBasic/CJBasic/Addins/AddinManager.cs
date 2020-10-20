namespace CJBasic.Addins
{
    using CJBasic;
    using CJBasic.Collections;
    using CJBasic.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading;

    public class AddinManager : IAddinManager
    {
        private bool copyToMem = false;
        private IDictionary<int, IAddin> dicAddins = new Dictionary<int, IAddin>();

        public event CbSimple AddinsChanged;

        public AddinManager()
        {
            this.AddinsChanged += delegate {
            };
        }

        public void Clear()
        {
            foreach (IAddin addin in this.dicAddins.Values)
            {
                try
                {
                    addin.BeforeTerminating();
                }
                catch
                {
                }
            }
            this.dicAddins.Clear();
            this.AddinsChanged();
        }

        private bool ContainsAddin(int addinKey)
        {
            return this.dicAddins.ContainsKey(addinKey);
        }

        public void DisableAddin(int addinKey)
        {
            IAddin addin = this.GetAddin(addinKey);
            if (addin != null)
            {
                addin.Enabled = false;
            }
        }

        public void DynRemoveAddin(int addinKey)
        {
            IAddin addin = this.GetAddin(addinKey);
            if (addin != null)
            {
                addin.BeforeTerminating();
                this.dicAddins.Remove(addinKey);
                this.AddinsChanged();
            }
        }

        public void EnableAddin(int addinKey)
        {
            IAddin addin = this.GetAddin(addinKey);
            if (addin != null)
            {
                addin.Enabled = true;
            }
        }

        public IAddin GetAddin(int addinKey)
        {
            if (!this.dicAddins.ContainsKey(addinKey))
            {
                return null;
            }
            return this.dicAddins[addinKey];
        }

        public void LoadAddinAssembly(string assemblyPath)
        {
            Assembly asm = null;
            if (this.copyToMem)
            {
                asm = Assembly.Load(FileHelper.ReadFileReturnBytes(assemblyPath));
            }
            else
            {
                asm = Assembly.LoadFrom(assemblyPath);
            }
            IList<IAddin> list = ReflectionHelper.LoadDerivedInstance<IAddin>(asm);
            foreach (IAddin addin in list)
            {
                this.dicAddins.Add(addin.AddinKey, addin);
                addin.OnLoading();
            }
            this.AddinsChanged();
        }

        public void LoadAllAddins(string addin_FolderPath, bool searchChildFolder)
        {
            ReflectionHelper.TypeLoadConfig config = new ReflectionHelper.TypeLoadConfig(this.copyToMem, false, "Addin.dll");
            IList<Type> list = ReflectionHelper.LoadDerivedType(typeof(IAddin), addin_FolderPath, searchChildFolder, config);
            foreach (Type type in list)
            {
                IAddin addin = (IAddin) Activator.CreateInstance(type);
                this.dicAddins.Add(addin.AddinKey, addin);
                addin.OnLoading();
            }
            this.AddinsChanged();
        }

        public void LoadDefault()
        {
            this.LoadAllAddins(AppDomain.CurrentDomain.BaseDirectory, true);
        }

        public IList<IAddin> AddinList
        {
            get
            {
                return CollectionConverter.CopyAllToList<IAddin>(this.dicAddins.Values);
            }
        }

        public bool CopyToMemory
        {
            get
            {
                return this.copyToMem;
            }
            set
            {
                this.copyToMem = value;
            }
        }
    }
}

