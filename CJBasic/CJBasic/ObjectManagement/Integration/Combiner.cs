namespace CJBasic.ObjectManagement.Integration
{
    using System;
    using System.Collections.Generic;

    public static class Combiner
    {
        public static void CombineIntoContainer<TID, TObj>(ref IDictionary<TID, TObj> container, params IEnumerable<TObj>[] collectionAry) where TObj: ICombined<TID, TObj>
        {
            if (collectionAry != null)
            {
                foreach (IList<TObj> list in collectionAry)
                {
                    if (list != null)
                    {
                        foreach (TObj local in list)
                        {
                            if (!container.ContainsKey(local.ID))
                            {
                                container.Add(local.ID, local);
                            }
                            else
                            {
                                container[local.ID].Combine(local);
                            }
                        }
                    }
                }
            }
        }

        public static IDictionary<TID, TObj> CombineOnSameID<TID, TObj>(IEnumerable<IList<TObj>> listAry) where TObj: ICombined<TID, TObj>
        {
            IDictionary<TID, TObj> dictionary = new Dictionary<TID, TObj>();
            if (listAry != null)
            {
                foreach (IList<TObj> list in listAry)
                {
                    if (list != null)
                    {
                        foreach (TObj local in list)
                        {
                            if (!dictionary.ContainsKey(local.ID))
                            {
                                dictionary.Add(local.ID, local);
                            }
                            else
                            {
                                dictionary[local.ID].Combine(local);
                            }
                        }
                    }
                }
            }
            return dictionary;
        }
    }
}

