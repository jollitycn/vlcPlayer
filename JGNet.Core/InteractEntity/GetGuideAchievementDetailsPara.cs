using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GetGuideAchievementDetailsPara
    {
        public string GuideID { get; set; }

        public int Date { get; set; }
    }

    public class GuideAchievementDetail
    {
        /// <summary>
        /// 导购员名称
        /// </summary>
        public string GuideName { get; set; }

        /// <summary>
        /// 销售单号
        /// </summary>
        public string RetailOrderID { get; set; }

        /// <summary>
        /// 款号
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string CostumeName { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string ColorName { get; set; }
        public string SizeDisplayName { get; set; }
        
        /// <summary>
        /// 尺码
        /// </summary>
        public string SizeName { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int BuyCount { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal SumMoney { get; set; }

        /// <summary>
        /// 会员卡号
        /// </summary>
        public string MemeberID { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 单据编号
        /// </summary>
        public string OrderRemarks { get; set; }
    }
}
