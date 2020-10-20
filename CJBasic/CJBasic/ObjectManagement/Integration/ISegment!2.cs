namespace CJBasic.ObjectManagement.Integration
{
    using System.Collections.Generic;

    public interface ISegment<TSegmentID, TVal>
    {
        IList<TVal> GetContent();

        TSegmentID ID { get; }
    }
}

