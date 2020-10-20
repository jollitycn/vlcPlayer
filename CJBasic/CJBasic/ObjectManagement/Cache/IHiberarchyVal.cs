namespace CJBasic.ObjectManagement.Cache
{
    using CJBasic.ObjectManagement.Trees.Multiple;
    using System;

    public interface IHiberarchyVal : IMTreeVal
    {
        string SequenceCode { get; }
    }
}

