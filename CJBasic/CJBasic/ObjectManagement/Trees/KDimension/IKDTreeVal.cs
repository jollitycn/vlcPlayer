namespace CJBasic.ObjectManagement.Trees.KDimension
{
    using System;
    using System.Reflection;

    public interface IKDTreeVal
    {
        IComparable this[int index] { get; }
    }
}

