namespace CJBasic.Addins
{
    using CJBasic;
    using System;
    using System.Collections.Generic;

    public interface IAddinManager
    {
        event CbSimple AddinsChanged;

        void Clear();
        void DisableAddin(int addinKey);
        void DynRemoveAddin(int addinKey);
        void EnableAddin(int addinKey);
        IAddin GetAddin(int addinKey);
        void LoadAddinAssembly(string assemblyPath);
        void LoadAllAddins(string addinFolderPath, bool searchChildFolder);
        void LoadDefault();

        IList<IAddin> AddinList { get; }

        bool CopyToMemory { get; set; }
    }
}

