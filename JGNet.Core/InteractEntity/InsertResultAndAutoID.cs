using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class InsertResultAndAutoID
    {
        public InsertResult InsertResult { get; set; }

        public int AutoID { set; get; }
    }
}
