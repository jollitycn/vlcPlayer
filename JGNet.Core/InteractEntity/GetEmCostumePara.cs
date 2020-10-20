using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class GetEmCostumePara
    {
        public string ID { get; set; }
    }

    [Serializable]
    public class EmCostumeInfo
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string EmTitle { get; set; }

        public string Colors { get; set; }

        public decimal EmOnlinePrice { get; set; }

        public Boolean EmShowOnline { get; set; }

        public string EmThumbnail { get; set; }

        public List<EmCostumePhoto> EmCostumePhotos { get; set; }

        public int CarriageCostTemplateID { get; set; }

        public string EmDetails { get; set; }

        /// <summary>
        /// 是否线上批发上架过
        /// </summary>
        public bool PfEverOnline { get; set; }

        /// <summary>
        /// 是否上架过？
        /// </summary>
        public bool EmEverOnline { get; set; }

        public bool PfShowOnline { get; set; }

        /// <summary>
        /// 同步上架线上批发商城
        /// </summary>
        //public bool IsSyncEmPfOnline { get; set; }

        public decimal PfOnlinePrice { get; set; }

        /// <summary>
        /// 零售
        /// </summary>
        public bool IsRetail { get; set; }

        /// <summary>
        /// 批发
        /// </summary>
        public bool IsPf { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public int ClassID { get; set; }

        /// <summary>
        /// 分销佣金模板id
        /// </summary>
        public int CommissionTemplateID { get; set; }

        /// <summary>
        /// 是否是新品
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// 是否是热卖
        /// </summary>
        public bool IsHot { get; set; }

        /// <summary>
        /// 线上吊牌价
        /// </summary>
        public decimal EmPrice { get; set; }
    }
}
