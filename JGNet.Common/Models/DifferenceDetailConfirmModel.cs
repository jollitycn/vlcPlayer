using JGNet.Core;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Common
{
    public class DifferenceDetailConfirmModel
    {
        #region CostumeID
        private System.String m_CostumeID = "";
        /// <summary>
        /// CostumeID 服装ID
        /// </summary>
        public System.String CostumeID
        {
            get
            {
                return this.m_CostumeID;
            }
            set
            {
                this.m_CostumeID = value;
            }
        }
        #endregion

        #region ColorName
        private System.String m_ColorName = "";
        /// <summary>
        /// ColorName 颜色
        /// </summary>
        public System.String ColorName
        {
            get
            {
                return this.m_ColorName;
            }
            set
            {
                this.m_ColorName = value;
            }
        }
        #endregion

        /// <summary>
        /// 商品名称
        /// </summary>
        public string CostumeName { get; set; }
        public string DisplaySizeName
        {
            get;set;
        }
        /// <summary>
        /// 尺码
        /// </summary>
        public string SizeName { get; set; }

        /// <summary>
        /// 出库数
        /// </summary>
        public int OutboundCount { get; set; }

        /// <summary>
        /// 入库数
        /// </summary>
        public int InboundCount { get; set; }

        /// <summary>
        /// 差异数
        /// </summary>
        public int DifferenceCount { get; set; } 


        public int ChangeCount { get; set; }
    }
}
