using CJBasic.Helpers;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class DifferenceDetail: IStatisticabled
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 服装名称
        /// </summary>
        public string CostumeName { get; set; }

        private int sumCount = 0;

        /// <summary>
        /// 同款号同颜色所有尺码衣服的数量总和
        /// </summary>
        public int SumCount
        {
            get
            {
                if (!this.IsStatistics)
                {
                    return Math.Abs(this.XS) + Math.Abs(this.S) + Math.Abs(this.M) + Math.Abs(this.L) + Math.Abs(this.XL) + Math.Abs(this.XL2) + Math.Abs(this.XL3) + Math.Abs(this.XL4) + Math.Abs(this.XL5) + Math.Abs(this.XL6) + Math.Abs(this.F);
                }
                return this.sumCount;
            }
            set
            {               
                this.sumCount = Math.Abs(value);
            }

        }

        public bool IsStatistics { get ; set ; }

        /// <summary>
        /// 商品图片链接地址
        /// </summary>
        public string PhotoThumbnailUrl { get; set; }
        public List<DifferenceDetailInfo> DifferenceDetailInfos { get; set; }
    }

    [Serializable]
    /// <summary>
    /// 差异详情
    /// </summary>
    public class DifferenceDetailInfo
    {
        /// <summary>
        /// 原始尺码名称 （X,XL ...）
        /// </summary>
        public string OriginalSizeName { get; set; }

        /// <summary>
        /// 显示的尺码名称（20码，21码 ...）
        /// </summary>
        public string SizeName { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        public short OutStoreCount { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        public short InStoreCount { get; set; }

        /// <summary>
        /// 差异数
        /// </summary>
        public int DifStoreCount
        {
            get
            {

                return this.OutStoreCount - this.InStoreCount;
            }
        }

    }

}
