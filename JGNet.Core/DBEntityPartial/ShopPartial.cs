using System;
using System.Collections.Generic;
using DataRabbit;


namespace JGNet
{
    public partial class Shop
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public Boolean Selected { get; set; }
        
        public string EnbledName
        {
            get {
                if (this.Enabled)
                {
                    return "∆Ù”√";
                }
                else
                {
                    return "“—Ω˚”√";
                }
            }
        }
    }
}
