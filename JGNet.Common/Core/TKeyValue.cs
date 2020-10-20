using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    /// <summary>
    /// keyvalue对象
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class TKeyValue<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public TKeyValue()
        { 
        }
        public TKeyValue(TKey pKey, TValue pValue)
        {
            this.Key = pKey;
            this.Value = pValue;
        }
        public override string ToString()
        {
            return this.Key != null ? this.Key.ToString() : null;
        }
        
    }
}
