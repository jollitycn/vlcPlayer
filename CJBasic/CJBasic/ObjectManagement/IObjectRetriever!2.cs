namespace CJBasic.ObjectManagement
{
    using System.Collections.Generic;

    public interface IObjectRetriever<Tkey, TVal>
    {
        TVal Retrieve(Tkey id);
        IDictionary<Tkey, TVal> RetrieveAll();
    }
}

