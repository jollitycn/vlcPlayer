using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class CheckBaseDataPara
    {
        public String BrandName { get; set; }
        
        public int BrandID { get; set; }
        
        public decimal CostPrice { get; set; }
        
        public decimal PfPrice { get; set; }

        public string CostumeID { get; set; }

        public string CostumeName { get; set; }

        public string CostumeColorID { get; set; }

        /// <summary>
        /// 修改库存对应的颜色
        /// </summary>
        public string CostumeColorName { get; set; }

        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }
        
        public string SupplierName { get; set; } 

        public string SupplierID { get; set; }

        public int Year { get; set; }

        public string Season { get; set; }
        
        public string Remarks { get; set; }

        public string SizeGroupName { get; set; }

        public string SizeGroupShowName { get; set; }

        public string SizeNames { get; set; }

        public string BigClass { get; set; }

        public string SmallClass { get; set; }

        public string SubSmallClass { get; set; }

        public int ClassID { get; set; }

        //public string ClassCode { get; set; }

        /// <summary>
        /// 线上零售价
        /// </summary>
        public decimal EmOnlinePrice { get; set; }

        /// <summary>
        /// 线上批发价
        /// </summary>
        public decimal PfOnlinePrice { get; set; }
    }

    public class CostumeStoreExcel : CheckBaseDataPara
    {
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

    }

    public class CreateCostumeStore
    {
        public string ShopID { get; set; }

        public Date Date { get; set; }

        public List<CostumeStoreExcel> CostumeStoreExcels { get; set; }

        public bool IsImport { get; set; }
    }

    public class CreatePfCostumeStore
    {
        public string PfCustomerID { get; set; }
        
        public List<CostumeStoreExcel> CostumeStoreExcels { get; set; }

        public bool IsImport { get; set; }
    }
}
