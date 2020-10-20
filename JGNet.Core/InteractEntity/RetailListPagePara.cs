using CJBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class RetailListPagePara : BasePagePara
    {
        /// <summary>
        /// 店铺id
        /// </summary>
        public string ShopID { get; set; }

        /// <summary>
        /// 导购员id
        /// </summary>
        public string GuideID { get; set; }

        /// <summary>
        /// 会员id
        /// </summary>
        public string MemberID { get; set; }

        /// <summary>
        /// 单据类型
        /// </summary>
        public RetailOrderType RetailOrderType { get; set; }

        /// <summary>
        /// 销售单id
        /// </summary>
        public string RetailOrderID { get; set; }

        /// <summary>
        /// 款号
        /// </summary>
        public string CostumeID { get; set; }

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
        /// 品牌
        /// </summary>
        public int BrandID { get; set; }

        private int classId = -1;
        /// <summary>
        /// 类别id,(-1:不过滤)
        /// </summary>
        public int ClassID
        {
            get
            {
                return this.classId;
            }
            set
            {
                this.classId = value;
            }
        }

        public RetailOrderState RetailOrderState { get; set; }

        public bool IsGetGeneralStore { get; set; }

        /// <summary>
        /// 付款类型
        /// </summary>
        public RetailPayType RetailPayType { get; set; }

        /// <summary>
        /// 仅看未付款单
        /// </summary>
        public bool IsOnlyNotPay { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }

    public class RetailListPage : BasePage
    {
        public List<RetailOrder> ResultList { get; set; }
         
        public RetailOrder RetailOrderSum { get; set; }
    }

    public enum RetailPayType
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        All = -1,

        /// <summary>
        /// 现金
        /// </summary>
        [Description("现金")]
        Cash = 0,

        /// <summary>
        /// 银联卡
        /// </summary>
        [Description("银联卡")]
        BankCard,

        /// <summary>
        /// 微信
        /// </summary>
        [Description("微信")]
        WeiXin,

        /// <summary>
        /// 支付宝
        /// </summary>
        [Description("支付宝")]
        Alipay,

        /// <summary>
        /// VIP卡
        /// </summary>
        [Description("VIP卡")]
        VipCard,

        /// <summary>
        /// 优惠券
        /// </summary>
        [Description("优惠券")]
        Ticket,

        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other
    }

    public enum RetailOrderState
    {
        All = 0,

        /// <summary>
        /// 已冲单
        /// </summary>
        IsCancel = 1,

        /// <summary>
        /// 正常
        /// </summary>
        IsNormal = 2,

        IsRefund = 3,

        IsEffective = 4
    }
}
