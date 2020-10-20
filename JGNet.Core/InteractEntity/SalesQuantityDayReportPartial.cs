using JGNet.Core.Tools;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class SalesQuantityDayReport
    {
        public string CostumeName { get; set; }

        public decimal Price { get; set; }

        public decimal CostPrice { get; set; }

        public string BrandName { get; set; }

        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 缩略图URL
        /// </summary>
        public string PhotoThumbnailURL { get; set; }

        /// <summary>
        /// 卖出的服装颜色 （中文逗号，分隔）
        /// </summary>
        public string Colors { get; set; }

        /// <summary>
        /// 平均折扣（用于界面显示 带%）
        /// </summary>
        public string AverageDiscountName
        {
            get
            {
                decimal value = this.QuantityOfSale * this.Price;
                if (value == 0)
                {
                    return string.Empty;
                }
                return ((int)(Server.Tools.MathHelper.Rounded(this.SumMoney / value, 2) * 100)).ToString();
            }
        }

        /// <summary>
        /// 平均售价
        /// </summary>
        public decimal AveragePirce
        {
            get
            {
                if (this.QuantityOfSale == 0)
                {
                    return 0;
                }
                return Server.Tools.MathHelper.Rounded(this.SumMoney / this.QuantityOfSale, 2);
            }
        }

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
    }
}
