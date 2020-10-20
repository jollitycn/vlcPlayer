namespace CJBasic.ObjectManagement.Pool
{
    using System;

    public interface IObjectPool<TObject> where TObject: class
    {
        void GiveBack(TObject obj);
        void Initialize();
        TObject Rent();

        int DetectSpanInMSecs { get; set; }

        int MaxObjectCount { get; set; }

        int MinObjectCount { get; set; }

        IPooledObjectCreator<TObject> PooledObjectCreator { set; }
    }
}

