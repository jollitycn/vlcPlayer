namespace CJBasic.ObjectManagement.Cache
{
    using CJBasic.ObjectManagement;
    using CJBasic.ObjectManagement.Trees.Multiple;
    using System;
    using System.Collections.Generic;

    public class HiberarchyAgileNodePicker<TVal> : IAgileNodePicker<TVal>, IObjectRetriever<string, TVal> where TVal: IMTreeVal
    {
        private string rootID;
        private ISmartDictionaryCache<string, TVal> smartDictionaryCache;

        public HiberarchyAgileNodePicker(ISmartDictionaryCache<string, TVal> _cache, string _rootID)
        {
            this.smartDictionaryCache = _cache;
            this.rootID = _rootID;
        }

        public TVal PickupRoot()
        {
            return this.smartDictionaryCache.Get(this.rootID);
        }

        public TVal Retrieve(string id)
        {
            return this.smartDictionaryCache.Get(id);
        }

        public IDictionary<string, TVal> RetrieveAll()
        {
            IDictionary<string, TVal> dictionary = new Dictionary<string, TVal>();
            foreach (string str in this.smartDictionaryCache.GetAllKeyListCopy())
            {
                dictionary.Add(str, this.smartDictionaryCache.Get(str));
            }
            return dictionary;
        }
    }
}

