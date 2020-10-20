namespace CJBasic.ObjectManagement.Trees.Multiple
{
    using System;

    public interface IMTreeVal
    {
        string CurrentID { get; }

        int DepthIndex { get; }

        string FatherID { get; }
    }
}

