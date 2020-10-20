namespace CJBasic.Addins
{
    using System;

    public interface IAddin
    {
        void BeforeTerminating();
        void OnLoading();

        int AddinKey { get; }

        string AddinName { get; }

        string Description { get; }

        bool Enabled { get; set; }

        float Version { get; }
    }
}

