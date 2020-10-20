using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class CheckStoreOrderPagePara : BasePagePara
    {
        /// <summary>
        /// 单据编号
        /// </summary>
        public string CheckStoreOrderID { get; set; }

        /// <summary>
        /// 模糊查询款号
        /// </summary>
        public bool IsLike { get; set; }

        /// <summary>
        /// 款号
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 店铺id
        /// </summary>
        public string ShopID { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public CheckStoreOrderState State { get; set; }

        /// <summary>
        /// 是否开启限制日期查询
        /// </summary>
        public bool IsOpenDate { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public Date StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public Date EndDate { get; set; }

        /// <summary>
        /// 是否仅显示有效的店铺 数据（ 过滤掉被禁用的店铺进入统计）
        /// </summary>
        public bool IsOnlyShowEnabledShop { get; set; }

        /// <summary>
        /// 是否过滤子盘点单
        /// </summary>
        public bool IsFilterChild { get; set; }

        /// <summary>
        /// 是否仅显示本店的数据
        /// </summary>
        public bool OnlyShowOwnShop { get; set; }
    }

    [Serializable]
    public class CheckStoreOrderPage : BasePage
    {
        public List<CheckStoreOrder> CheckStoreOrderList { get; set; }
         
        public CheckStoreOrder CheckStoreOrderSum { get; set; }
    }
}
