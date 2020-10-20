namespace CJBasic.Threading.Engines
{
    using System;

    public interface IWorkProcesser<T>
    {
        void Process(T work);
    }
}

