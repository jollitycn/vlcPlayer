namespace CJBasic.Emit.ForEntity
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface IObjectClassifier<TObject>
    {
        void Add(TObject entity);
        List<IObjectContainer<TObject>> GetAllContainers();
        List<IObjectContainer<TObject>> GetContainers(params object[] propertyValues4Classify);
        IList GetDistinctValues(string property4Classify);
        void Initialize(IObjectContainerCreator<TObject> creator);

        string[] Properties4Classify { get; }
    }
}

