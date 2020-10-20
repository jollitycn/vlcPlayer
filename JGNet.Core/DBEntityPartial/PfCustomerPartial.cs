using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet
{
    public partial class PfCustomer
    {
        /// <summary>
        /// 用户类型
        /// </summary>
        public OLCustomerType Type { get; set; }

       // public String PfCustomerCode { get; set; }
        /// <summary>
        /// 佣金
        /// </summary>
        public decimal Commission { get; set; }
        /// <summary>
        /// 剩余的佣金
        /// </summary>
       // private decimal _remaining = 0;
        public decimal RemainingCommission
        {
            get
            {
                return this.AccruedCommission - this.ApplicationMoney;
            } 
            //set
            //{
            //    _remaining = value;
            //}
        }

        /// <summary>
        /// 待打款佣金
        /// </summary>
        public decimal WaitPayMoney { get; set; }

      
        /// <summary>
        /// 已申请佣金
        /// </summary>
        public decimal ApplicationMoney
        {
            get
            {
                return this.WaitPayMoney + this.WithdrawCommission;
            }
        }
        public string CustomerTypeName
        {
            get
            {
                string strName = "";
                if (this.CustomerType == 1)
                {
                    strName = "代卖";
                }
                else
                {

                    strName = "买断";
                }
                return strName;
            } 

        }

        //public string CustomerCode
        //{
        //    get;set;
        //}

       /* private System.String m_pfCodeid = "";

        public System.String PfCodeID
        {
            get
            {
                return this.m_pfCodeid;
            }
            set
            {
                this.m_pfCodeid = value;
            }
        }
        */

    }

    public enum OLCustomerType
    {
        /// <summary>
        /// 批发
        /// </summary>
        Pf = 0,

        /// <summary>
        /// 分销
        /// </summary>
        Fx=1,

        /// <summary>
        /// 零售
        /// </summary>
        Sale=100
    }
}
