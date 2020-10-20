namespace CJBasic.ObjectManagement.Pool
{
    using System;

    public interface IPooledObjectCreator<TObject> where TObject: class
    {
        TObject Create();
        void Reset(TObject obj);
    }
}

