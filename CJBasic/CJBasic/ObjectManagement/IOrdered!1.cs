namespace CJBasic.ObjectManagement
{
    using System;

    public interface IOrdered<TOrderedObj>
    {
        bool IsTopThan(TOrderedObj other);
    }
}

