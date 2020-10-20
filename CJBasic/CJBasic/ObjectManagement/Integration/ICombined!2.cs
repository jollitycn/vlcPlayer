namespace CJBasic.ObjectManagement.Integration
{
    using System;

    public interface ICombined<TID, TCombinedObj>
    {
        void Combine(TCombinedObj obj);

        TID ID { get; }
    }
}

