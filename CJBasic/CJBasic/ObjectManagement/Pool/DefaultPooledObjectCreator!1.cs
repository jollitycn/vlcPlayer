namespace CJBasic.ObjectManagement.Pool
{
    using System;

    public class DefaultPooledObjectCreator<TObject> : IPooledObjectCreator<TObject> where TObject: class
    {
        public TObject Create()
        {
            return Activator.CreateInstance<TObject>();
        }

        public void Reset(TObject obj)
        {
        }
    }
}

