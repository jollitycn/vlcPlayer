using JGNet.Core.Const;
using JGNet.Core.MyEnum;
using JGNet.Core.Tools;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class Costume
    {
        public decimal PfPrice { get; set; }

        public Decimal BuyoutPrice { get; set; }
        
        public String SupplierName { get; set; }

        public string CostumePropertyName
        {
            get
            {
                return EnumHelper.GetDescription((CostumeProperty)this.Property);
            }
        }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public String BrandName { get; set; }

        public string CreateTimeString
        {
            get
            {
                return this.m_CreateTime.ToString(SystemDefault.JsonDateTimeFormat);
            }
        }

        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 缩略图地址
        /// </summary>
        //public string PhotoThumbnailUrl { get; set; }
        /// <summary>
        /// 库存总数
        /// </summary>
        public int StoreCount { get; set; }

        public List<string> ColorList
        {
            get
            {
                List<string> colorList = new List<string>();
                colorList.Clear();
                if (string.IsNullOrEmpty(this.Colors))
                {
                    return colorList;
                }
                string[] colors = this.Colors.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string color in colors)
                {
                    if (!colorList.Contains(color))
                    {
                        colorList.Add(color);
                    }
                }
                return colorList;
            }
        }

        /// <summary>
        /// 第一个string：原尺码名称XL，S 第二个string： 尺码别名 如28，29
        /// </summary>
        public Dictionary<string, string> SizeNameDIC { get; set; }
        public List<string> SizeNameList4Show
        {
            get
            {
                if (this.SizeNameDIC == null)
                {
                    return new List<string>();
                }
                List<string> sizeNames = new List<string>();
                foreach (KeyValuePair<string, string> item in this.SizeNameDIC)
                {
                    if (!sizeNames.Contains(item.Value))
                    {
                        sizeNames.Add(item.Value);
                    }
                }
                return sizeNames;
            }
        }

        public string ClassCode { get; set; }

        //public String SeasonValue
        //{
        //    get
        //    {
        //        String value = "";
        //        switch (Season)
        //        {
        //            case 0:
        //                value = "春";
        //                break;
        //            case 1:
        //                value = "夏";
        //                break;
        //            case 2:
        //                value = "秋"; break;
        //            case 3:
        //                value = "冬"; break;
        //            default:
        //                value = ""; break;

        //        }
        //        return value;
        //    }
        //}

        //public string BigClass { get; set; }

        //public string SmallClass { get; set; }

        //public string SubSmallClass { get; set; }

        public string ClassName { get; set; }

        public List<String> SizeNameList
        {
            get
            {
                List<String> sizeNames = null;
                if (!String.IsNullOrEmpty(SizeNames))
                {
                    String[] strs = SizeNames.Split(',');
                    sizeNames = new List<string>(strs);
                };
                return sizeNames;
            }
        }

        public bool IsSimpleWeb { get; set; }

        #region BigClassID
        private System.Int32 bigClassID = 0;
        /// <summary>
        /// ClassID 类别id
        /// </summary>
        public System.Int32 BigClassID
        {
            get
            {
                return this.bigClassID;
            }
            set
            {
                this.bigClassID = value;
            }
        }
        #endregion

        public string PhotoThumbnailUrl
        {
            get
            {
                return this.m_EmThumbnail;
            }
        }

        public List<EmCostumePhoto> PhotoUrls { get; set; }
    }
}
