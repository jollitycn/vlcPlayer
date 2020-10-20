using JGNet.Core.InteractEntity;
using JGNet.Core.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Dev.InteractEntity
{
    /// <summary>
    /// 库存分析
    /// </summary>
    [Serializable] 
    public class CostumeStoreAnalysisInfo
    {
        private List<string> costumeIDs = new List<string>();
        public void SetCostumeID(string costumeID)
        {
            if (!this.costumeIDs.Contains(costumeID))
            {
                this.costumeIDs.Add(costumeID);
            }
        }

        public int CostumeCount
        {
            get
            {
                return this.costumeIDs.Count;
            }
        }

        /// <summary>
        /// 分析标题
        /// </summary>
        public string AnalysisTitle { get; set; }

        /// <summary>
        /// 库存总量
        /// </summary>
        public int CostumeStoreCount { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 参考成本总额
        /// </summary>
        public decimal CostPrice { get; set; }

        /// <summary>
        /// 数量占比
        /// </summary>
        public double CountRate { get; set; }

        /// <summary>
        /// 吊牌金额占比
        /// </summary>
        public double PriceRate { get; set; }

        /// <summary>
        /// 参考成本占比
        /// </summary>
        public double CostPriceRate { get; set; }


        /// <summary>
        /// 显示数量占比带%
        /// </summary>
        public string CountRateName { get { return StringHelper.RateToWithPercent(this.CountRate); } }

        /// <summary>
        /// 显示吊牌金额占比带%
        /// </summary>
        public string PriceRateName { get { return StringHelper.RateToWithPercent(this.PriceRate); } }

        /// <summary>
        /// 显示参考成本占比带%
        /// </summary>
        public string CostPriceRateName { get { return StringHelper.RateToWithPercent(this.CostPriceRate); } }

    }

    [Serializable]
    public class CostumeStoreAnalysis : BasePage
    {
        public CostumeStoreAnalysisInfo CostumeStoreAnalysisInfoSum { get; set; }

        public List<CostumeStoreAnalysisInfo> CostumeStoreAnalysisInfos { get; set; }
    }
}
