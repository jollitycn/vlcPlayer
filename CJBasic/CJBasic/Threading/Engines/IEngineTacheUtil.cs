namespace CJBasic.Threading.Engines
{
    using System;

    public interface IEngineTacheUtil
    {
        void Clear();
        object GetObject(string name);
        void RegisterObject(string name, object obj);
        void Remove(string name);
    }
}

