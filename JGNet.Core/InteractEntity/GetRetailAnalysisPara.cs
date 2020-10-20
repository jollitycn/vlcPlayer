﻿using JGNet.Core.Const;
using JGNet.Core.Dev.MyEnum;
using JGNet.Server.Tools;
using CJBasic;
using CJBasic.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GetRetailAnalysisPara
    {
        public GroupType GroupType { get; set; }

        public string CostumeID { get; set; }

        public string ShopID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }

        public bool IsGetGeneralStore { get; set; }
    }

    [Serializable]
    public class RetailAnalysis : IStatisticabled
    {
        public string CostumeID { get; set; }

        public bool IsStatistics { get; set; }
        public string ShopID { get; set; }

        public string ParaValue { get; set; }

        /// <summary>
        /// 分组
        /// </summary>
        public string GroupTypeName { get; set; }

        /// <summary>
        /// 销量
        /// </summary>
        public int QuantityOfSale { get; set; }


        private int quantityOfSaleActual;
        /// <summary>
        /// 实际销量
        /// </summary>
        public int QuantityOfSaleActual
        { 
            get
            {
                if (!this.IsStatistics)
                {
                    return this.QuantityOfSale - this.QuantityOfRefund;
                }
                return this.quantityOfSaleActual;
            }
            set
            {
                this.quantityOfSaleActual = value;
            }
        }

        /// <summary>
        /// 退货
        /// </summary>
        public int QuantityOfRefund { get; set; }

        /// <summary>
        /// 实收额
        /// </summary>
        public decimal SalesTotalMoney { get; set; }

        /// <summary>
        /// 销售成本
        /// </summary>
        public decimal SalesTotalCost { get; set; }

        /// <summary>
        /// 毛利
        /// </summary>
        public decimal SalesBenefit { get; set; }

        /// <summary>
        /// 毛利率
        /// </summary>
        public decimal BenefitRate { get; set; }

        /// <summary>
        /// 毛利率(带%，用于显示)
        /// </summary>
        public string BenefitRateName {
            get { return Core.Tools.StringHelper.RateToWithPercent(this.BenefitRate); }
        }

        /// <summary>
        /// 退货率
        /// </summary>
        public decimal RefundRate { get; set; }
        /// <summary>
        /// 退货率(带%，用于显示)
        /// </summary>
        public string RefundRateName
        {
            get { return Core.Tools.StringHelper.RateToWithPercent(this.RefundRate); }
        }

        /// <summary>
        /// 期初库存
        /// </summary>
        public int StartCostumeStoreCount { get; set; }

        /// <summary>
        /// 期末库存
        /// </summary>
        public int EndCostumeStoreCount { get; set; }
        
        /// <summary>
        /// 销量占比
        /// </summary>
        public decimal QuantityOfSaleRate { get; set; }

        /// <summary>
        /// 销量占比(带%，用于显示)
        /// </summary>
        public string QuantityOfSaleRateName
        {
            get { return Core.Tools.StringHelper.RateToWithPercent(this.QuantityOfSaleRate); }
        }

        /// <summary>
        /// 销售额
        /// </summary>
        public decimal RetailMoney { get; set; }
        
        /// <summary>
        /// 销售占比
        /// </summary>
        public decimal RetailMoneyRate { get; set; }

        /// <summary>
        /// 销售占比(带%，用于显示)
        /// </summary>
        public string RetailMoneyRateName
        {
            get { return Core.Tools.StringHelper.RateToWithPercent(this.RetailMoneyRate); }
        }

        /// <summary>
        /// 售罄率
        /// </summary>
        public decimal RetailRate { get; set; }
        /// <summary>
        /// 售罄率(带%，用于显示)
        /// </summary>
        public string RetailRateName
        {
            get { return Core.Tools.StringHelper.RateToWithPercent(this.RetailRate); }
        }

        /// <summary>
        /// 货占比
        /// </summary>
        public decimal CostumeRate { get; set; }
        /// <summary>
        /// 货占比(带%，用于显示)
        /// </summary>
        public string CostumeRateName
        {
            get { return Core.Tools.StringHelper.RateToWithPercent(this.CostumeRate); }
        }
    }

    public class GetRetailAnalysisDeatilInfoPara
    {
        public string ShopID { get; set; }

        public string ParaValue { get; set; }
        
        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
        
        public GroupType GroupType { get; set; }

        public bool IsChooseColor { get; set; }

        public bool IsChooseSize { get; set; }

        public string CostumeID { get; set; }
    }

    [Serializable]
    public class RetailAnalysisDeatilInfo : BasePage
    {
        public string TimeRange { get; set; }

        public List<RetailAnalysisDeatil> RetailAnalysisDeatils { get; set; }

        public RetailAnalysisDeatil RetailAnalysisDeatilSum { get; set; }
    }
    [Serializable]
    public class RetailAnalysisDeatil
    {
        public string BrandName { get; set; }

        public string CostumeID { get; set; }

        public string CostumeName { get; set; }

        public string ColorName { get; set; }

        public string SizeName { get; set; }

        public int SalesCount { get; set; }

        public string PhotoThumbnailURL { get; set; }

        public decimal SalesMoney { get; set; }

        #region XS
        private System.Int16 m_XS = 0;
        /// <summary>
        /// XS XS尺码件数
        /// </summary>
        public System.Int16 XS
        {
            get
            {
                return this.m_XS;
            }
            set
            {
                this.m_XS = value;
            }
        }
        #endregion

        #region S
        private System.Int16 m_S = 0;
        /// <summary>
        /// S S尺码件数
        /// </summary>
        public System.Int16 S
        {
            get
            {
                return this.m_S;
            }
            set
            {
                this.m_S = value;
            }
        }
        #endregion

        #region M
        private System.Int16 m_M = 0;
        /// <summary>
        /// M M尺码件数
        /// </summary>
        public System.Int16 M
        {
            get
            {
                return this.m_M;
            }
            set
            {
                this.m_M = value;
            }
        }
        #endregion

        #region L
        private System.Int16 m_L = 0;
        /// <summary>
        /// L L尺码件数
        /// </summary>
        public System.Int16 L
        {
            get
            {
                return this.m_L;
            }
            set
            {
                this.m_L = value;
            }
        }
        #endregion

        #region XL
        private System.Int16 m_XL = 0;
        /// <summary>
        /// XL XL尺码件数
        /// </summary>
        public System.Int16 XL
        {
            get
            {
                return this.m_XL;
            }
            set
            {
                this.m_XL = value;
            }
        }
        #endregion

        #region XL2
        private System.Int16 m_XL2 = 0;
        /// <summary>
        /// XL2 2XL尺码件数
        /// </summary>
        public System.Int16 XL2
        {
            get
            {
                return this.m_XL2;
            }
            set
            {
                this.m_XL2 = value;
            }
        }
        #endregion

        #region XL3
        private System.Int16 m_XL3 = 0;
        /// <summary>
        /// XL3 3XL尺码件数
        /// </summary>
        public System.Int16 XL3
        {
            get
            {
                return this.m_XL3;
            }
            set
            {
                this.m_XL3 = value;
            }
        }
        #endregion

        #region XL4
        private System.Int16 m_XL4 = 0;
        /// <summary>
        /// XL4 4XL尺码件数
        /// </summary>
        public System.Int16 XL4
        {
            get
            {
                return this.m_XL4;
            }
            set
            {
                this.m_XL4 = value;
            }
        }
        #endregion

        #region XL5
        private System.Int16 m_XL5 = 0;
        /// <summary>
        /// XL5 5XL尺码件数
        /// </summary>
        public System.Int16 XL5
        {
            get
            {
                return this.m_XL5;
            }
            set
            {
                this.m_XL5 = value;
            }
        }
        #endregion

        #region XL6
        private System.Int16 m_XL6 = 0;
        /// <summary>
        /// XL6 6XL尺码件数
        /// </summary>
        public System.Int16 XL6
        {
            get
            {
                return this.m_XL6;
            }
            set
            {
                this.m_XL6 = value;
            }
        }
        #endregion

        #region F
        private System.Int16 m_F = 0;
        /// <summary>
        /// F F尺码件数
        /// </summary>
        public System.Int16 F
        {
            get
            {
                return this.m_F;
            }
            set
            {
                this.m_F = value;
            }
        }
        #endregion

        /// <summary>
        /// 销售尺码数量对应的数量（除去数量为0）
        /// </summary>
        public string SizeCountString { get; set; }

        public string[] SizeCountStringList
        {
            get
            {
                if (string.IsNullOrEmpty(this.SizeCountString))
                {
                    return new string[0];
                }
                return this.SizeCountString.Split(SystemDefault.Semicolon.ToCharArray());
            }
        }
    }
}
