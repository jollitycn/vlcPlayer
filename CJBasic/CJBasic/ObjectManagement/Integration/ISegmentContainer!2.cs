namespace CJBasic.ObjectManagement.Integration
{
    using System;
    using System.Collections.Generic;

    public interface ISegmentContainer<TSegmentID, TVal>
    {
        List<ISegment<TSegmentID, TVal>> GetAllSegments();
        List<TVal> Pick(int startIndex, int pickCount);

        bool PickFromSmallToBig { get; set; }
    }
}

