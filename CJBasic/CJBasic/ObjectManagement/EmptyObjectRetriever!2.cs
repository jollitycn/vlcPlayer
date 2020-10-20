namespace CJBasic.ObjectManagement
{
    using System;
    using System.Collections.Generic;

    public class EmptyObjectRetriever<Tkey, TVal> : IObjectRetriever<Tkey, TVal>
    {
        public TVal Retrieve(Tkey id)
        {
            return default(TVal);
        }

        public IDictionary<Tkey, TVal> RetrieveAll()
        {
            return new Dictionary<Tkey, TVal>();
        }
    }
}

