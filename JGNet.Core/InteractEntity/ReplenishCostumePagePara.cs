using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class ReplenishCostumePagePara : BasePagePara
    {
        public string ShopID { get; set; }

        /// <summary>
        /// 单据编号
        /// </summary>
        public string ReplenishOrderID { get; set; }

        /// <summary>
        /// 款号
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        public int BrandID { get; set; }

        private int classId = -1;
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

        /// <summary>
        /// 补货申请单状态
        /// </summary>
        public ReplenishOrderState ReplenishOrderState { get; set; }

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
        
        public static implicit operator ReplenishCostumePagePara(OutboundOrderPagePara v)
        {
            throw new NotImplementedException();
        }
    }

    public class ReplenishCostumePage : BasePage
    {
        public List<ReplenishOrder> ReplenishOrderList { get; set; }
         

        public ReplenishOrder ReplenishOrderSum { get; set; }
    }
}
