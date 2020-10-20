namespace CJBasic.Widget
{
    using CJBasic;
    using System;

    public interface IPageController
    {
        event CbGeneric CurrentPageIndexChanged;

        event CbGeneric PageCountChanged;

        int CurrentPageIndex { get; set; }

        int PageCount { get; }
    }
}

